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
    
    public partial class rafflesForm2 : Form
    {
        string resId;
        public rafflesForm2(string resId)
        {
            InitializeComponent();
            this.resId = resId;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewRafflesForm form = new viewRafflesForm(this.resId);
            form.Show();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResidentPersonalForm form = new ResidentPersonalForm(this.resId);
            form.Show();
        }

        private void btnUsersAndApps_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            signToRafflesForm form = new signToRafflesForm(this.resId);
            form.Show();
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            login2Form form = new login2Form();
            form.Show();
        }

        private void rafflesForm2_Load(object sender, EventArgs e)
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResidentChartsForm form = new ResidentChartsForm(this.resId);
            form.Show();
        }
    }
}
