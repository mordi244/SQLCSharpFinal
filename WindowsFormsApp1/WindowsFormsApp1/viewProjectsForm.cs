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
    public partial class viewProjectsForm : Form
    {
        string projectNo;
        string conId;
        public viewProjectsForm(string conId)
        {
            InitializeComponent();
            this.conId = conId;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            SqlCommand cmd = new SqlCommand("dbo.removeProjFromConProc", sql);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProjectNO", SqlDbType.VarChar).Value = projectNo;
            cmd.Parameters.AddWithValue("@ContractorID", SqlDbType.VarChar).Value = this.conId;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Project Deleted from Contractors DB.");
            showProjects();
            sql.Close();
        }
        public void showProjects()
        {
            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.ProjForConstractorProc", sql);
            dAdap.SelectCommand.Parameters.AddWithValue("@ID", this.conId);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
            projTable.DataSource = table;
            sql.Close();
        }
        private void rafflesTable_MouseClick(object sender, MouseEventArgs e)
        {
            projectNo = projTable.CurrentRow.Cells[0].Value.ToString();
        }

        private void viewProjectsForm_Load(object sender, EventArgs e)
        {
            showProjects();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            projectsForm form = new projectsForm(this.conId);
            form.Show();
        }

        private void btnUsersAndApps_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            consChartForm form = new consChartForm(this.conId);
            form.Show();
        }
    }
}
