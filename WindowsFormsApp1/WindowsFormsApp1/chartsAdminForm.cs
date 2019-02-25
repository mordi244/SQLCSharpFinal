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
    public partial class chartsAdminForm : Form
    {
        public chartsAdminForm()
        {
            InitializeComponent();
        }

        private void chartsAdminForm_Load(object sender, EventArgs e)
        {
           projectsOfConstChart();
            mishtekenPerProj();
        }
        public void mishtekenPerProj()
        {
            SqlConnection sql = new SqlConnection(Program.cs);
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.NumberOfMishtakenPerProjectProc", sql);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            chart2.DataSource = table;
            chart2.Series["Series1"].XValueMember = "Project";
            chart2.Series["Series1"].YValueMembers = "Percentage";

        }

        public void projectsOfConstChart()
        {
            SqlConnection sql = new SqlConnection(Program.cs);
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.NumberOfProjectsToConstractorChartProc", sql);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            chart1.DataSource = table;
            chart1.Series["Series1"].XValueMember = "Name";
            chart1.Series["Series1"].YValueMembers = "Number of Projects";

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

        private void btnUsersAndApps_Click(object sender, EventArgs e)
        {
            this.Hide();
            RafflesForm form = new RafflesForm();
            form.Show();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
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
