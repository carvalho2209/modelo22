using System.Text;
using System.Linq;
using Model22TextFile.Domain.Extensions;
using Model22TextFile.Domain.File;

namespace Model22TextFile.Domain.Model22
{
    public class RegistroDadosCadastrais : Registro
    {
        private readonly NumericoCodigoIdentificacao _cnpjCpf = new NumericoCodigoIdentificacao("CNPJ", 14);
        private readonly Alpha _ie = new Alpha("IE", 14, isMandatory: true);
        private readonly Alpha _razaoSocial = new Alpha("RazaoSocial", 35, isMandatory: true);
        private readonly Alpha _logradouro = new Alpha("Logradouro", 45);
        private readonly NumericoCodigoIdentificacao _numero = new NumericoCodigoIdentificacao("Numero", 5);
        private readonly Alpha _complemento = new Alpha("Complemento", 15);
        private readonly NumericoCodigoIdentificacao _cep = new NumericoCodigoIdentificacao("CEP", 8);
        private readonly Alpha _bairro = new Alpha("Bairro", 15);
        private readonly Alpha _municipio = new Alpha("Municipio", 30);
        private readonly Alpha _uf = new Alpha("UF", 2);
        private readonly NumericoCodigoIdentificacao _telefone = new NumericoCodigoIdentificacao("Telefone", 12);
        private readonly Alpha _codigoIdentConsumidor = new Alpha("Cod. Ident. Consumidor", 12);
        private readonly Alpha _numeroTerminalTel = new Alpha("Num. Terminal Tel", 12);
        private readonly Alpha _ufTermTel = new Alpha("UF Term. Tel.", 2);
        private readonly Alpha _brancos = new Alpha("Brancos", 5);
        private readonly Alpha _codigoAutDigital = new Alpha("Cod. Autenticacao Digital", 32, isMandatory: true);

        private readonly IStoreModel22 _parametro;
        private StringBuilder _conteudo;

        public RegistroDadosCadastrais(IStoreModel22 parametro)
        {
            _parametro = parametro;
            AddFields();
            _conteudo = new StringBuilder();
        }

        private void AddFields()
        {
            AddField(_cnpjCpf);
            AddField(_ie);
            AddField(_razaoSocial);
            AddField(_logradouro);
            AddField(_numero);
            AddField(_complemento);
            AddField(_cep);
            AddField(_bairro);
            AddField(_municipio);
            AddField(_uf);
            AddField(_telefone);
            AddField(_codigoIdentConsumidor);
            AddField(_numeroTerminalTel);
            AddField(_ufTermTel);
            AddField(_brancos);
            AddField(_codigoAutDigital);
        }

        public override void Append(StringBuilder stringBuilder)
        {
            //var dadosCadastrais = _parametro.Movimentos.GetMovimentoAgrupadoDadosCadastrais();

            var dadosCadastrais = _parametro
                                  .Movimentos
                                  .GroupBy(m => new
                                  {
                                      m.ClienteCpfCnpj,
                                      m.ClienteIe,
                                      m.ClienteRazaoSocial,
                                      m.ClienteLogradouro,
                                      m.ClienteEnderecoNumero,
                                      m.ClienteCep,
                                      m.ClienteBairro,
                                      m.ClienteMunicipio,
                                      m.ClienteUf,
                                      m.ClienteTelefone,
                                      m.DataEmissao,
                                      m.ClienteCodigo,
                                      m.Modelo,
                                      m.Serie,
                                      m.NumeroNf,
                                      m.Situacao,
                                  });

            foreach (var cliente in dadosCadastrais)
            {
                SetValue(_cnpjCpf, cliente.Key.ClienteCpfCnpj);
                SetValue(_ie, cliente.Key.ClienteIe);
                SetValue(_razaoSocial, cliente.Key.ClienteRazaoSocial.NoAccents());
                SetValue(_logradouro, cliente.Key.ClienteLogradouro.NoAccents().NoSimbols());
                SetValue(_numero, cliente.Key.ClienteEnderecoNumero.NoAccents().NoSimbols());
                SetValue(_complemento, string.Empty);
                SetValue(_cep, cliente.Key.ClienteCep);
                SetValue(_bairro, cliente.Key.ClienteBairro.NoAccents().NoSimbols());
                SetValue(_municipio, cliente.Key.ClienteMunicipio.NoAccents().NoSimbols());
                SetValue(_uf, cliente.Key.ClienteUf);
                SetValue(_telefone, cliente.Key.ClienteTelefone);
                SetValue(_codigoIdentConsumidor, cliente.Key.ClienteCpfCnpj.NoSimbols().NoSpaces());
                SetValue(_numeroTerminalTel, string.Empty);
                SetValue(_ufTermTel, string.Empty);

                SetValue(_brancos, string.Empty);

                _codigoAutDigital.Value = HashCode.GetMd5Hash(_conteudo.ToString()).ToUpper();
                AppendLine(stringBuilder);
                _conteudo.Clear();
            }
        }
        private void SetValue(ICampo pObject, object pValue)
        {
            pObject.Value = pValue;
            _conteudo.Append(pObject);
        }
    }
}
