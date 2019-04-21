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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.tableauRésultats = new System.Windows.Forms.DataGridView();
            this.btnTraitement = new System.Windows.Forms.Button();
            this.btnFichierExcelDépart = new System.Windows.Forms.Button();
            this.lblCheminFichierModèle = new System.Windows.Forms.Label();
            this.bgwExcelFinal = new System.ComponentModel.BackgroundWorker();
            this.barreProgression = new System.Windows.Forms.ProgressBar();
            this.lblProgression = new System.Windows.Forms.Label();
            this.txbRecherche = new System.Windows.Forms.TextBox();
            this.btnEnregistrerFichier = new System.Windows.Forms.Button();
            this.cbxRaisonSociale = new System.Windows.Forms.ComboBox();
            this.bgwExcelBase = new System.ComponentModel.BackgroundWorker();
            this.lblAttente = new System.Windows.Forms.Label();
            this.LogoAtlantic = new System.Windows.Forms.PictureBox();
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblRaisonSociale = new System.Windows.Forms.Label();
            this.lblRecherche = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tableauRésultats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoAtlantic)).BeginInit();
            this.SuspendLayout();
            // 
            // tableauRésultats
            // 
            this.tableauRésultats.AllowUserToAddRows = false;
            this.tableauRésultats.AllowUserToDeleteRows = false;
            this.tableauRésultats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableauRésultats.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tableauRésultats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableauRésultats.Location = new System.Drawing.Point(31, 185);
            this.tableauRésultats.Name = "tableauRésultats";
            this.tableauRésultats.Size = new System.Drawing.Size(1310, 450);
            this.tableauRésultats.TabIndex = 0;
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
            this.lblCheminFichierModèle.Location = new System.Drawing.Point(153, 112);
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
            // barreProgression
            // 
            this.barreProgression.Location = new System.Drawing.Point(156, 136);
            this.barreProgression.Maximum = 500;
            this.barreProgression.Name = "barreProgression";
            this.barreProgression.Size = new System.Drawing.Size(176, 23);
            this.barreProgression.Step = 1;
            this.barreProgression.TabIndex = 5;
            // 
            // lblProgression
            // 
            this.lblProgression.AutoSize = true;
            this.lblProgression.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgression.ForeColor = System.Drawing.Color.Red;
            this.lblProgression.Location = new System.Drawing.Point(352, 141);
            this.lblProgression.Name = "lblProgression";
            this.lblProgression.Size = new System.Drawing.Size(0, 13);
            this.lblProgression.TabIndex = 6;
            // 
            // txbRecherche
            // 
            this.txbRecherche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbRecherche.BackColor = System.Drawing.SystemColors.Window;
            this.txbRecherche.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbRecherche.ForeColor = System.Drawing.Color.Black;
            this.txbRecherche.Location = new System.Drawing.Point(771, 138);
            this.txbRecherche.Name = "txbRecherche";
            this.txbRecherche.Size = new System.Drawing.Size(359, 20);
            this.txbRecherche.TabIndex = 7;
            this.txbRecherche.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbRecherche.TextChanged += new System.EventHandler(this.TxbRechercheRaisonSociale);
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
            this.btnEnregistrerFichier.Click += new System.EventHandler(this.BtnEnregistrerFichierExcel);
            // 
            // cbxRaisonSociale
            // 
            this.cbxRaisonSociale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxRaisonSociale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbxRaisonSociale.FormattingEnabled = true;
            this.cbxRaisonSociale.Location = new System.Drawing.Point(771, 104);
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
            this.lblAttente.BackColor = System.Drawing.Color.Transparent;
            this.lblAttente.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttente.ForeColor = System.Drawing.Color.Red;
            this.lblAttente.Location = new System.Drawing.Point(314, 235);
            this.lblAttente.Name = "lblAttente";
            this.lblAttente.Size = new System.Drawing.Size(665, 37);
            this.lblAttente.TabIndex = 10;
            this.lblAttente.Text = "Chargement du fichier. Veuillez patienter...";
            // 
            // LogoAtlantic
            // 
            this.LogoAtlantic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoAtlantic.Image = global::Chantiers_Laurent.Properties.Resources.Atlantic;
            this.LogoAtlantic.Location = new System.Drawing.Point(1131, 12);
            this.LogoAtlantic.Name = "LogoAtlantic";
            this.LogoAtlantic.Size = new System.Drawing.Size(210, 50);
            this.LogoAtlantic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoAtlantic.TabIndex = 11;
            this.LogoAtlantic.TabStop = false;
            // 
            // lblTitre
            // 
            this.lblTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitre.Font = new System.Drawing.Font("Forte", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.ForeColor = System.Drawing.Color.Teal;
            this.lblTitre.Location = new System.Drawing.Point(0, 0);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(1370, 70);
            this.lblTitre.TabIndex = 12;
            this.lblTitre.Text = "Revue de portefeuille clients";
            this.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRaisonSociale
            // 
            this.lblRaisonSociale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRaisonSociale.AutoSize = true;
            this.lblRaisonSociale.Location = new System.Drawing.Point(677, 107);
            this.lblRaisonSociale.Name = "lblRaisonSociale";
            this.lblRaisonSociale.Size = new System.Drawing.Size(76, 13);
            this.lblRaisonSociale.TabIndex = 13;
            this.lblRaisonSociale.Text = "Raison sociale";
            // 
            // lblRecherche
            // 
            this.lblRecherche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecherche.AutoSize = true;
            this.lblRecherche.Location = new System.Drawing.Point(693, 141);
            this.lblRecherche.Name = "lblRecherche";
            this.lblRecherche.Size = new System.Drawing.Size(60, 13);
            this.lblRecherche.TabIndex = 14;
            this.lblRecherche.Text = "Recherche";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 653);
            this.Controls.Add(this.lblRecherche);
            this.Controls.Add(this.lblRaisonSociale);
            this.Controls.Add(this.LogoAtlantic);
            this.Controls.Add(this.lblAttente);
            this.Controls.Add(this.cbxRaisonSociale);
            this.Controls.Add(this.btnEnregistrerFichier);
            this.Controls.Add(this.txbRecherche);
            this.Controls.Add(this.lblProgression);
            this.Controls.Add(this.barreProgression);
            this.Controls.Add(this.lblCheminFichierModèle);
            this.Controls.Add(this.btnFichierExcelDépart);
            this.Controls.Add(this.btnTraitement);
            this.Controls.Add(this.tableauRésultats);
            this.Controls.Add(this.lblTitre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Revue de portefeuille clients";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableauRésultats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoAtlantic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tableauRésultats;
        private System.Windows.Forms.Button btnTraitement;
        private System.Windows.Forms.Button btnFichierExcelDépart;
        private System.Windows.Forms.Label lblCheminFichierModèle;
        private System.ComponentModel.BackgroundWorker bgwExcelFinal;
        private System.Windows.Forms.ProgressBar barreProgression;
        private System.Windows.Forms.Label lblProgression;
        private System.Windows.Forms.TextBox txbRecherche;
        private System.Windows.Forms.Button btnEnregistrerFichier;
        private System.Windows.Forms.ComboBox cbxRaisonSociale;
        private System.ComponentModel.BackgroundWorker bgwExcelBase;
        private System.Windows.Forms.Label lblAttente;
        private System.Windows.Forms.PictureBox LogoAtlantic;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblRaisonSociale;
        private System.Windows.Forms.Label lblRecherche;
    }
}

