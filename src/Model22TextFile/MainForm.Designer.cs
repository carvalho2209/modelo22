namespace Model22TextFile
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCriarArquivos = new DevExpress.XtraEditors.SimpleButton();
            this.btnFechar = new DevExpress.XtraEditors.SimpleButton();
            this.lblFilial = new DevExpress.XtraEditors.LabelControl();
            this.lblDataInicio = new DevExpress.XtraEditors.LabelControl();
            this.lblDataFim = new DevExpress.XtraEditors.LabelControl();
            this.filialNomeEdit = new DevExpress.XtraEditors.TextEdit();
            this.dataInicioEdit = new DevExpress.XtraEditors.DateEdit();
            this.dataFinalEdit = new DevExpress.XtraEditors.DateEdit();
            this.filialCodigoEdit = new DevExpress.XtraEditors.TextEdit();
            this.btnTestarHash = new DevExpress.XtraEditors.SimpleButton();
            this.chkRetificado = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.filialNomeEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataInicioEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataInicioEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataFinalEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataFinalEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filialCodigoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRetificado.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCriarArquivos
            // 
            this.btnCriarArquivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCriarArquivos.Location = new System.Drawing.Point(12, 226);
            this.btnCriarArquivos.Name = "btnCriarArquivos";
            this.btnCriarArquivos.Size = new System.Drawing.Size(103, 23);
            this.btnCriarArquivos.TabIndex = 0;
            this.btnCriarArquivos.Text = "Criar Arquivos";
            this.btnCriarArquivos.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Location = new System.Drawing.Point(369, 226);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(103, 23);
            this.btnFechar.TabIndex = 1;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // lblFilial
            // 
            this.lblFilial.Location = new System.Drawing.Point(12, 13);
            this.lblFilial.Name = "lblFilial";
            this.lblFilial.Size = new System.Drawing.Size(27, 13);
            this.lblFilial.TabIndex = 2;
            this.lblFilial.Text = "Filial: ";
            // 
            // lblDataInicio
            // 
            this.lblDataInicio.Location = new System.Drawing.Point(12, 42);
            this.lblDataInicio.Name = "lblDataInicio";
            this.lblDataInicio.Size = new System.Drawing.Size(57, 13);
            this.lblDataInicio.TabIndex = 3;
            this.lblDataInicio.Text = "Data Inicial:";
            // 
            // lblDataFim
            // 
            this.lblDataFim.Location = new System.Drawing.Point(12, 72);
            this.lblDataFim.Name = "lblDataFim";
            this.lblDataFim.Size = new System.Drawing.Size(52, 13);
            this.lblDataFim.TabIndex = 4;
            this.lblDataFim.Text = "Data Final:";
            // 
            // filialNomeEdit
            // 
            this.filialNomeEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filialNomeEdit.Location = new System.Drawing.Point(208, 10);
            this.filialNomeEdit.Name = "filialNomeEdit";
            this.filialNomeEdit.Size = new System.Drawing.Size(264, 20);
            this.filialNomeEdit.TabIndex = 5;
            // 
            // dataInicioEdit
            // 
            this.dataInicioEdit.EditValue = null;
            this.dataInicioEdit.Location = new System.Drawing.Point(90, 39);
            this.dataInicioEdit.Name = "dataInicioEdit";
            this.dataInicioEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dataInicioEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dataInicioEdit.Size = new System.Drawing.Size(112, 20);
            this.dataInicioEdit.TabIndex = 6;
            // 
            // dataFinalEdit
            // 
            this.dataFinalEdit.EditValue = null;
            this.dataFinalEdit.Location = new System.Drawing.Point(90, 69);
            this.dataFinalEdit.Name = "dataFinalEdit";
            this.dataFinalEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dataFinalEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dataFinalEdit.Size = new System.Drawing.Size(112, 20);
            this.dataFinalEdit.TabIndex = 7;
            // 
            // filialCodigoEdit
            // 
            this.filialCodigoEdit.Location = new System.Drawing.Point(90, 10);
            this.filialCodigoEdit.Name = "filialCodigoEdit";
            this.filialCodigoEdit.Size = new System.Drawing.Size(112, 20);
            this.filialCodigoEdit.TabIndex = 8;
            // 
            // btnTestarHash
            // 
            this.btnTestarHash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTestarHash.Location = new System.Drawing.Point(260, 226);
            this.btnTestarHash.Name = "btnTestarHash";
            this.btnTestarHash.Size = new System.Drawing.Size(103, 23);
            this.btnTestarHash.TabIndex = 9;
            this.btnTestarHash.Text = "Testar Hash";
            this.btnTestarHash.Click += new System.EventHandler(this.btnTestarHash_Click);
            // 
            // chkRetificado
            // 
            this.chkRetificado.Location = new System.Drawing.Point(10, 104);
            this.chkRetificado.Name = "chkRetificado";
            this.chkRetificado.Properties.Caption = "Retificação ?";
            this.chkRetificado.Size = new System.Drawing.Size(192, 19);
            this.chkRetificado.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.chkRetificado);
            this.Controls.Add(this.btnTestarHash);
            this.Controls.Add(this.filialCodigoEdit);
            this.Controls.Add(this.dataFinalEdit);
            this.Controls.Add(this.dataInicioEdit);
            this.Controls.Add(this.filialNomeEdit);
            this.Controls.Add(this.lblDataFim);
            this.Controls.Add(this.lblDataInicio);
            this.Controls.Add(this.lblFilial);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnCriarArquivos);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magnético Modelo 22";
            ((System.ComponentModel.ISupportInitialize)(this.filialNomeEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataInicioEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataInicioEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataFinalEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataFinalEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filialCodigoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRetificado.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCriarArquivos;
        private DevExpress.XtraEditors.SimpleButton btnFechar;
        private DevExpress.XtraEditors.LabelControl lblFilial;
        private DevExpress.XtraEditors.LabelControl lblDataInicio;
        private DevExpress.XtraEditors.LabelControl lblDataFim;
        private DevExpress.XtraEditors.TextEdit filialNomeEdit;
        private DevExpress.XtraEditors.DateEdit dataInicioEdit;
        private DevExpress.XtraEditors.DateEdit dataFinalEdit;
        private DevExpress.XtraEditors.TextEdit filialCodigoEdit;
        private DevExpress.XtraEditors.SimpleButton btnTestarHash;
        private DevExpress.XtraEditors.CheckEdit chkRetificado;
    }
}