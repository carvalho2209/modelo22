namespace Model22TextFile
{
    partial class FrmTestaHash
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtString = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigoHash = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnConverter = new DevExpress.XtraEditors.SimpleButton();
            this.chkUpper = new DevExpress.XtraEditors.CheckEdit();
            this.btnCopiarAreaTransferencia = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtString.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoHash.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUpper.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(103, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Texto para converter";
            // 
            // txtString
            // 
            this.txtString.Location = new System.Drawing.Point(13, 32);
            this.txtString.Name = "txtString";
            this.txtString.Size = new System.Drawing.Size(634, 96);
            this.txtString.TabIndex = 2;
            this.txtString.UseOptimizedRendering = true;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 184);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Código Hash";
            // 
            // txtCodigoHash
            // 
            this.txtCodigoHash.Location = new System.Drawing.Point(12, 203);
            this.txtCodigoHash.Name = "txtCodigoHash";
            this.txtCodigoHash.Size = new System.Drawing.Size(631, 20);
            this.txtCodigoHash.TabIndex = 4;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(568, 344);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "Fechar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnConverter
            // 
            this.btnConverter.Location = new System.Drawing.Point(13, 134);
            this.btnConverter.Name = "btnConverter";
            this.btnConverter.Size = new System.Drawing.Size(75, 23);
            this.btnConverter.TabIndex = 6;
            this.btnConverter.Text = "Converter";
            this.btnConverter.Click += new System.EventHandler(this.btnConverter_Click);
            // 
            // chkUpper
            // 
            this.chkUpper.EditValue = true;
            this.chkUpper.Location = new System.Drawing.Point(120, 137);
            this.chkUpper.Name = "chkUpper";
            this.chkUpper.Properties.Caption = "Maiusculo ?";
            this.chkUpper.Size = new System.Drawing.Size(75, 19);
            this.chkUpper.TabIndex = 7;
            // 
            // btnCopiarAreaTransferencia
            // 
            this.btnCopiarAreaTransferencia.Location = new System.Drawing.Point(13, 229);
            this.btnCopiarAreaTransferencia.Name = "btnCopiarAreaTransferencia";
            this.btnCopiarAreaTransferencia.Size = new System.Drawing.Size(75, 23);
            this.btnCopiarAreaTransferencia.TabIndex = 8;
            this.btnCopiarAreaTransferencia.Text = "Copiar";
            this.btnCopiarAreaTransferencia.Click += new System.EventHandler(this.btnCopiarAreaTransferencia_Click);
            // 
            // FrmTestaHash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 379);
            this.Controls.Add(this.btnCopiarAreaTransferencia);
            this.Controls.Add(this.chkUpper);
            this.Controls.Add(this.btnConverter);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtCodigoHash);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtString);
            this.Controls.Add(this.labelControl1);
            this.Name = "FrmTestaHash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Testa Hash Code";
            ((System.ComponentModel.ISupportInitialize)(this.txtString.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoHash.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUpper.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txtString;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtCodigoHash;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnConverter;
        private DevExpress.XtraEditors.CheckEdit chkUpper;
        private DevExpress.XtraEditors.SimpleButton btnCopiarAreaTransferencia;
    }
}