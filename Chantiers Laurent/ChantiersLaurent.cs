using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Chantiers_Laurent
{
    public partial class Principal : Form
    {
        public int Compteur;
        public int Progression;
        public string CheminModèle;
        private readonly System.Data.DataTable _data = new System.Data.DataTable();

        public Principal()
        {
            InitializeComponent();
        }

        [STAThread]
        private void Principal_Load(object sender, EventArgs e)
        {
            btnTraitement.Enabled = false;
            cbxRaisonSociale.Enabled = false;
            txbRecherche.Enabled = false;
            btnEnregistrerFichier.Enabled = false;
            dataGridView1.DoubleBuffered(true);
            lblAttente.Visible = false;
        }

        private void BtnFicherExcelDépart(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = @"Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xlsx",
                Filter = @"xlsx files (*.xlsx)|*.xlsx",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lblCheminFichierModèle.Text = openFileDialog1.FileName;
            }

            bgwExcelBase.RunWorkerAsync();
        }

        private void BgwTraitementExcelBase(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            lblAttente.Invoke(new MethodInvoker(delegate
            {
                lblAttente.Parent = dataGridView1;
    lblAttente.Visible = true;
}));
            var strPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Modèle.xlsx";
            if (File.Exists(strPath)) File.Delete(strPath);
            var assembly = Assembly.GetExecutingAssembly();
            var input = assembly.GetManifestResourceStream("Chantiers_Laurent.Resources.Modèle.xlsx");
            var output = File.Open(strPath, FileMode.CreateNew);
            CopieFichierModèle(input, output);
            input?.Dispose();
            output.Dispose();

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlApp.Visible = false;
            xlApp.DisplayAlerts = false;
            Workbook fichierExcelDépart = xlApp.Workbooks.Open(lblCheminFichierModèle.Text);
            Worksheet feuilleDépart = fichierExcelDépart.Worksheets[1];
            Range colonnes12 = feuilleDépart.Range[feuilleDépart.Cells[1, 1], feuilleDépart.Cells[1, 2]];
            colonnes12.UnMerge();

            feuilleDépart.Range["B1"].EntireColumn.Delete();
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Base.xlsx")) File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Base.xlsx");
            fichierExcelDépart.SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Base.xlsx");

            String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Base.xlsx" +
                            ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

            OleDbConnection con = new OleDbConnection(constr);
            con.Open();

            //OleDbCommand oconn = new OleDbCommand("Select * From [" + feuilleDépart.Name + "$] WHERE [Nom de l'offre / du chantier] LIKE '%ICF%'", con);
            OleDbCommand oconn = new OleDbCommand("Select * From [" + feuilleDépart.Name + "$]", con);

            OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
            System.Data.DataTable data = new System.Data.DataTable();
            sda.Fill(data);

            dataGridView1.Invoke(new MethodInvoker(delegate
{
    dataGridView1.DataSource = data;
    if (dataGridView1.Rows.Count > 0) btnTraitement.Enabled = true;
}));

            con.Close();
            fichierExcelDépart.Close(0);
            xlApp.Quit();
            GC.Collect();
        }

        private void BgwProgressionExcelBase(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
        }

        private void BgwTerminéExcelBase(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            lblAttente.Visible = false;
        }

        private void BtnTraitementFichierExcel(object sender, EventArgs e)
        {
            bgwExcelFinal.RunWorkerAsync();
        }

        private void BgwTraitementExcelFinal(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlApp.Visible = false;
            xlApp.DisplayAlerts = false;

            Workbook fichierExcelDépart = xlApp.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Base.xlsx");
            Worksheet feuilleDépart = fichierExcelDépart.Worksheets[1];

            Workbook fichierExcelModèle = xlApp.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Modèle.xlsx");
            Worksheet feuilleModèle = fichierExcelModèle.Worksheets[1];

            int ligneModèle = 6;
            int dernierRang = feuilleDépart.Cells.Find("*", Missing.Value,
                               Missing.Value, Missing.Value,
                               XlSearchOrder.xlByRows, XlSearchDirection.xlPrevious,
                               false, Missing.Value, Missing.Value).Row;
            Compteur = dernierRang;

            for (int i = 2; i <= dernierRang; i++)
            {
                if (feuilleDépart.Cells[i, 1].Value != null)
                {
                    if (feuilleDépart.Cells[i, 1].Value == feuilleDépart.Cells[i - 1, 1].Value.ToString())
                    {
                        if (feuilleDépart.Cells[i, 12].Value == "Bureau d'études")
                        {
                            Range ligneSource = feuilleDépart.Range[feuilleDépart.Cells[i, 13], feuilleDépart.Cells[i, 16]];
                            Range ligneDestination = feuilleModèle.Range[feuilleModèle.Cells[ligneModèle, 20], feuilleModèle.Cells[ligneModèle, 23]];

                            ligneSource.Copy(ligneDestination);
                        }
                        if (feuilleDépart.Cells[i, 12].Value == "Installateur")
                        {
                            Range ligneSource = feuilleDépart.Range[feuilleDépart.Cells[i, 13], feuilleDépart.Cells[i, 16]];
                            Range ligneDestination = feuilleModèle.Range[feuilleModèle.Cells[ligneModèle, 24], feuilleModèle.Cells[ligneModèle, 27]];

                            ligneSource.Copy(ligneDestination);
                        }
                        if (feuilleDépart.Cells[i, 12].Value == "Maitrise Ouvrage")
                        {
                            Range ligneSource = feuilleDépart.Range[feuilleDépart.Cells[i, 13], feuilleDépart.Cells[i, 16]];
                            Range ligneDestination = feuilleModèle.Range[feuilleModèle.Cells[ligneModèle, 12], feuilleModèle.Cells[ligneModèle, 15]];

                            ligneSource.Copy(ligneDestination);
                        }
                        if (feuilleDépart.Cells[i, 12].Value == "Entreprise Generale")
                        {
                            Range ligneSource = feuilleDépart.Range[feuilleDépart.Cells[i, 13], feuilleDépart.Cells[i, 16]];
                            Range ligneDestination = feuilleModèle.Range[feuilleModèle.Cells[ligneModèle, 16], feuilleModèle.Cells[ligneModèle, 19]];

                            ligneSource.Copy(ligneDestination);
                        }
                    }
                    else
                    {
                        Range ligneSource = feuilleDépart.Range[feuilleDépart.Cells[i, 1], feuilleDépart.Cells[i, 11]];
                        Range ligneDestination = feuilleModèle.Range[feuilleModèle.Cells[ligneModèle, 1], feuilleModèle.Cells[ligneModèle, 11]];

                        ligneSource.Copy(ligneDestination);

                        if (feuilleDépart.Cells[i, 12].Value == "Bureau d'études")
                        {
                            Range ligneSource1 = feuilleDépart.Range[feuilleDépart.Cells[i, 13], feuilleDépart.Cells[i, 16]];
                            Range ligneDestination1 = feuilleModèle.Range[feuilleModèle.Cells[ligneModèle, 20], feuilleModèle.Cells[ligneModèle, 23]];

                            ligneSource1.Copy(ligneDestination1);
                        }
                        if (feuilleDépart.Cells[i, 12].Value == "Installateur")
                        {
                            Range ligneSource1 = feuilleDépart.Range[feuilleDépart.Cells[i, 13], feuilleDépart.Cells[i, 16]];
                            Range ligneDestination1 = feuilleModèle.Range[feuilleModèle.Cells[ligneModèle, 24], feuilleModèle.Cells[ligneModèle, 27]];

                            ligneSource1.Copy(ligneDestination1);
                        }
                        if (feuilleDépart.Cells[i, 12].Value == "Maitrise Ouvrage")
                        {
                            Range ligneSource1 = feuilleDépart.Range[feuilleDépart.Cells[i, 13], feuilleDépart.Cells[i, 16]];
                            Range ligneDestination1 = feuilleModèle.Range[feuilleModèle.Cells[ligneModèle, 12], feuilleModèle.Cells[ligneModèle, 15]];

                            ligneSource1.Copy(ligneDestination1);
                        }
                        if (feuilleDépart.Cells[i, 12].Value == "Entreprise Generale")
                        {
                            Range ligneSource1 = feuilleDépart.Range[feuilleDépart.Cells[i, 13], feuilleDépart.Cells[i, 16]];
                            Range ligneDestination1 = feuilleModèle.Range[feuilleModèle.Cells[ligneModèle, 16], feuilleModèle.Cells[ligneModèle, 19]];

                            ligneSource1.Copy(ligneDestination1);
                        }

                        if (ligneModèle % 2 == 0)
                        {
                            Range ligneDestination1 = feuilleModèle.Range[feuilleModèle.Cells[ligneModèle, 1],
                                feuilleModèle.Cells[ligneModèle, 27]];
                            ligneDestination1.Interior.Color = XlRgbColor.rgbLightGrey;
                        }
                        else
                        {
                            Range ligneDestination1 = feuilleModèle.Range[feuilleModèle.Cells[ligneModèle, 1],
                                feuilleModèle.Cells[ligneModèle, 27]];
                            ligneDestination1.Interior.Color = XlRgbColor.rgbWhite;
                        }
                        ligneModèle++;
                    }
                }
                bgwExcelFinal.ReportProgress(i);
                Progression = i;
            }
            fichierExcelModèle.Save();

            String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Modèle.xlsx" +
                                ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

            OleDbConnection con = new OleDbConnection(constr);
            con.Open();

            //OleDbCommand oconn = new OleDbCommand("Select * From [" + feuilleDépart.Name + "$] WHERE [Nom de l'offre / du chantier] LIKE '%ICF%'", con);
            OleDbCommand oconn = new OleDbCommand("Select * From [" + feuilleModèle.Name + "$A5:AA5000]", con);
            OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
            //System.Data.DataTable data = new System.Data.DataTable();
            sda.Fill(_data);
            dataGridView1.Invoke(new MethodInvoker(delegate
{
    dataGridView1.DataSource = _data;
    dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;
    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor =
        Color.Beige;
    con.Close();
}));

            fichierExcelDépart.Close(0);
            fichierExcelModèle.Close(0);
            xlApp.Quit();
            GC.Collect();
            RemplirCombobox();
        }

        private void BgwProgressionExcelFinal(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = Compteur;
            progressBar1.Value = e.ProgressPercentage;
            lblProgression.Text = Progression + @" / " + Compteur;
        }

        private void BgwTerminéExcelFinal(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 0;
            lblProgression.Text = @"Traitement terminé !";
            cbxRaisonSociale.Enabled = true;
            txbRecherche.Enabled = true;
            btnEnregistrerFichier.Enabled = true;
            cbxRaisonSociale.SelectedIndex = 0;
        }

        private void CopieFichierModèle(Stream input, Stream output)
        {
            var buffer = new byte[32768];
            while (true)
            {
                var read = input.Read(buffer, 0, buffer.Length);
                if (read <= 0)
                    return;
                output.Write(buffer, 0, read);
            }
        }

        private void txbRecherche_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(_data)
            {
                RowFilter = "[Raison sociale] like '" + txbRecherche.Text + "%' OR [Raison sociale1] like '" +
                            txbRecherche.Text + "%' OR [Raison sociale2] like '" + txbRecherche.Text +
                            "%' OR [Raison sociale3] like '" + txbRecherche.Text + "%'"
            };
            dataGridView1.DataSource = dv;

            if (dataGridView1.Rows.Count == 1)
            {
                foreach (DataGridViewColumn colonne in dataGridView1.Columns)
                {
                    if (dataGridView1.Rows[0].Cells[colonne.Name].Value.ToString() == "")
                    {
                        colonne.Visible = false;
                    }
                    else
                    {
                        colonne.Visible = true;
                    }
                }
            }
            else
            {
                foreach (DataGridViewColumn colonne in dataGridView1.Columns)
                {
                    colonne.Visible = true;
                }
            }

            if (dataGridView1.Rows.Count > 0 && txbRecherche.Text != "")
            {
                txbRecherche.BackColor = Color.LightGreen;
            }
            if (dataGridView1.Rows.Count == 0 && txbRecherche.Text != "")
            {
                txbRecherche.BackColor = Color.Red;
            }
            if (txbRecherche.Text == "")
            {
                txbRecherche.BackColor = Color.White;
            }
        }

        private void RemplirCombobox()
        {
            dataGridView1.Invoke(new MethodInvoker(delegate
{
    cbxRaisonSociale.Items.Clear();

    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    {
        if (dataGridView1[11, i].Value != null)
        {
            if (!cbxRaisonSociale.Items.Contains(dataGridView1[11, i].Value.ToString()))
                cbxRaisonSociale.Items.Add(dataGridView1[11, i].Value.ToString());
        }
        if (dataGridView1[15, i].Value != null)
        {
            if (!cbxRaisonSociale.Items.Contains(dataGridView1[15, i].Value.ToString()))
                cbxRaisonSociale.Items.Add(dataGridView1[15, i].Value.ToString());
        }
        if (dataGridView1[19, i].Value != null)
        {
            if (!cbxRaisonSociale.Items.Contains(dataGridView1[19, i].Value.ToString()))
                cbxRaisonSociale.Items.Add(dataGridView1[19, i].Value.ToString());
        }
        if (dataGridView1[23, i].Value != null)
        {
            if (!cbxRaisonSociale.Items.Contains(dataGridView1[23, i].Value.ToString()))
                cbxRaisonSociale.Items.Add(dataGridView1[23, i].Value.ToString());
        }
    }

    for (int i = 0; i < cbxRaisonSociale.Items.Count; i++)
    {
        if (cbxRaisonSociale.GetItemText(cbxRaisonSociale.Items[i]) == "")
        {
            cbxRaisonSociale.Items.Remove(cbxRaisonSociale.Items[i]);
        }
    }

    cbxRaisonSociale.Items.Add("***AUCUN FILTRE***");
}));
        }

        private void btnEnregistrerFichier_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                var folderPath = folderBrowserDialog1.SelectedPath;
                File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Modèle.xlsx",
                    folderPath + @"\Chantiers.xlsx");
            }
        }

        private void cbxRaisonSociale_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbRecherche.Text = cbxRaisonSociale.Text;
            if (cbxRaisonSociale.Text == @"***AUCUN FILTRE***")
            {
                txbRecherche.Text = "";
            }
        }
    }

    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            if (pi != null) pi.SetValue(dgv, setting, null);
        }
    }
}