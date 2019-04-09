using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chantiers_Laurent
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlApp.Visible = false;
            Microsoft.Office.Interop.Excel.Workbook excelBook = xlApp.Workbooks.Open(lblCheminFichierModèle.Text);
            excelBook.IsAddin = false;

            String[] excelSheets = new String[excelBook.Worksheets.Count];
            int i = 0;
            foreach (Microsoft.Office.Interop.Excel.Worksheet wSheet in excelBook.Worksheets)
            {
                excelSheets[i] = wSheet.Name;
                i++;
            }

            excelBook.Close();
            xlApp.Quit();
            String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                            lblCheminFichierModèle.Text +
                            ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            
                OleDbCommand oconn = new OleDbCommand("Select * From [" + excelSheets[0] + "$] WHERE [Nom de l'offre / du chantier] LIKE '%ICF%'", con);
                

                OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
            
            


        }

        private void button2_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlApp.Visible = false;
            Microsoft.Office.Interop.Excel.Workbook excelBook = xlApp.Workbooks.Open(lblCheminFichierModèle.Text);
            excelBook.IsAddin = false;

            String[] excelSheets = new String[excelBook.Worksheets.Count];
            int i = 0;
            foreach (Microsoft.Office.Interop.Excel.Worksheet wSheet in excelBook.Worksheets)
            {
                excelSheets[i] = wSheet.Name;
                i++;
            }

            excelBook.Close();
            Microsoft.Office.Interop.Excel.Application xlApp1 = new Microsoft.Office.Interop.Excel.Application();
            xlApp1.Visible = false;
            Microsoft.Office.Interop.Excel.Workbook excelBook1 = xlApp1.Workbooks.Open("C:\\Users\\User\\Desktop\\Modèle.xlsx");
            excelBook1.IsAddin = false;

            String[] excelSheets1 = new String[excelBook1.Worksheets.Count];
            int j = 0;
            foreach (Microsoft.Office.Interop.Excel.Worksheet wSheet1 in excelBook1.Worksheets)
            {
                excelSheets1[j] = wSheet1.Name;
                j++;
            }

            excelBook1.Close();

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

        private void button3_Click(object sender, EventArgs e)
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
            }

        }
    }
}
