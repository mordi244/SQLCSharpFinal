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
    public partial class projectsForm : Form
    {
        string conId;
        public projectsForm(string conId)
        {
            InitializeComponent();
            this.conId = conId;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            addProjectForm form = new addProjectForm(this.conId);
            form.Show();
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            login2Form form = new login2Form();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewProjectsForm form = new viewProjectsForm(this.conId);
            form.Show();
        }
        public void changeLable()
        {
            SqlConnection sqlCon = new SqlConnection(Program.cs);
            sqlCon.Open();
            DataTable dtbl = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("dbo.ConstractorNameProc", sqlCon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@ID", this.conId);
            da.Fill(dtbl);
            string result = dtbl.Rows[0][0].ToString();
            lbl.Text = "Hello " + result;

        }

        private void projectsForm_Load(object sender, EventArgs e)
        {
            changeLable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            consChartForm form = new consChartForm(this.conId);
            form.Show();
        }

        private void btnUsersAndApps_Click(object sender, EventArgs e)
        {
            this.Hide();
            addBuildingForm form = new addBuildingForm(this.conId);
            form.Show();

        }
    }
}
