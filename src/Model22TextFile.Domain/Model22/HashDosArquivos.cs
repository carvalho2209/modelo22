using System;
using System.Globalization;
using Model22TextFile.Infra;

namespace Model22TextFile.Domain.Model22
{
    public class HashDosArquivos : IHashDosArquivos
    {
        public void SalvarHash(HistoricoModelo22E21 historico)
        {
            var codigoDaFilial = historico.CodigoDaFilial;

            var queryFilial =
                @"SELECT ORG_TAB_IN_CODIGO, ORG_PAD_IN_CODIGO, ORG_IN_CODIGO, PAI_ORG_IN_CODIGO FROM MGGLO.GLO_VW_ORGANIZACAO WHERE ORG_IN_CODIGO = " + codigoDaFilial;

            var filial = UtilXpo.ExecutaSelect(queryFilial);

            if (filial.Rows.Count == 0 || filial.Rows.Count > 1)
                throw new Exception(
                    string.Format(
                    "Não foi encontrado organização maior com o código [{0}]", codigoDaFilial));

            var linhaDaFilial = filial.Rows[0];

            var queryDeInsertDoHistorico =
            string.Format(CultureInfo.InvariantCulture,
                @"INSERT INTO MGCUSTOM.MG_HISTNFMODELO21 (
                    ORG_TAB_IN_CODIGO,
                    ORG_PAD_IN_CODIGO,
                    ORG_IN_CODIGO,
                    FIL_IN_CODIGO,
                    REC_DT_RECIBO,
                    REC_ST_NOMEARQMESTRE,
                    REC_ST_HASHARQMESTRE ,
                    rec_st_nomearqitem  ,
                    rec_st_hasharqitem  ,
                    rec_st_nomearqdest  ,
                    rec_st_hasharqdest  ,
                    rec_in_qtderegistro ,
                    rec_re_vlrtotal     ,
                    rec_re_vlrdesc      ,
                    rec_re_vlracres     ,
                    rec_re_vlrbaseicms  ,
                    rec_re_vlricms      ,
                    rec_re_vlrisentas   ,
                    rec_re_vlroutros    ,
                    rec_dt_referenciaini,
                    rec_dt_referenciafin
                )
                VALUES 
                    ({0},
                     {1},
                     {2},
                     {3},
                     SYSDATE,
                     '{4}',
                     '{5}',
                     '{6}',
                     '{7}',
                     '{8}',
                     '{9}',
                      {10},
                      {11},
                      {12},
                      {13},
                      {14},
                      {15},
                      {16},
                      {17},
                     TO_DATE('{18:dd/MM/yyyy}{20:hh:mm:ss}',  'DD/MM/YYYYHH24:MI:SS'),
                     TO_DATE('{19:dd/MM/yyyy}{20:hh:mm:ss}',  'DD/MM/YYYYHH24:MI:SS')
             )",
                linhaDaFilial["ORG_TAB_IN_CODIGO"],
                linhaDaFilial["ORG_PAD_IN_CODIGO"],
                linhaDaFilial["PAI_ORG_IN_CODIGO"],
                codigoDaFilial,
                historico.NomeDoArquioMestre,
                historico.HashDoArquivoMestere,
                historico.NomeDoArquivoItem,
                historico.HashDoArquivoItem,
                historico.NomeDoArquivoDados,
                historico.HashDoArquivoDados,
                historico.QtdRegistroMestre,
                historico.ValorTotal,
                historico.ValorDesconto,
                historico.ValorAcrescimo,
                historico.ValorBaseIcms,
                historico.ValorIcms,
                historico.ValorBaseIsentas,
                historico.ValorOutros,
                historico.ReferenciaInicial,
                historico.ReferenciaFinal,
                DateTime.Now
            );

            UtilXpo.WriteLog(queryDeInsertDoHistorico);

            UtilXpo.ExecuteNonQuery(queryDeInsertDoHistorico);

        }
    }
}
