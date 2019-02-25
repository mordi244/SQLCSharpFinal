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
    public partial class HW2Form : Form
    {
        public HW2Form()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(Program.cs);
            sqlCon.Open();
            tableView.DataSource = null;
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.HW1", sqlCon);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            tableView.DataSource = table;
            sqlCon.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(Program.cs);
            sqlCon.Open();
            tableView.DataSource = null;
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.H2", sqlCon);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            tableView.DataSource = table;
            sqlCon.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(Program.cs);
            sqlCon.Open();
            tableView.DataSource = null;
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.HW3", sqlCon);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            tableView.DataSource = table;
            sqlCon.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(Program.cs);
            sqlCon.Open();
            tableView.DataSource = null;
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.HW4", sqlCon);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            tableView.DataSource = table;
            sqlCon.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(Program.cs);
            sqlCon.Open();
            tableView.DataSource = null;
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.HW5", sqlCon);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            tableView.DataSource = table;
            sqlCon.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(Program.cs);
            sqlCon.Open();
            tableView.DataSource = null;
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.HW6", sqlCon);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            tableView.DataSource = table;
            sqlCon.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(Program.cs);
            sqlCon.Open();
            tableView.DataSource = null;
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.HW7", sqlCon);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            tableView.DataSource = table;
            sqlCon.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(Program.cs);
            sqlCon.Open();
            tableView.DataSource = null;
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.HW8", sqlCon);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            tableView.DataSource = table;
            sqlCon.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(Program.cs);
            sqlCon.Open();
            tableView.DataSource = null;
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.HW9", sqlCon);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            tableView.DataSource = table;
            sqlCon.Close();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            DataForm form = new DataForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            chartsAdminForm form = new chartsAdminForm();
            form.Show();
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            login2Form form = new login2Form();
            form.Show();
        }
    }
}
