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
    public partial class consChartForm : Form
    {
        string conId;
        public consChartForm(string conId)
        {
            InitializeComponent();
            this.conId = conId;
        }
        public void ConstractorApartmentsTentChart()
        {
            SqlConnection con = new SqlConnection(Program.cs);         
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.ConstractorApartmentsTentChartProc", con);
            dAdap.SelectCommand.Parameters.AddWithValue("@ID", this.conId);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable table = new DataTable();
            dAdap.Fill(table);
            chart1.DataSource = table;
            chart1.Series["Series1"].XValueMember = "Tenant Price Apartments";
            chart1.Series["Series1"].YValueMembers = "ProjectNO";

        }
        public void ParticipanrsPerCityChart()
        {
            SqlConnection con = new SqlConnection(Program.cs);
            SqlDataAdapter da = new SqlDataAdapter("dbo.ParticipanrsPerCityChartProc", con);
            da.SelectCommand.Parameters.AddWithValue("@ID", this.conId);
            da.SelectCommand.Parameters.AddWithValue("@city", city.Text);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            chart2.DataSource = dt;
            chart2.Series["Series1"].XValueMember = "ProjectNO";
            chart2.Series["Series1"].YValueMembers = "Tenant Price Apartments";

        }

        private void consChartForm_Load(object sender, EventArgs e)
        {
            ConstractorApartmentsTentChart();
            loadCities();
            
        }
        public void loadCities()
        {

            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.citiesProc", sql);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            city.ValueMember = "Name";
            city.DataSource = table;
            sql.Close();

        }

        private void city_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParticipanrsPerCityChart();
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
            projectsForm form = new projectsForm(this.conId);
            form.Show();
        }

        private void btnUsersAndApps_Click(object sender, EventArgs e)
        {
            this.Hide();
            BuildingForm form = new BuildingForm(this.conId);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
