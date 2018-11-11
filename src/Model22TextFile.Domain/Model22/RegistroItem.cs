using System;
using System.Text;
using System.Linq;
using Model22TextFile.Domain.Extensions;
using Model22TextFile.Domain.File;
using Model22TextFile.Infra;

namespace Model22TextFile.Domain.Model22
{
    public class RegistroItem : Registro
    {
        private readonly NumericoCodigoIdentificacao _cnpjCpf = new NumericoCodigoIdentificacao("CNPJ", 14);
        private readonly Alpha _uf = new Alpha("UF", 2, isMandatory: true);
        private readonly NumericoCodigoIdentificacao _classeConsumoTipoAssinante = new NumericoCodigoIdentificacao("ClasseConsumoTipoAssinante", 1);
        private readonly NumericoCodigoIdentificacao _faseTipoUtil = new NumericoCodigoIdentificacao("FaseTipoUtil", 1);
        private readonly NumericoCodigoIdentificacao _grupoTensao = new NumericoCodigoIdentificacao("_grupoTensao", 2);
        private readonly NumericoData _dataEmissao = new NumericoData("dataEmissao");
        private readonly NumericoCodigoIdentificacao _modelo = new NumericoCodigoIdentificacao("Modelo", 2);
        private readonly Alpha _serie = new Alpha("Serie", 3);
        private readonly NumericoCodigoIdentificacao _numero = new NumericoCodigoIdentificacao("Numero", 9);
        private readonly NumericoCodigoIdentificacao _cfop = new NumericoCodigoIdentificacao("CFOP", 4);
        private readonly NumericoCodigoIdentificacao _item = new NumericoCodigoIdentificacao("Item", 3);
        private readonly Alpha _codigoServicoFornec = new Alpha("Codigo Servico Fornecimento", 10);
        private readonly Alpha _descricaoServicoFornec = new Alpha("Descricao Servico Fornecimento", 40);
        private readonly NumericoCodigoIdentificacao _codClassItem = new NumericoCodigoIdentificacao("Cod. Class. Item", 4);
        private readonly Alpha _unidade = new Alpha("Unidade", 6);
        private readonly Numerico _qtdadeContratada = new Numerico("Qtdade Contratada", 11, scale: 3);
        private readonly Numerico _qtdadePrestada = new Numerico("Qtdade Prestada", 11, scale: 3);
        private readonly Numerico _valorTotal = new Numerico("Valor Total", 11, scale: 2);
        private readonly Numerico _valorDesconto = new Numerico("Valor Desconto", 11, scale: 2);
        private readonly Numerico _valorAcrescimo = new Numerico("Valor Acrescimo", 11, scale: 2);
        private readonly Numerico _baseIcms = new Numerico("base icms", 11, scale: 2);
        private readonly Numerico _valorIcms = new Numerico("Valor icms", 11, scale: 2);
        private readonly Numerico _valorIsentos = new Numerico("Valor Isentos", 11, scale: 2);
        private readonly Numerico _valorOutros = new Numerico("Valor Outros", 11, scale: 2);
        private readonly Numerico _aliqIcms = new Numerico("Aliq Icms", 4, scale: 2);
        private readonly Alpha _situacao = new Alpha("situacao", 1);
        private readonly NumericoDataAnoMes _anoMes = new NumericoDataAnoMes("AnoMesReferencia");
        private readonly Alpha _brancos = new Alpha("Brancos", 5);
        private readonly Alpha _codigoAutDigital = new Alpha("Cod. Autenticacao Digital", 32, isMandatory: true);

        private readonly IStoreModel22 _parametro;
        private StringBuilder _conteudo;

        public RegistroItem(IStoreModel22 parametro)
        {
            _parametro = parametro;
            AddFields();

            _conteudo = new StringBuilder();
        }

        private void AddFields()
        {
            AddField(_cnpjCpf);
            AddField(_uf);
            AddField(_classeConsumoTipoAssinante);
            AddField(_faseTipoUtil);
            AddField(_grupoTensao);
            AddField(_dataEmissao);
            AddField(_modelo);
            AddField(_serie);
            AddField(_numero);
            AddField(_cfop);
            AddField(_item);
            AddField(_codigoServicoFornec);
            AddField(_descricaoServicoFornec);
            AddField(_codClassItem);
            AddField(_unidade);
            AddField(_qtdadeContratada);
            AddField(_qtdadePrestada);
            AddField(_valorTotal);
            AddField(_valorDesconto);
            AddField(_valorAcrescimo);
            AddField(_baseIcms);
            AddField(_valorIcms);
            AddField(_valorIsentos);
            AddField(_valorOutros);
            AddField(_aliqIcms);
            AddField(_situacao);
            AddField(_anoMes);
            AddField(_brancos);
            AddField(_codigoAutDigital);
        }

        public override void Append(StringBuilder stringBuilder)
        {
            var movimentos = _parametro
                            .Movimentos
                            .GroupBy(m => new
                            {
                                m.ClienteCpfCnpj,
                                m.ClienteUf,
                                m.DataEmissao,
                                m.ClienteCodigo,
                                m.Modelo,
                                m.Serie,
                                m.NumeroNf,
                                m.Situacao,
                                m.Cfop,
                                m.Item,
                                m.Unidade,
                                m.ClasseConsumoTipoAssinante,
                                m.FaseTipoUtilizacao,
                                m.GrupoTensao,
                                m.CodigoServicoFornecimento,
                                m.DescricaoServicoFornecimento,
                                m.CodigoClasseItem
                            });

            foreach (var movimento in movimentos)
            {
                SetValue(_cnpjCpf, movimento.Key.ClienteCpfCnpj);
                SetValue(_uf, movimento.Key.ClienteUf);
                SetValue(_classeConsumoTipoAssinante, movimento.Key.ClasseConsumoTipoAssinante);
                SetValue(_faseTipoUtil, movimento.Key.FaseTipoUtilizacao);
                SetValue(_grupoTensao, movimento.Key.GrupoTensao);
                SetValue(_dataEmissao, movimento.Key.DataEmissao);
                SetValue(_modelo, movimento.Key.Modelo);
                SetValue(_serie, movimento.Key.Serie);
                SetValue(_numero, movimento.Key.NumeroNf);
                SetValue(_cfop, movimento.Key.Cfop);
                SetValue(_item, movimento.Key.Item);
                SetValue(_codigoServicoFornec, movimento.Key.CodigoServicoFornecimento);
                SetValue(_descricaoServicoFornec, movimento.Key.DescricaoServicoFornecimento);
                SetValue(_codClassItem, movimento.Key.CodigoClasseItem);
                SetValue(_unidade, movimento.Key.Unidade);
                SetValue(_qtdadeContratada, movimento.Sum(v => v.QtdadeContratada));
                SetValue(_qtdadePrestada, movimento.Sum(v => v.QtdadePrestada));
                SetValue(_valorTotal, movimento.Sum(v => v.ValorTotal));
                SetValue(_valorDesconto, movimento.Sum(v => v.ValorDesconto));
                SetValue(_valorAcrescimo, movimento.Sum(v => v.ValorAcrescimo));
                SetValue(_baseIcms, movimento.Sum(v => v.ValorBaseIcms));
                SetValue(_valorIcms, movimento.Sum(v => v.ValorIcms));
                SetValue(_valorIsentos, movimento.Sum(v => v.ValorIcmsIsento));
                SetValue(_valorOutros, movimento.Sum(v => v.ValorIcmsOutros));
                SetValue(_aliqIcms, movimento.Max(v => v.AliqIcms));
                SetValue(_situacao, movimento.Key.Situacao);
                SetValue(_anoMes, movimento.Key.DataEmissao);

                SetValue(_brancos, string.Empty);

                UtilXpo.WriteLog("Item");
                UtilXpo.WriteLog(_conteudo.ToString());

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
