namespace Chantiers_Laurent
{
    partial class Principal
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnTraitement = new System.Windows.Forms.Button();
            this.btnFichierExcelDépart = new System.Windows.Forms.Button();
            this.lblCheminFichierModèle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1310, 466);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnTraitement
            // 
            this.btnTraitement.Location = new System.Drawing.Point(898, 13);
            this.btnTraitement.Name = "btnTraitement";
            this.btnTraitement.Size = new System.Drawing.Size(75, 23);
            this.btnTraitement.TabIndex = 2;
            this.btnTraitement.Text = "Traitement";
            this.btnTraitement.UseVisualStyleBackColor = true;
            this.btnTraitement.Click += new System.EventHandler(this.BtnTraitementFichierExcel);
            // 
            // btnFichierExcelDépart
            // 
            this.btnFichierExcelDépart.Location = new System.Drawing.Point(31, 13);
            this.btnFichierExcelDépart.Name = "btnFichierExcelDépart";
            this.btnFichierExcelDépart.Size = new System.Drawing.Size(87, 23);
            this.btnFichierExcelDépart.TabIndex = 3;
            this.btnFichierExcelDépart.Text = "Fichier excel...";
            this.btnFichierExcelDépart.UseVisualStyleBackColor = true;
            this.btnFichierExcelDépart.Click += new System.EventHandler(this.BtnFicherExcelDépart);
            // 
            // lblCheminFichierModèle
            // 
            this.lblCheminFichierModèle.AutoSize = true;
            this.lblCheminFichierModèle.Location = new System.Drawing.Point(124, 18);
            this.lblCheminFichierModèle.Name = "lblCheminFichierModèle";
            this.lblCheminFichierModèle.Size = new System.Drawing.Size(35, 13);
            this.lblCheminFichierModèle.TabIndex = 4;
            this.lblCheminFichierModèle.Text = "label1";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 601);
            this.Controls.Add(this.lblCheminFichierModèle);
            this.Controls.Add(this.btnFichierExcelDépart);
            this.Controls.Add(this.btnTraitement);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Principal";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnTraitement;
        private System.Windows.Forms.Button btnFichierExcelDépart;
        private System.Windows.Forms.Label lblCheminFichierModèle;
    }
}

