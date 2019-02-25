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
    public partial class addResidentsForm : Form
    {
        public addResidentsForm()
        {
            InitializeComponent();
        }

        private void update_Click(object sender, EventArgs e)
        {
            this.Hide();
            updateDetailsForm form = new updateDetailsForm();
            form.Show();
        }
        public void addToCat()
        {
            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            DataTable table2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("dbo.OptionalEntForResident", Program.cs);
            da2.SelectCommand.Parameters.AddWithValue("@ID", id.Text);
            da2.SelectCommand.CommandType = CommandType.StoredProcedure;
            da2.Fill(table2);

            foreach (DataRow row in table2.Rows)
            {
                SqlCommand cmd3 = new SqlCommand("dbo.addCatToResProc", sql);
                cmd3.CommandType = CommandType.StoredProcedure;
                string sid = row["SerialNO"].ToString();
                int n = Int32.Parse(sid);
                cmd3.Parameters.AddWithValue("@ID", SqlDbType.VarChar).Value = id.Text;
                cmd3.Parameters.AddWithValue("@sid", SqlDbType.VarChar).Value = n;
                cmd3.ExecuteNonQuery();
            }
        }
        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                if (id.Text != "" && bd.Text != "" && firstname.Text != "" && lastname.Text != "" && city.Text != "")
                {

                    SqlConnection sql = new SqlConnection(Program.cs);
                    sql.Open();
                    SqlCommand cm = new SqlCommand("dbo.addResidentProc", sql);
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@id", SqlDbType.VarChar).Value = id.Text;
                    cm.Parameters.AddWithValue("@fname", SqlDbType.VarChar).Value = firstname.Text;
                    cm.Parameters.AddWithValue("@lname", SqlDbType.VarChar).Value = lastname.Text;
                    cm.Parameters.AddWithValue("@bd", SqlDbType.VarChar).Value = bd.Value.Date;
                    cm.Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = status.Text;
                    cm.Parameters.AddWithValue("@city", SqlDbType.VarChar).Value = city.Text;
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Resident Added to DB.");
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
            addToCat();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            chartsAdminForm form = new chartsAdminForm();
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

        private void addResidentsForm_Load(object sender, EventArgs e)
        {
            comboLoad();
        }
        public void comboLoad()
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
    }
}
