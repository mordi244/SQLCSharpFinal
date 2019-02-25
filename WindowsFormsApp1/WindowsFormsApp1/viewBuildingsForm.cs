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
    public partial class viewBuildingsForm : Form
    {
        string conId;
        string project;
        string building;
        public viewBuildingsForm(string conId)
        {
            InitializeComponent();
            this.conId = conId;
        }


        public void showBuildings()
        {
            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.showBuildingsProc", sql);
            dAdap.SelectCommand.Parameters.AddWithValue("@ID", this.conId);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            buildingsTable.DataSource = table;
            sql.Close();
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

        private void viewBuildingsForm_Load(object sender, EventArgs e)
        {
            showBuildings();
            changeLable();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            projectsForm form = new projectsForm(this.conId);
            form.Show();
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
            BuildingForm form = new BuildingForm(this.conId);
            form.Show();
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            login2Form form = new login2Form();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sql = new SqlConnection(Program.cs);
                sql.Open();
                SqlCommand cmd = new SqlCommand("dbo.deleteBuildingFromConstractorProc", sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@project", SqlDbType.VarChar).Value = project;
                cmd.Parameters.AddWithValue("@building", SqlDbType.VarChar).Value = building;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Building Deleted.");
                showBuildings();
                sql.Close();
            }
            catch
            {
                MessageBox.Show("Building cant deleted because it have apartments.");
            }
        }

        private void buildingsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buildingsTable_MouseClick(object sender, MouseEventArgs e)
        {
            project = buildingsTable.CurrentRow.Cells[0].Value.ToString();
            building = buildingsTable.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
