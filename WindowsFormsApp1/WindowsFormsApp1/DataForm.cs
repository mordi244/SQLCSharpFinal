using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class DataForm : Form
    {
        public DataForm()
        {
            InitializeComponent();
        }

        private void DataForm_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DataForm form = new DataForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = new OleDbConnection(Program.cexcel))
            {
                OleDbCommand command = new OleDbCommand
                ("Select * FROM [Sheet1$]", con);
                con.Open();
                using (DbDataReader dr = command.ExecuteReader())
                {
                    using (SqlBulkCopy bulkCopy =
                               new SqlBulkCopy(Program.cs))
                    {
                        bulkCopy.DestinationTableName = "ImportExportData";
                        bulkCopy.WriteToServer(dr);
                        MessageBox.Show("Data Imported.");
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            export();
        }

        public void export()
        {

            StreamWriter stream = new StreamWriter("D:logECategories.txt", true);

            //Adding data To DataTable
            DataTable table = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("dbo.ExportProc", Program.cs);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(table);


            int i = 0;
            stream.Write(Environment.NewLine);
            foreach (DataRow row in table.Rows)
            {
                object[] arr = row.ItemArray;
                for (i = 0; i < arr.Length - 1; i++)
                {
                    stream.Write(arr[i].ToString() +" | ");
                }
                stream.WriteLine(arr[i].ToString());
            }
            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            SqlCommand cmd = new SqlCommand("dbo.DataToImportProc", sql);
            cmd.ExecuteNonQuery();    
            SqlCommand cmd2 = new SqlCommand("dbo.RemoveAllImport", sql);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Table Import Cleaned");
            sql.Close();
            stream.Flush();
            stream.Close();
            MessageBox.Show("Data Exported to file.");
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            chartsAdminForm form = new chartsAdminForm();
            form.Show();
        }

        private void btnUsersAndApps_Click(object sender, EventArgs e)
        {
            this.Hide();
            RafflesForm form = new RafflesForm();
            form.Show();
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            login2Form form = new login2Form();
            form.Show();
        }

        private void btnQueries_Click(object sender, EventArgs e)
        {
            this.Hide();
            HW2Form form = new HW2Form();
            form.Show();
        }
    }
}
