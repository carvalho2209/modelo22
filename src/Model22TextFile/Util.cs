using System;
using System.Windows.Forms;

namespace Model22TextFile
{
    public static class Util
    {
        public static void ShowMessageError(string pTexto)
        {
            MessageBox.Show(pTexto, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowMessageError(Exception pException)
        {
            MessageBox.Show(pException.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowMessageInformation(string pTexto)
        {
            MessageBox.Show(pTexto, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowMessageSuccess(string pTexto = "Dados salvos com sucesso.")
        {
            MessageBox.Show(pTexto, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowMessageWarning(string pTexto, string pCaption = "Aviso")
        {
            MessageBox.Show(pTexto, pCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
