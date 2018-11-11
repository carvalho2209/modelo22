using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DevExpress.Xpo;

namespace Model22TextFile.Infra
{
    public class FILIAL
    {
        public int FIL_IN_CODIGO { get; set; }
        public string ORG_ST_FANTASIA { get; set; }

        public FILIAL GetFilialConectada(int usuario, string computador)
        {
#if DEBUG
            computador = "VMMEGA";
#endif

            var query = @"
                Select 
                   fa.comp_st_nome,
                   fa.usu_in_codigo,
                   o.ORG_ST_FANTASIA,
                   fa.fil_in_codigo
                From  
                       mgglo.glo_filial_ativa fa,
                       mgglo.glo_vw_organizacao o
                Where 
                        o.org_in_codigo      = fa.fil_in_codigo
                    and fa.USU_IN_CODIGO = " + usuario + @"
                    and fa.COMP_ST_NOME = '" + computador + "'";

            var text = string.Format("usuario = {0} - comp = {1}", usuario, computador);

            var dataTable = UtilXpo.ExecutaSelect(query);

            if (dataTable.Rows.Count == 0)
                //throw new Exception("Não foi possível detectar a filial ativa");
                throw new Exception("Não foi possível detectar a filial ativa. Usuario = " + usuario.ToString() + "comp = " + computador);

            var row = dataTable.Rows[0];
            
            var filial = new FILIAL();
            filial.FIL_IN_CODIGO = (int)row.Field<decimal>("FIL_IN_CODIGO");
            filial.ORG_ST_FANTASIA = row.Field<string>("ORG_ST_FANTASIA");

            return filial;
        }
    }
}
