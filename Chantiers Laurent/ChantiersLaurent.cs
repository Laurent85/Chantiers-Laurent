using Microsoft.Office.Interop.Excel;
using System;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Chantiers_Laurent
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
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
                dataGridView1.DataSource = data;

                con.Close();
                fichierExcelDépart.Close();
                xlApp.Quit();
                GC.Collect();
            }
        }

        private void BtnTraitementFichierExcel(object sender, EventArgs e)
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
                            ligneDestination1.Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbLightGrey;
                        }
                        else
                        {
                            Range ligneDestination1 = feuilleModèle.Range[feuilleModèle.Cells[ligneModèle, 1],
                                feuilleModèle.Cells[ligneModèle, 27]];
                            ligneDestination1.Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbWhite;  
                        }
                        ligneModèle++;
                    }
                }
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
            System.Data.DataTable data = new System.Data.DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor =
                Color.Beige;
            con.Close();

            fichierExcelDépart.Close();
            fichierExcelModèle.Close();
            xlApp.Quit();
            GC.Collect();
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
    }
}