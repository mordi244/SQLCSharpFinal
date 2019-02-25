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
    public partial class constractorMenuForm : Form
    {
        string conId;
        public constractorMenuForm(string conId)
        {
            InitializeComponent();
            this.conId = conId;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            projectsForm form = new projectsForm(this.conId);
            form.Show();
        }
        public void changeLable()
        {
            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            DataTable table = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("dbo.ConstractorNameProc", sql);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@ID", this.conId);
            da.Fill(table);
            string result = table.Rows[0][0].ToString();
            lbl.Text = "Hello " + result;
        }

        private void constractorMenuForm_Load(object sender, EventArgs e)
        {
            changeLable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            consChartForm form = new consChartForm(this.conId);
            form.Show();
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            login2Form form = new login2Form();
            form.Show();
        }

        private void lbl_Click(object sender, EventArgs e)
        {

        }

        private void btnUsersAndApps_Click(object sender, EventArgs e)
        {
            this.Hide();
            BuildingForm form = new BuildingForm(this.conId);
            form.Show();
        }
    }
}
