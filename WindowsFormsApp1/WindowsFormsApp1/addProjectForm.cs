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
    
    public partial class addProjectForm : Form
    {
        string conId;
        public addProjectForm(string conId)
        {
            InitializeComponent();
            this.conId = conId;
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

            loadNeighbor();

        }
        public void loadNeighbor()
        {
            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.neighborhoodProc", sql);
            dAdap.SelectCommand.Parameters.AddWithValue("@city",city.Text);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            neighborhood.ValueMember = "Neighborhood";
            neighborhood.DataSource = table;
            sql.Close();

        }
        private void add_Click(object sender, EventArgs e)
        {

            if (id.Text == "" || name.Text == "" || percent.Text == "" || city.Text == "" || neighborhood.Text == "")
            {
                MessageBox.Show("Empty fields.");
            }
            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            SqlCommand cmd = new SqlCommand("dbo.AddProjectProc", sql);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProjectNO", SqlDbType.VarChar).Value = id.Text;
            cmd.Parameters.AddWithValue("@ProjectName", SqlDbType.VarChar).Value = name.Text;
            cmd.Parameters.AddWithValue("@AppartmentsPercent", SqlDbType.VarChar).Value = percent.Text;
            cmd.Parameters.AddWithValue("@ContractorID", SqlDbType.VarChar).Value = this.conId;
            cmd.Parameters.AddWithValue("@CityName", SqlDbType.VarChar).Value = city.Text;
            cmd.Parameters.AddWithValue("@Neighborhood", SqlDbType.VarChar).Value = neighborhood.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Project Added.");
            sql.Close();
                
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

        private void addProjectForm_Load(object sender, EventArgs e)
        {
            loadCities();
            changeLable();
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

        private void city_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadNeighbor();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            consChartForm form = new consChartForm(this.conId);
            form.Show();
        }
    }
}
