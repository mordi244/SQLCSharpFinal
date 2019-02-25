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
    public partial class addBuildingForm : Form
    {
        string conId;
        public addBuildingForm(string conId)
        {
            InitializeComponent();
            this.conId = conId;
        }

        private void addBuildingForm_Load(object sender, EventArgs e)
        {
            loadProjects();
        }

        public void loadProjects()
        {
            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.ProjectsOfConstractorProc", sql);
            dAdap.SelectCommand.Parameters.AddWithValue("@ID", this.conId);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            projects.ValueMember = "ProjectNO";
            projects.DataSource = table;
            sql.Close();
        }

        private void btnUsersAndApps_Click(object sender, EventArgs e)
        {
            this.Hide();
            BuildingForm form = new BuildingForm(this.conId);
            form.Show();
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                if (projects.Text != "" && location.Text != "" && floors.Text != "" && autonum.Text != "")
                {

                    SqlConnection sql = new SqlConnection(Program.cs);
                    sql.Open();
                    SqlCommand cm = new SqlCommand("dbo.AddBuildingToProj", sql);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@project", SqlDbType.VarChar).Value = projects.Text;
                    cm.Parameters.AddWithValue("@building", SqlDbType.VarChar).Value = autonum.Text;
                    cm.Parameters.AddWithValue("@floors", SqlDbType.VarChar).Value = floors.Text;
                    cm.Parameters.AddWithValue("@location", SqlDbType.VarChar).Value = location.Text;
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Building Added.");
                    sql.Close();
                }
                else
                {
                    MessageBox.Show("Empty Fields. Cheack Again.");
                }
            }
            catch
            {
                MessageBox.Show("Resident already exists in DB.");
            }
        }
       
        public void autoNum()
        {
            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            DataTable table = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("dbo.BuildingNumberProc", sql);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@project", projects.Text);
            da.Fill(table);
            string auto = table.Rows[0][0].ToString();
            int auton = Int32.Parse(auto);
            auton += 1;
            autonum.Text = auton.ToString();
        }

        private void projects_SelectedIndexChanged(object sender, EventArgs e)
        {
            autoNum();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
