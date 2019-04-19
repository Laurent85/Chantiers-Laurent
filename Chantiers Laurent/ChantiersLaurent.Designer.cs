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
            this.bgwExcelFinal = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgression = new System.Windows.Forms.Label();
            this.txbRecherche = new System.Windows.Forms.TextBox();
            this.btnEnregistrerFichier = new System.Windows.Forms.Button();
            this.cbxRaisonSociale = new System.Windows.Forms.ComboBox();
            this.bgwExcelBase = new System.ComponentModel.BackgroundWorker();
            this.lblAttente = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 185);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1310, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnTraitement
            // 
            this.btnTraitement.Location = new System.Drawing.Point(31, 136);
            this.btnTraitement.Name = "btnTraitement";
            this.btnTraitement.Size = new System.Drawing.Size(87, 23);
            this.btnTraitement.TabIndex = 2;
            this.btnTraitement.Text = "Traitement";
            this.btnTraitement.UseVisualStyleBackColor = true;
            this.btnTraitement.Click += new System.EventHandler(this.BtnTraitementFichierExcel);
            // 
            // btnFichierExcelDépart
            // 
            this.btnFichierExcelDépart.Location = new System.Drawing.Point(31, 107);
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
            this.lblCheminFichierModèle.ForeColor = System.Drawing.Color.Green;
            this.lblCheminFichierModèle.Location = new System.Drawing.Point(124, 112);
            this.lblCheminFichierModèle.Name = "lblCheminFichierModèle";
            this.lblCheminFichierModèle.Size = new System.Drawing.Size(0, 13);
            this.lblCheminFichierModèle.TabIndex = 4;
            // 
            // bgwExcelFinal
            // 
            this.bgwExcelFinal.WorkerReportsProgress = true;
            this.bgwExcelFinal.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwTraitementExcelFinal);
            this.bgwExcelFinal.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BgwProgressionExcelFinal);
            this.bgwExcelFinal.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgwTerminéExcelFinal);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(156, 136);
            this.progressBar1.Maximum = 500;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(176, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 5;
            // 
            // lblProgression
            // 
            this.lblProgression.AutoSize = true;
            this.lblProgression.Location = new System.Drawing.Point(352, 141);
            this.lblProgression.Name = "lblProgression";
            this.lblProgression.Size = new System.Drawing.Size(0, 13);
            this.lblProgression.TabIndex = 6;
            // 
            // txbRecherche
            // 
            this.txbRecherche.BackColor = System.Drawing.SystemColors.Window;
            this.txbRecherche.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbRecherche.ForeColor = System.Drawing.Color.Black;
            this.txbRecherche.Location = new System.Drawing.Point(623, 138);
            this.txbRecherche.Name = "txbRecherche";
            this.txbRecherche.Size = new System.Drawing.Size(359, 20);
            this.txbRecherche.TabIndex = 7;
            this.txbRecherche.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbRecherche.TextChanged += new System.EventHandler(this.txbRecherche_TextChanged);
            // 
            // btnEnregistrerFichier
            // 
            this.btnEnregistrerFichier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnregistrerFichier.Location = new System.Drawing.Point(1193, 136);
            this.btnEnregistrerFichier.Name = "btnEnregistrerFichier";
            this.btnEnregistrerFichier.Size = new System.Drawing.Size(148, 23);
            this.btnEnregistrerFichier.TabIndex = 8;
            this.btnEnregistrerFichier.Text = "Enregistrer le fichier excel...";
            this.btnEnregistrerFichier.UseVisualStyleBackColor = true;
            this.btnEnregistrerFichier.Click += new System.EventHandler(this.btnEnregistrerFichier_Click);
            // 
            // cbxRaisonSociale
            // 
            this.cbxRaisonSociale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbxRaisonSociale.FormattingEnabled = true;
            this.cbxRaisonSociale.Location = new System.Drawing.Point(623, 104);
            this.cbxRaisonSociale.Name = "cbxRaisonSociale";
            this.cbxRaisonSociale.Size = new System.Drawing.Size(359, 21);
            this.cbxRaisonSociale.Sorted = true;
            this.cbxRaisonSociale.TabIndex = 9;
            this.cbxRaisonSociale.SelectedIndexChanged += new System.EventHandler(this.cbxRaisonSociale_SelectedIndexChanged);
            // 
            // bgwExcelBase
            // 
            this.bgwExcelBase.WorkerReportsProgress = true;
            this.bgwExcelBase.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwTraitementExcelBase);
            this.bgwExcelBase.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BgwProgressionExcelBase);
            this.bgwExcelBase.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgwTerminéExcelBase);
            // 
            // lblAttente
            // 
            this.lblAttente.AutoSize = true;
            this.lblAttente.BackColor = System.Drawing.Color.Transparent;
            this.lblAttente.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttente.ForeColor = System.Drawing.Color.Red;
            this.lblAttente.Location = new System.Drawing.Point(317, 350);
            this.lblAttente.Name = "lblAttente";
            this.lblAttente.Size = new System.Drawing.Size(665, 37);
            this.lblAttente.TabIndex = 10;
            this.lblAttente.Text = "Chargement du fichier. Veuillez patienter...";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 653);
            this.Controls.Add(this.lblAttente);
            this.Controls.Add(this.cbxRaisonSociale);
            this.Controls.Add(this.btnEnregistrerFichier);
            this.Controls.Add(this.txbRecherche);
            this.Controls.Add(this.lblProgression);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblCheminFichierModèle);
            this.Controls.Add(this.btnFichierExcelDépart);
            this.Controls.Add(this.btnTraitement);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnTraitement;
        private System.Windows.Forms.Button btnFichierExcelDépart;
        private System.Windows.Forms.Label lblCheminFichierModèle;
        private System.ComponentModel.BackgroundWorker bgwExcelFinal;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgression;
        private System.Windows.Forms.TextBox txbRecherche;
        private System.Windows.Forms.Button btnEnregistrerFichier;
        private System.Windows.Forms.ComboBox cbxRaisonSociale;
        private System.ComponentModel.BackgroundWorker bgwExcelBase;
        private System.Windows.Forms.Label lblAttente;
    }
}

