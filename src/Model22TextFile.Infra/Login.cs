using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model22TextFile.Infra
{
    public class Login
    {
        static int _usuarioId;
        public static int USUARIO_ID
        {
            get
            { return _usuarioId; }
            set
            {
                _usuarioId = value;
                SetNomeUsuario();
            }
        }

        private static void SetNomeUsuario()
        {
            var usuario = new GLO_GRUPO_USUARIO().ObterPor(Login.USUARIO_ID);
            if (usuario != null)
                USUARIO_NOME = usuario.GRU_ST_NOME;
        }
        public static string USUARIO_NOME { get; set; }
        public static bool CONECTADO { get; set; }
        public static FILIAL FILIALCONECTADA { get; set; }
    }
}
