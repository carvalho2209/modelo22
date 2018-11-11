using System;
using DevExpress.Xpo;

namespace Model22TextFile.Infra
{
    [Persistent("VW_NOTAMODEL22")]
    public class ViewMegaNotaModel22
    {
        [Key]
        public int ID { get; set; }
        public int NOT_IN_NUMERO { get; set; }
        public int NOT_IN_CODIGO { get; set; }
        public DateTime NOT_DT_EMISSAO { get; set; }
        public int AGN_IN_CODIGO { get; set; }
        public string AGN_ST_NOME { get; set; }
        public string CFOP_ST_EXTENSO { get; set; }
        public string CFOP_ST_FANTASIA { get; set; }
        public string ORG_NOME { get; set; }
        public string ORG_LOGRADOURO { get; set; }
        public string ORG_BAIRRO { get; set; }
        public string ORG_MUNICIPIO { get; set; }
        public string ORG_CEP { get; set; }
        public string ORG_UF { get; set; }
        public string ORG_PA { get; set; }
        public string ORG_IE { get; set; }
        public string CLI_LOGRADOURO { get; set; }
        public string CLI_BAIRRO { get; set; }
        public string CLI_MUNICIPIO { get; set; }
        public string CLI_CEP { get; set; }
        public string CLI_UF { get; set; }
        public string CLI_PA { get; set; }
        public string CLI_IE { get; set; }
        public string CLI_NUMERO { get; set; }
        public decimal NOT_RE_BASEICMS { get; set; }
        public decimal NOT_RE_VALORICMS { get; set; }
        public decimal NOT_RE_VALORTOTAL { get; set; }
        public string ORG_CNPJ { get; set; }
        public string AGN_ST_INSCRESTADUAL { get; set; }
        public string CPF_CNPJ { get; set; }
        //public string PRO_IN_CODIGO { get; set; }
        public int PRO_IN_CODIGO { get; set; }
        public string ITN_ST_DESCRICAO { get; set; }
        public decimal ITN_RE_ALIQICMS { get; set; }
        public decimal ITN_RE_VALORMERCADORIA { get; set; }
        //[Persistent]
        //[NullValue(true)]
        //public DateTime VENCIMENTO { get; set; }
        public string ORG_TEL { get; set; }
        public string HASHCODE  { get; set; }
        public int FIL_IN_CODIGO { get; set; }
        public string RESPONSAVEL_NOME { get; set; }
        public string RESPONSAVEL_CARGO { get; set; }
        public string RESPONSAVEL_TELEFONE { get; set; }
        public string RESPONSAVEL_EMAIL { get; set; }

        public int CLASSE_CONSUMO { get; set; }

        public int FASE_TIPO_UTILIZACAO { get; set; }

        public int GRUPO_TENSAO { get; set; }

        public string SER_ST_CODIGO { get; set; }

        public int CODIGO_CLASSIFICACAO_ITEM { get; set; }

        public string SITUACAO { get; set; }

        public string MODELO { get; set; }

    }
}
