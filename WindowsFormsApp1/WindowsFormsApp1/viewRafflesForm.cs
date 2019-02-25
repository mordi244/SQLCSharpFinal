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
    public partial class viewRafflesForm : Form
    {
        string raffle;
        string resId;
       
        public viewRafflesForm(string resId)
        {
            InitializeComponent();
            this.resId = resId;
        }

        private void viewRafflesForm_Load(object sender, EventArgs e)
        {
            showRaffles();
            changeLable();
        }
        public void changeLable()
        {
            SqlConnection sqlCon = new SqlConnection(Program.cs);
            sqlCon.Open();
            DataTable dtbl = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("dbo.ResidentFullNameProc", sqlCon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@ID", this.resId);
            da.Fill(dtbl);
            string result = dtbl.Rows[0][0].ToString();
            lbl.Text = "Hello " + result;

        }

        public void showRaffles()
        {
            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.ResidentRafflesProc", sql);
            dAdap.SelectCommand.Parameters.AddWithValue("@ID", this.resId);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            rafflesTable.DataSource = table;
            sql.Close();
        }
        public void showOptionalRaffles()
        {
            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.ResidentOptionalRafflesProc", sql);
            dAdap.SelectCommand.Parameters.AddWithValue("@ID", this.resId);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            rafflesTable.DataSource = table;
            sql.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResidentPersonalForm form = new ResidentPersonalForm(this.resId);
            form.Show();
        }

        private void btnUsersAndApps_Click(object sender, EventArgs e)
        {
            this.Hide();
            rafflesForm2 form = new rafflesForm2(this.resId);
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            SqlCommand cmd = new SqlCommand("dbo.deleteRaffleFromResidentProc", sql);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", SqlDbType.VarChar).Value = this.resId;
            cmd.Parameters.AddWithValue("@raff", SqlDbType.VarChar).Value = raffle;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Raffle Deleted from Resident DB.");
            showRaffles();
            sql.Close();
        }

        private void rafflesTable_MouseClick(object sender, MouseEventArgs e)
        {
            raffle = rafflesTable.CurrentRow.Cells[0].Value.ToString();
           
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            login2Form form = new login2Form();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResidentChartsForm form = new ResidentChartsForm(this.resId);
            form.Show();
        }

        private void rafflesTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
