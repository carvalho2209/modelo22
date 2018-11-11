using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model22TextFile.Domain;

namespace Model22TextFile
{
    public partial class FrmTestaHash : Form
    {
        public FrmTestaHash()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {
            txtCodigoHash.Text = HashCode.GetMd5Hash(txtString.Text);

            if (chkUpper.Checked)
                txtCodigoHash.Text = txtCodigoHash.Text.ToUpper();
        }

        private void btnCopiarAreaTransferencia_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCodigoHash.Text);
        }
    }
}
