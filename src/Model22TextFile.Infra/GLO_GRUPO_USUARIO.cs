using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpo;

namespace Model22TextFile.Infra
{
    [Persistent("MGGLO.GLO_GRUPO_USUARIO")]
    public class GLO_GRUPO_USUARIO
    {
        [Key]
        public int GRU_IN_CODIGO { get; set; }
        public string GRU_ST_NOME { get; set; }
        public string GRU_ST_NOMECOMPLETO { get; set; }
        public string GRU_ST_SENHA { get; set; }
        public string GRU_CH_STATUS { get; set; }

        //public List<USUARIO_ACESSO> ACESSO { get; set; }

        public GLO_GRUPO_USUARIO ObterPor(int valorChave)
        {
            var list = new XPQuery<GLO_GRUPO_USUARIO>(Session.DefaultSession).Where(c => c.GRU_IN_CODIGO == valorChave);

            return list.FirstOrDefault();
        }

        //public void PreencherAcessoDoUsuario()
        //{
        //    ACESSO = new XPQuery<USUARIO_ACESSO>(Session.DefaultSession).Where(c => c.USUARIO_ID == GRU_IN_CODIGO).ToList();

        //    foreach (var item in new XPQuery<MODULO_ACESSO>(Session.DefaultSession))
        //    {
        //        if (!ACESSO.Exists(c => c.MODULO_ACESSO_ID == item.ID))
        //            ACESSO.Add(new USUARIO_ACESSO() { USUARIO_ID = this.GRU_IN_CODIGO, MODULO_ACESSO_ID = item.ID, MODULO_ACESSO_DESCRICAO = item.DESCRICAO, MODULO_ACESSO_CODIGO = item.CODIGO, MODULO_ACESSO_CATEGORIA = item.CATEGORIA });
        //    }

        //    ACESSO.ForEach(c => c.Save());
        //}
    }
}
