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
    public partial class ResidentMainForm : Form
    {
        private string resId;
        public ResidentMainForm(string resId)
        {
            InitializeComponent();
            this.resId = resId;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResidentPersonalForm form = new ResidentPersonalForm(resId);
            form.Show();
        }

        private void ResidentMainForm_Load(object sender, EventArgs e)
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


        private void btnUsersAndApps_Click(object sender, EventArgs e)
        {
            this.Hide();
            rafflesForm2 form = new rafflesForm2(resId);
            form.Show();
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
