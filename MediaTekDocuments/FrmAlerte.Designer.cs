namespace MediaTekDocuments.view
{
    partial class FrmAlerte
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAlerteAbonnements = new System.Windows.Forms.DataGridView();
            this.btnAlerteOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlerteAbonnements)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Les abonnements suivants expirent dans moins de 30 jours :";
            // 
            // dgvAlerteAbonnements
            // 
            this.dgvAlerteAbonnements.AllowUserToAddRows = false;
            this.dgvAlerteAbonnements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlerteAbonnements.Location = new System.Drawing.Point(15, 39);
            this.dgvAlerteAbonnements.Name = "dgvAlerteAbonnements";
            this.dgvAlerteAbonnements.RowHeadersWidth = 51;
            this.dgvAlerteAbonnements.RowTemplate.Height = 24;
            this.dgvAlerteAbonnements.Size = new System.Drawing.Size(359, 169);
            this.dgvAlerteAbonnements.TabIndex = 1;
            // 
            // btnAlerteOK
            // 
            this.btnAlerteOK.Location = new System.Drawing.Point(155, 222);
            this.btnAlerteOK.Name = "btnAlerteOK";
            this.btnAlerteOK.Size = new System.Drawing.Size(85, 28);
            this.btnAlerteOK.TabIndex = 2;
            this.btnAlerteOK.Text = "OK";
            this.btnAlerteOK.UseVisualStyleBackColor = true;
            this.btnAlerteOK.Click += new System.EventHandler(this.BtnAlerteOK_Click);
            // 
            // FrmAlerte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 262);
            this.Controls.Add(this.btnAlerteOK);
            this.Controls.Add(this.dgvAlerteAbonnements);
            this.Controls.Add(this.label1);
            this.Name = "FrmAlerte";
            this.Text = "FrmAlerte";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlerteAbonnements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAlerteAbonnements;
        private System.Windows.Forms.Button btnAlerteOK;
    }
}