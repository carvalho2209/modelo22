using System;
using System.Text;
using System.Linq;
using Model22TextFile.Domain.Extensions;
using Model22TextFile.Domain.File;

namespace Model22TextFile.Domain.Model22
{
    public class RegistroInformacaoControle : Registro
    {
        private readonly Alpha _cnpj = new Alpha("Cnpj", 18);
        private readonly Alpha _ie = new Alpha("IE", 15);
        private readonly Alpha _razaoSocial = new Alpha("Razao Social", 50);
        private readonly Alpha _endereco = new Alpha("Endereco", 50);
        private readonly Alpha _cep = new Alpha("CEP", 9);
        private readonly Alpha _bairro = new Alpha("Bairro", 30);
        private readonly Alpha _municipio = new Alpha("Municipio", 30);
        private readonly Alpha _uf = new Alpha("UF", 2);
        private readonly Alpha _responsavel = new Alpha("Responsavel", 30);
        private readonly Alpha _cargo = new Alpha("Cargo", 20);
        private readonly Alpha _telefone = new Alpha("Telefone", 12);
        private readonly Alpha _email = new Alpha("Email", 40);

        // Registro Mestre
        private readonly NumericoCodigoIdentificacao _qtdRegistroMestre = new NumericoCodigoIdentificacao("Qtd. Arq. Registro mestre", 7);
        private readonly NumericoCodigoIdentificacao _qtdNfCancelada = new NumericoCodigoIdentificacao("Qtd. Nf Canceladas", 7);
        private readonly NumericoData _dataEmissaoPrimeiroDocMestre = new NumericoData("Data Emissao Primeiro Doc");
        private readonly NumericoData _dataEmissaoUltimoDocMestre = new NumericoData("Data Emissao Ultimo Doc");
        private readonly NumericoCodigoIdentificacao _numeroPrimeiroDocMestre = new NumericoCodigoIdentificacao("Numero Primeiro Doc", 9);
        private readonly NumericoCodigoIdentificacao _numeroUltimoDocMestre = new NumericoCodigoIdentificacao("Numero Ultimo Doc", 9);
        private readonly Numerico _valorTotalMestre = new Numerico("ValorTotal", 14, scale: 2);
        private readonly Numerico _baseIcmsMestre = new Numerico("Base Icms", 14, scale: 2);
        private readonly Numerico _valorIcmsMestre = new Numerico("Valor Icms", 14, scale: 2);
        private readonly Numerico _valorIsentosMestre = new Numerico("Valor Isentos", 14, scale: 2);
        private readonly Numerico _valorOutrosMestre = new Numerico("Valor Outros", 14, scale: 2);
        private readonly Alpha _nomeArquivoMestre = new Alpha("Nome Arq. Mestre", 15);
        private readonly Alpha _statusRetificacaoMestre = new Alpha("Status Retificacao", 1);
        private readonly Alpha _codigoAutDigitalMestre = new Alpha("Cod. Autenticacao Digital Mestre", 32, isMandatory: true);

        // Registro Item
        private readonly NumericoCodigoIdentificacao _qtdRegistroItem = new NumericoCodigoIdentificacao("Qtd. Arq. Registro item", 9);
        private readonly NumericoCodigoIdentificacao _qtdItemCancelado = new NumericoCodigoIdentificacao("Qtd. Item Canceladas", 7);
        private readonly NumericoData _dataEmissaoPrimeiroDocItem = new NumericoData("Data Emissao Primeiro Doc");
        private readonly NumericoData _dataEmissaoUltimoDocItem = new NumericoData("Data Emissao Ultimo Doc");
        private readonly NumericoCodigoIdentificacao _numeroPrimeiroDocItem = new NumericoCodigoIdentificacao("Numero Primeiro Doc", 9);
        private readonly NumericoCodigoIdentificacao _numeroUltimoDocItem = new NumericoCodigoIdentificacao("Numero Ultimo Doc", 9);
        private readonly Numerico _valorTotalItem = new Numerico("ValorTotal", 14, scale: 2);
        private readonly Numerico _valorDescontoItem = new Numerico("valorDescontoItem", 14, scale: 2);
        private readonly Numerico _valorAcrescimoItem = new Numerico("valorAcrescimoItem", 14, scale: 2);
        private readonly Numerico _baseIcmsItem = new Numerico("Base Icms", 14, scale: 2);
        private readonly Numerico _valorIcmsItem = new Numerico("Valor Icms", 14, scale: 2);
        private readonly Numerico _valorIsentosItem = new Numerico("Valor Isentos", 14, scale: 2);
        private readonly Numerico _valorOutrosItem = new Numerico("Valor Outros", 14, scale: 2);
        private readonly Alpha _nomeArquivoItem = new Alpha("Nome Arq. Item", 15);
        private readonly Alpha _statusRetificacaoItem = new Alpha("Status Retificacao", 1);
        private readonly Alpha _codigoAutDigitalItem = new Alpha("Cod. Autenticacao Digital Item", 32, isMandatory: true);

        // Registro Dados Cadastrais
        private readonly NumericoCodigoIdentificacao _qtdRegistroDadosCadastro = new NumericoCodigoIdentificacao("Qtd Registro Dados Cadastrais", 7);
        private readonly Alpha _nomeArquivoDadosCadastrais = new Alpha("Nome arq. Dados Cadastrais", 15);
        private readonly Alpha _statusRetificacaoArquivoDadosCadastrais = new Alpha("_statusRetificacaoArquivoDadosCadastrais", 1);
        private readonly Alpha _codigoAutDigitalDadosCadastrais = new Alpha("_codigoAutDigitalDadosCadastrais", 32);

        private readonly NumericoCodigoIdentificacao _versaoValidador = new NumericoCodigoIdentificacao("_versaoValidador", 3);
        private readonly Alpha _chaveControle = new Alpha("_chaveControle", 6); // Layout diz que tem 9 posicoes mais sendo 727 a 732
        private readonly NumericoCodigoIdentificacao _qtdadeAdvertencias = new NumericoCodigoIdentificacao("_qtdadeAdvertencias", 9);

        private readonly Alpha _brancos = new Alpha("Brancos", 24);
        private readonly Alpha _codigoAutDigitalRegistro = new Alpha("Cod. Autenticacao Digital", 32, isMandatory: true);

        private readonly IStoreModel22 _parametro;
        private readonly IHashDosArquivos _hashDosArquivos;
        private StringBuilder _conteudoParcial;
        private StringBuilder _conteudoArquivo;

        private string _fullPath;

        public RegistroInformacaoControle(IStoreModel22 parametro, IHashDosArquivos hashDosArquivos, string fullPath)
        {
            _parametro = parametro;
            _hashDosArquivos = hashDosArquivos;
            _fullPath = fullPath;
            AddFields();

            _conteudoParcial = new StringBuilder();
            _conteudoArquivo = new StringBuilder();
        }

        private void AddFields()
        {
            AddField(_cnpj);
            AddField(_ie);
            AddField(_razaoSocial);
            AddField(_endereco);
            AddField(_cep);
            AddField(_bairro);
            AddField(_municipio);
            AddField(_uf);
            AddField(_responsavel);
            AddField(_cargo);
            AddField(_telefone);
            AddField(_email);

            // Registro Mestre
            AddField(_qtdRegistroMestre);
            AddField(_qtdNfCancelada);
            AddField(_dataEmissaoPrimeiroDocMestre);
            AddField(_dataEmissaoUltimoDocMestre);
            AddField(_numeroPrimeiroDocMestre);
            AddField(_numeroUltimoDocMestre);
            AddField(_valorTotalMestre);
            AddField(_baseIcmsMestre);
            AddField(_valorIcmsMestre);
            AddField(_valorIsentosMestre);
            AddField(_valorOutrosMestre);
            AddField(_nomeArquivoMestre);
            AddField(_statusRetificacaoMestre);
            AddField(_codigoAutDigitalMestre);

            // Registro Item
            AddField(_qtdRegistroItem);
            AddField(_qtdItemCancelado);
            AddField(_dataEmissaoPrimeiroDocItem);
            AddField(_dataEmissaoUltimoDocItem);
            AddField(_numeroPrimeiroDocItem);
            AddField(_numeroUltimoDocItem);
            AddField(_valorTotalItem);
            AddField(_valorDescontoItem);
            AddField(_valorAcrescimoItem);
            AddField(_baseIcmsItem);
            AddField(_valorIcmsItem);
            AddField(_valorIsentosItem);
            AddField(_valorOutrosItem);
            AddField(_nomeArquivoItem);
            AddField(_statusRetificacaoItem);
            AddField(_codigoAutDigitalItem);

            // Registro Dados Cadastrais
            AddField(_qtdRegistroDadosCadastro);
            AddField(_nomeArquivoDadosCadastrais);
            AddField(_statusRetificacaoArquivoDadosCadastrais);
            AddField(_codigoAutDigitalDadosCadastrais);

            AddField(_versaoValidador);
            AddField(_chaveControle);
            AddField(_qtdadeAdvertencias);
            AddField(_brancos);
            AddField(_codigoAutDigitalRegistro);
        }

        public override void Append(StringBuilder stringBuilder)
        {
            var movimentos = _parametro
                            .Movimentos
                            .GroupBy(m => new
                            {
                                m.EstabelecimentoCpfCnpj,
                                m.EstabelecimentoIe,
                                m.EstabelecimentoRazaoSocial,
                                m.EstabelecimentoCep,
                                m.EstabelecimentoBairro,
                                m.EstabelecimentoMunicipio,
                                m.EstabelecimentoUf,
                                m.EstabelecimentoEndereco,
                                m.Responsavel,
                                m.ResponsavelCargo,
                                m.ResponsavelEmail,
                                m.ResponsavelTelefone,
                            });

            foreach (var movimento in movimentos)
            {
                SetValue(_cnpj, movimento.Key.EstabelecimentoCpfCnpj);
                SetValue(_ie, movimento.Key.EstabelecimentoIe);
                SetValue(_razaoSocial, movimento.Key.EstabelecimentoRazaoSocial);
                SetValue(_endereco, movimento.Key.EstabelecimentoEndereco);
                SetValue(_cep, movimento.Key.EstabelecimentoCep.Replace(".",""));
                SetValue(_bairro, movimento.Key.EstabelecimentoBairro);
                SetValue(_municipio, movimento.Key.EstabelecimentoMunicipio);
                SetValue(_uf, movimento.Key.EstabelecimentoUf);
                SetValue(_responsavel, movimento.Key.Responsavel);
                SetValue(_cargo, movimento.Key.ResponsavelCargo);
                SetValue(_telefone, movimento.Key.ResponsavelTelefone);
                SetValue(_email, movimento.Key.ResponsavelEmail);

                // Registro Mestre
                _conteudoParcial.Clear();
                SetValue(_qtdRegistroMestre, _parametro.Movimentos.GetMovimentoAgrupadoDadosCadastrais().Count());
                SetValue(_qtdNfCancelada, 0);
                SetValue(_dataEmissaoPrimeiroDocMestre, _parametro.Movimentos.Min(v => v.DataEmissao));
                SetValue(_dataEmissaoUltimoDocMestre, _parametro.Movimentos.Max(v => v.DataEmissao));
                SetValue(_numeroPrimeiroDocMestre, _parametro.Movimentos.Min(v => v.NumeroNf));
                SetValue(_numeroUltimoDocMestre, _parametro.Movimentos.Max(v => v.NumeroNf));
                SetValue(_valorTotalMestre, _parametro.Movimentos.Sum(v => v.ValorTotal));
                SetValue(_baseIcmsMestre, _parametro.Movimentos.Sum(v => v.ValorBaseIcms));
                SetValue(_valorIcmsMestre, _parametro.Movimentos.Sum(v => v.ValorIcms));
                SetValue(_valorIsentosMestre, _parametro.Movimentos.Sum(v => v.ValorIcmsIsento));
                SetValue(_valorOutrosMestre, _parametro.Movimentos.Sum(v => v.ValorIcmsOutros));
                SetValue(_nomeArquivoMestre, ArquivoModel22.GetFileNameArquivoMestre());
                SetValue(_statusRetificacaoMestre, _parametro.GetStringRetificacao());
                _codigoAutDigitalMestre.Value = HashCode.GetMd5Hash(_conteudoParcial.ToString()).ToUpper();

                // Registro Item
                _conteudoParcial.Clear();
                SetValue(_qtdRegistroItem, _parametro.Movimentos.GetMovimentoAgrupadoItem().Count());
                SetValue(_qtdItemCancelado, 0);
                SetValue(_dataEmissaoPrimeiroDocItem, _parametro.Movimentos.Min(v => v.DataEmissao));
                SetValue(_dataEmissaoUltimoDocItem, _parametro.Movimentos.Max(v => v.DataEmissao));
                SetValue(_numeroPrimeiroDocItem, _parametro.Movimentos.Min(v => v.NumeroNf));
                SetValue(_numeroUltimoDocItem, _parametro.Movimentos.Max(v => v.NumeroNf));
                SetValue(_valorTotalItem, _parametro.Movimentos.Sum(v => v.ValorTotal));
                SetValue(_valorDescontoItem, _parametro.Movimentos.Sum(v => v.ValorDesconto));
                SetValue(_valorAcrescimoItem, _parametro.Movimentos.Sum(v => v.ValorAcrescimo));
                SetValue(_baseIcmsItem, _parametro.Movimentos.Sum(v => v.ValorBaseIcms));
                SetValue(_valorIcmsItem, _parametro.Movimentos.Sum(v => v.ValorIcms));
                SetValue(_valorIsentosItem, _parametro.Movimentos.Sum(v => v.ValorIcmsIsento));
                SetValue(_valorOutrosItem, _parametro.Movimentos.Sum(v => v.ValorIcmsOutros));
                SetValue(_nomeArquivoItem, ArquivoModel22.GetFileNameArquivoItem());
                SetValue(_statusRetificacaoItem, _parametro.GetStringRetificacao());
                _codigoAutDigitalItem.Value = HashCode.GetMd5Hash(_conteudoParcial.ToString()).ToUpper();

                // Registro Dados Cadastrais
                _conteudoParcial.Clear();
                
                SetValue(_qtdRegistroDadosCadastro, _parametro.Movimentos.GetMovimentoAgrupadoDadosCadastrais().Count());
                SetValue(_nomeArquivoDadosCadastrais, ArquivoModel22.GetFileNameArquivoDadosCadastrais());

                SetValue(_statusRetificacaoArquivoDadosCadastrais, _parametro.GetStringRetificacao());
                _codigoAutDigitalDadosCadastrais.Value = HashCode.GetMd5Hash(_conteudoParcial.ToString()).ToUpper();

                SetValue(_versaoValidador, 208);
                SetValue(_chaveControle, string.Empty);
                SetValue(_qtdadeAdvertencias, 0);

                SetValue(_brancos, string.Empty);

                _codigoAutDigitalRegistro.Value = HashCode.GetMd5Hash(_conteudoArquivo.ToString()).ToUpper();

                AppendLine(stringBuilder);
                
                _conteudoArquivo.Clear();

                var historico = new HistoricoModelo22E21
                {
                    NomeDoArquioMestre = ArquivoModel22.GetFileNameArquivoMestre(),
                    HashDoArquivoMestere = _codigoAutDigitalMestre.Value.ToString(),
                    NomeDoArquivoItem = ArquivoModel22.GetFileNameArquivoItem(),
                    HashDoArquivoItem = _codigoAutDigitalItem.Value.ToString(),
                    NomeDoArquivoDados = ArquivoModel22.GetFileNameArquivoDadosCadastrais(),
                    HashDoArquivoDados = GetCodigoAtuDigital(ArquivoModel22.GetFileNameArquivoDadosCadastrais()),
                    QtdRegistroMestre = _parametro.Movimentos.GetMovimentoAgrupadoItem().Count(),
                    ValorTotal = (decimal)_valorTotalItem.Value,
                    ValorDesconto = (decimal)_valorDescontoItem.Value,
                    ValorAcrescimo = (decimal)_valorAcrescimoItem.Value,
                    ValorIcms = (decimal)_valorIcmsItem.Value,
                    ValorBaseIcms = (decimal)_baseIcmsItem.Value,
                    ValorBaseIsentas = (decimal)_valorIsentosItem.Value,
                    ValorOutros = (decimal)_valorOutrosItem.Value,
                    ReferenciaInicial = _parametro.DataInicio,
                    ReferenciaFinal = _parametro.DataFim,
                    CodigoDaFilial = _parametro.EstabelecimentoId
                };                

                _hashDosArquivos.SalvarHash(historico);
            }
        }

        private string GetCodigoAtuDigitalArquivoDadosCadastrais()
        {
            throw new NotImplementedException();
        }

        private string GetCodigoAtuDigitalArquivoItem()
        {
            return GetCodigoAtuDigital(ArquivoModel22.GetFileNameArquivoItem());
        }

        private string GetCodigoAtuDigital(string nomeDoArquivo)
        {
            var fullPath = System.IO.Path.Combine(_fullPath, nomeDoArquivo);
            var fileString = System.IO.File.ReadAllText(fullPath);

            return HashCode.GetMd5Hash(fileString).ToUpper();
        }

        private void SetValue(ICampo pObject, object pValue)
        {
            pObject.Value = pValue;
            _conteudoParcial.Append(pObject);
            _conteudoArquivo.Append(pObject);
        }
    }
}
