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
    public partial class RafflesForm : Form
    {
        public RafflesForm()
        {
            InitializeComponent();
        }

        private void residents_SelectedIndexChanged(object sender, EventArgs e)
        {

            showRaffles();
            
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            login2Form form = new login2Form();
            form.Show();
        }

        private void RafflesForm_Load(object sender, EventArgs e)
        {
            comboLoad();
            showRaffles();
        }
        public void comboLoad()
        {
            string q = "select ID from EX1_Summer_2018.dbo.Resident";
            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            SqlCommand cmd = new SqlCommand(q, sql);
            SqlDataReader DR = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(string));
            table.Load(DR);
            residents.ValueMember = "ID";
            residents.DataSource = table;
            sql.Close();

        }
        public void showRaffles()
        {
            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.ResidentRafflesProc", sql);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.SelectCommand.Parameters.AddWithValue("@ID", residents.Text);
            dAdap.Fill(table);
            raffles.DataSource = table;
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
