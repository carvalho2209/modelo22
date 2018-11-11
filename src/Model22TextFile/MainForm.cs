using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model22TextFile.Domain.Model22;
using Model22TextFile.Infra;

namespace Model22TextFile
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetDate();
            UpdateFilial();

            Text = string.Format("{0} - Versão : {1}", Text, GetVersion());
        }

        public string GetVersion()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi.FileVersion;
        }


        private void UpdateFilial()
        {
            filialCodigoEdit.Properties.ReadOnly = true;
            filialNomeEdit.Properties.ReadOnly = true;

            if (Login.FILIALCONECTADA == null)
                return;

            filialCodigoEdit.EditValue = Login.FILIALCONECTADA.FIL_IN_CODIGO;
            filialNomeEdit.EditValue = Login.FILIALCONECTADA.ORG_ST_FANTASIA;
        }

        private void SetDate()
        {
            var dataInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var dataFim = dataInicio.AddMonths(1).AddDays(-1);

            dataInicioEdit.DateTime = dataInicio;
            dataFinalEdit.DateTime = dataFim;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Execute();

                Cursor.Current = Cursors.Default;

                Util.ShowMessageSuccess("Arquivos gerados com sucesso.");
            }
            catch (Exception ex)
            {
                Util.ShowMessageError(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void Execute()
        {
            var pathForFile = GetPathOrException();
            var parametro = GetParametro();
            parametro.LoadMoviment();

            UtilXpo.WriteLog("Antes var arquivoModelo22 = new ArquivoModel22(parametro, pathForFile);");
            var arquivoModelo22 = new ArquivoModel22(parametro, pathForFile);
            UtilXpo.WriteLog("Antes arquivoModelo22.CreateFiles();");
            arquivoModelo22.CreateFiles();
        }

        private StoreModel22 GetParametro()
        {
            var parametro = new StoreModel22();

            parametro.DataInicio = dataInicioEdit.DateTime;
            parametro.DataFim = dataFinalEdit.DateTime;
            parametro.EstabelecimentoId = GetEstabelecimentoId();
            parametro.Retificacao = chkRetificado.Checked;

            return parametro;
        }

        private int GetEstabelecimentoId()
        {
            if (filialCodigoEdit.EditValue == null)
                throw new Exception("Filial não selecionada.");

            int estabelecimentoId;
            if (int.TryParse(filialCodigoEdit.Text, out estabelecimentoId))
                return estabelecimentoId;

            throw new Exception("Filial não selecionada.");
        }

        private string GetPathOrException()
        {
            var folderBrowser = new FolderBrowserDialog();

            folderBrowser.Description = "Caminho do Arquivo";

            if (folderBrowser.ShowDialog(this) == DialogResult.OK)
                return folderBrowser.SelectedPath;

            return string.Empty;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTestarHash_Click(object sender, EventArgs e)
        {
            new FrmTestaHash().Show();
        }
    }
}
