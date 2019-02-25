using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class viewResidentsForm : Form
    {
        string id;
         string fname;
         string lname;
        string bd;
        string city;
        string status;
        public viewResidentsForm()
        {
            InitializeComponent();
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            login2Form form = new login2Form();
            form.Show();
        }

        private void GridCitizens_MouseClick(object sender, MouseEventArgs e)
        {            
             id = residentsTable.CurrentRow.Cells[0].Value.ToString();
        }


        private void delete_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine ("id is : "+id);
            SqlConnection sql = new SqlConnection(Program.cs);
                sql.Open();
                SqlCommand cmd = new SqlCommand("dbo.deleteResidentProc", sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", SqlDbType.VarChar).Value = id;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Resident Deleted from DB.");
                sql.Close();

        }

        private void viewResidentsForm_Load(object sender, EventArgs e)
        {
            showResidents();
        }

        public void showResidents()
        {
            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.allResidentsProc", sql);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            residentsTable.DataSource = table;
            sql.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void btnUsersAndApps_Click(object sender, EventArgs e)
        {
            this.Hide();
            RafflesForm form = new RafflesForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            chartsAdminForm form = new chartsAdminForm();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DataForm form = new DataForm();
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
