using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Model22TextFile.Infra;

namespace Model22TextFile
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                var config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal);
                var sqlConn = config.ConnectionStrings.ConnectionStrings["Model22"].ConnectionString;

                XpoDefault.DataLayer = XpoDefault.GetDataLayer(sqlConn, AutoCreateOption.None);

                if (XpoDefault.DataLayer != null)
                {
                    XpoDefault.Session.ExecuteNonQuery(@" ALTER SESSION SET NLS_LANGUAGE= 'AMERICAN' NLS_TERRITORY= 'AMERICA' NLS_ISO_CURRENCY= 'AMERICA' NLS_DATE_FORMAT= 'DD/MM/RRRR' NLS_DATE_LANGUAGE= 'AMERICAN' NLS_SORT= 'BINARY' ");

                    Login.USUARIO_ID = ObterUsuario(args);
                    Login.FILIALCONECTADA = new FILIAL().GetFilialConectada(Login.USUARIO_ID, Environment.MachineName);
                    Login.CONECTADO = true;
                }

                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                Util.ShowMessageError(ex);
            }
        }

        static int ObterUsuario(params string[] args)
        {
            var usuarioId = 0;

            foreach (var arg in args){
                var usuarioArgs = arg.Replace("/USUARIO=", string.Empty);

                if (Int32.TryParse(usuarioArgs, out usuarioId))
                    usuarioId = Convert.ToInt32(usuarioId);
            }

#if DEBUG
            return 1;
#endif
            return usuarioId;
        }
    }
}
