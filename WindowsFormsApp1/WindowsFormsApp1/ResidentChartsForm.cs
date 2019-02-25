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
    public partial class ResidentChartsForm : Form
    {
        string resId;
        public ResidentChartsForm(string resId)
        {
            InitializeComponent();
            this.resId = resId;
        }

        private void ResidentChartsForm_Load(object sender, EventArgs e)
        {
            amountOfAccessoryChartProc();
            AppartmentsWithBalconChartProc();
        }
        public void amountOfAccessoryChartProc()
        {
            SqlConnection sql = new SqlConnection(Program.cs);
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.amountOfAccessoryChartProc", sql);          
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            chart1.DataSource = table;
            chart1.Series["Series1"].XValueMember = "Project";
            chart1.Series["Series1"].YValueMembers = "Total Amount of Accessory";
        }
        public void AppartmentsWithBalconChartProc()
        {
            SqlConnection sql = new SqlConnection(Program.cs);
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.AppartmentsWithBalconChartProc", sql);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            chart2.DataSource = table;
            chart2.Series["Series1"].XValueMember = "Project";
            chart2.Series["Series1"].YValueMembers = "Number of Appartments with high floors";

        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            login2Form form = new login2Form();
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
            this.Hide();
            rafflesForm2 form = new rafflesForm2(resId);
            form.Show();
        }
    }
}
