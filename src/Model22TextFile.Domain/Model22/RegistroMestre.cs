using System;
using System.Text;
using System.Linq;
using Model22TextFile.Domain.Extensions;
using Model22TextFile.Domain.File;
using Model22TextFile.Infra;
using System.Collections.Generic;

namespace Model22TextFile.Domain.Model22
{
    public class RegistroMestre : Registro
    {
        private readonly NumericoCodigoIdentificacao _cnpjCpf = new NumericoCodigoIdentificacao("CNPJ", 14);
        private readonly Alpha _ie = new Alpha("IE", 14, isMandatory: true);
        private readonly Alpha _razaoSocial = new Alpha("RazaoSocial", 35, isMandatory: true);
        private readonly Alpha _uf = new Alpha("UF", 2, isMandatory: true);
        private readonly NumericoCodigoIdentificacao _classeConsumoTipoAssinante = new NumericoCodigoIdentificacao("ClasseConsumoTipoAssinante", 1);
        private readonly NumericoCodigoIdentificacao _faseTipoUtil = new NumericoCodigoIdentificacao("FaseTipoUtil", 1);
        private readonly NumericoCodigoIdentificacao _grupoTensao = new NumericoCodigoIdentificacao("_grupoTensao", 2);
        private readonly NumericoCodigoIdentificacao _codigoIdentConsumidor = new NumericoCodigoIdentificacao("_codigoIdentConsumidor", 12);
        private readonly NumericoData _dataEmissao = new NumericoData("dataEmissao");
        private readonly NumericoCodigoIdentificacao _modelo = new NumericoCodigoIdentificacao("Modelo", 2);
        private readonly Alpha _serie = new Alpha("Serie", 3);
        private readonly NumericoCodigoIdentificacao _numero = new NumericoCodigoIdentificacao("Numero", 9);
        private readonly Alpha _codigoAutenticacao = new Alpha("CodigoAutent Digital doc fiscal", 32, isMandatory:true);
        private readonly Numerico _valorTotal = new Numerico("Valor Total", 12, scale: 2);
        private readonly Numerico _baseIcms = new Numerico("baseIcms", 12, scale: 2);
        private readonly Numerico _valorIcms = new Numerico("valorIcms", 12, scale: 2);
        private readonly Numerico _valorIsentos = new Numerico("_valorIsentos", 12, scale: 2);
        private readonly Numerico _valorOutros = new Numerico("_valorOutros", 12, scale: 2);
        private readonly Alpha _situacao = new Alpha("situacao", 1);
        private readonly NumericoDataAnoMes _anoMes = new NumericoDataAnoMes("AnoMesReferencia");
        private readonly NumericoCodigoIdentificacao _referenciaItemNf = new NumericoCodigoIdentificacao("Referencia Item Nf", 9);
        private readonly Alpha _numeroTerminalTel = new Alpha("Numero Terminal Tel", 12);
        private readonly Alpha _brancos = new Alpha("Brancos", 5);
        private readonly Alpha _codigoAutDigital = new Alpha("Cod. Autenticacao Digital", 32, isMandatory: true);

        private readonly IStoreModel22 _parametro;
        private StringBuilder _conteudo;

        public RegistroMestre(IStoreModel22 parametro)
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
            AddField(_uf);
            AddField(_classeConsumoTipoAssinante);
            AddField(_faseTipoUtil);
            AddField(_grupoTensao);
            AddField(_codigoIdentConsumidor);
            AddField(_dataEmissao);
            AddField(_modelo);
            AddField(_serie);
            AddField(_numero);
            AddField(_codigoAutenticacao);
            AddField(_valorTotal);
            AddField(_baseIcms);
            AddField(_valorIcms);
            AddField(_valorIsentos);
            AddField(_valorOutros);
            AddField(_situacao);
            AddField(_anoMes);
            AddField(_referenciaItemNf);
            AddField(_numeroTerminalTel);
            AddField(_brancos);
            AddField(_codigoAutDigital);
        }

        public override void Append(StringBuilder stringBuilder)
        {
            var index = 1;

            var movimentos = _parametro
                            .Movimentos
                            .GroupBy(m => new
                            {
                                m.ClienteCpfCnpj,
                                m.ClienteIe,
                                m.ClienteRazaoSocial,
                                m.ClienteUf,
                                m.ClienteCodigo,
                                m.DataEmissao,
                                m.Modelo,
                                m.Serie,
                                m.NumeroNf,
                                m.Situacao,
                                m.CodigoAutenticacaoDocumento,
                                m.ClasseConsumoTipoAssinante,
                                m.FaseTipoUtilizacao,
                                m.GrupoTensao
                            });

            foreach (var movimento in movimentos)
            {
                SetValue(_cnpjCpf, movimento.Key.ClienteCpfCnpj);
                SetValue(_ie, movimento.Key.ClienteIe);
                SetValue(_razaoSocial, movimento.Key.ClienteRazaoSocial.NoAccents());
                SetValue(_uf, movimento.Key.ClienteUf);
                SetValue(_classeConsumoTipoAssinante, movimento.Key.ClasseConsumoTipoAssinante);
                SetValue(_faseTipoUtil, movimento.Key.FaseTipoUtilizacao);
                SetValue(_grupoTensao, movimento.Key.GrupoTensao);
                SetValue(_codigoIdentConsumidor, movimento.Key.ClienteCodigo);
                SetValue(_dataEmissao, movimento.Key.DataEmissao);
                SetValue(_modelo, movimento.Key.Modelo);
                SetValue(_serie, movimento.Key.Serie);
                SetValue(_numero, movimento.Key.NumeroNf);
                //SetValue(_codigoAutenticacao, movimento.Key.CodigoAutenticacaoDocumento.ToUpper());
                var movimentoNf = _parametro.Movimentos.Where(m => m.NumeroNf == movimento.Key.NumeroNf).ToList();
                SetValue(_codigoAutenticacao, GetCodigoAutenticacaoDocumento(movimentoNf));
                SetValue(_valorTotal, movimento.Sum(v => v.ValorTotal));
                SetValue(_baseIcms, movimento.Sum(v => v.ValorBaseIcms));
                SetValue(_valorIcms, movimento.Sum(v => v.ValorIcms));
                SetValue(_valorIsentos, movimento.Sum(v => v.ValorIcmsIsento));
                SetValue(_valorOutros, movimento.Sum(v => v.ValorIcmsOutros));
                SetValue(_situacao, movimento.Key.Situacao);
                SetValue(_anoMes, movimento.Key.DataEmissao);
                SetValue(_referenciaItemNf, index);
                index++;
                SetValue(_numeroTerminalTel, string.Empty);

                SetValue(_brancos, string.Empty);

                UtilXpo.WriteLog("Mestre");
                UtilXpo.WriteLog(_conteudo.ToString());

                _codigoAutDigital.Value = HashCode.GetMd5Hash(_conteudo.ToString()).ToUpper();
                AppendLine(stringBuilder);
                _conteudo = new StringBuilder();
            }

        }

        private string GetCodigoAutenticacaoDocumento(List<MovimentoModel22> pMovimentoNfList)
        {
            var text = new StringBuilder();

            text.Append(_cnpjCpf);
            text.Append(_numero);

            _valorTotal.Value = pMovimentoNfList.Sum(v => v.ValorTotal);
            text.Append(_valorTotal);

            _baseIcms.Value = pMovimentoNfList.Sum(v => v.ValorBaseIcms);
            text.Append(_baseIcms);

            _valorIcms.Value = pMovimentoNfList.Sum(v => v.ValorIcms);
            text.Append(_valorIcms);

            var hashCodeDoc = HashCode.GetMd5Hash(text.ToString()).ToUpper();

            UtilXpo.WriteLog("Codigo hash: NF " + _numero.Value);
            UtilXpo.WriteLog(text.ToString());
            UtilXpo.WriteLog(hashCodeDoc);

            return hashCodeDoc;
        }

        private void SetValue(ICampo pObject, object pValue)
        {
            pObject.Value = pValue;
            _conteudo.Append(pObject);
        }
    }
}
