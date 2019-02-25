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
    public partial class signToRafflesForm : Form
    {
        string resId;
        public signToRafflesForm(string resId)
        {
            InitializeComponent();
            this.resId = resId;
        }

        private void signToRafflesForm_Load(object sender, EventArgs e)
        {
            comboLoad();
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

        public void comboLoad()
        {

            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.PossibleRafflesForResident", sql);
            dAdap.SelectCommand.Parameters.AddWithValue("@ID", this.resId);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);

             raffles.ValueMember = "RaffleNO";
             raffles.DataSource = table;
            sql.Close();

        }
        public void getRafDet()
        {
            
            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.RafflesDetailsProc", sql);
            dAdap.SelectCommand.Parameters.AddWithValue("@raffle", raffles.Text);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            date.Text = table.Rows[0][0].ToString();
            project.Text = table.Rows[0][1].ToString();
            city.Text = table.Rows[0][2].ToString();


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

        private void raffles_SelectedIndexChanged(object sender, EventArgs e)
        {
            getRafDet();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(Program.cs);
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("dbo.SignResidentToRaffleProc", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@raff", SqlDbType.VarChar).Value = raffles.Text;
            cmd.Parameters.AddWithValue("@id", SqlDbType.VarChar).Value = this.resId;
            cmd.Parameters.AddWithValue("@date", SqlDbType.VarChar).Value = DateTime.Now;
            cmd.Parameters.AddWithValue("@place", SqlDbType.TinyInt).Value = 0;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Resident sign to Raffle");
            }
            catch
            {
                MessageBox.Show("Resident alreadt participate in raffle.");
            }
           

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
    }
}
