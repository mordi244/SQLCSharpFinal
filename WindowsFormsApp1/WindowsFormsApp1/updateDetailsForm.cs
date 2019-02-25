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
    public partial class updateDetailsForm : Form
    {
        
        public updateDetailsForm()
        {
            InitializeComponent();
        }

        private void updateDetailsForm_Load(object sender, EventArgs e)
        {
           LoadCities();
            Residents();

        }

       

        public void Residents()
        {
            string q = "select ID from EX1_Summer_2018.dbo.Resident";
            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            SqlCommand cmd = new SqlCommand(q, sql);
            SqlDataReader DR = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(string));          
            table.Load(DR);
            residents.ValueMember = "ID";
            residents.DataSource = table;
            sql.Close();
 
        }

        public void LoadCities()
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

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            login2Form form = new login2Form();
            form.Show();
        }

        public void changeValues()
        {
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.residentDetailsProc", Program.cs);
            dAdap.SelectCommand.Parameters.AddWithValue("@ID", residents.Text);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.Fill(table);
           

            
            firstname.Text = table.Rows[0][1].ToString();           
            lastname.Text = table.Rows[0][2].ToString();
            bd.Text = table.Rows[0][3].ToString();
            status.Text = table.Rows[0][5].ToString();
            city.Text = table.Rows[0][4].ToString();
        }
        private void delete_Click(object sender, EventArgs e)
        {
    

            DataTable table = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("dbo.ResEntitlesProc", Program.cs);
            da.SelectCommand.Parameters.AddWithValue("@ID", residents.Text);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(table);




            SqlConnection sqlCon = new SqlConnection(Program.cs);
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("dbo.UpdateProc", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", SqlDbType.VarChar).Value = residents.Text;
            cmd.Parameters.AddWithValue("@first", SqlDbType.VarChar).Value = firstname.Text;
            cmd.Parameters.AddWithValue("@last", SqlDbType.VarChar).Value = lastname.Text;
            cmd.Parameters.AddWithValue("@bd", SqlDbType.VarChar).Value = bd.Value.Date;           
            cmd.Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = status.Text;
            cmd.Parameters.AddWithValue("@city", SqlDbType.VarChar).Value = city.Text;
            

            cmd.ExecuteNonQuery();


            //delete
            foreach (DataRow row in table.Rows)
            {
                
                SqlCommand cmd2 = new SqlCommand("dbo.RemoveCatFromResProc", sqlCon);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@ID", SqlDbType.VarChar).Value = residents.Text;
                string sid = row["SerialNO"].ToString();
                Console.Write("SERIAL IS : --------------------11-1-1-1-1----------" + sid);
                System.Diagnostics.Debug.WriteLine("SERIAL IS : --------------------11-1-1-1-1----------" + sid);
                int toInt = Int32.Parse(sid);
                cmd2.Parameters.AddWithValue("@sid", SqlDbType.VarChar).Value = toInt;
                cmd2.ExecuteNonQuery();
            }

            addToCat();

            MessageBox.Show("Details Updated.");
            MessageBox.Show("Residents in Entitles Table were updated.");

            sqlCon.Close();
        }

        public void addToCat()
        {
            SqlConnection sqlCon = new SqlConnection(Program.cs);
            sqlCon.Open();
            DataTable table2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("dbo.OptionalEntForResident", Program.cs);
            da2.SelectCommand.Parameters.AddWithValue("@ID", residents.Text);
            da2.SelectCommand.CommandType = CommandType.StoredProcedure;
            da2.Fill(table2);



            foreach (DataRow row in table2.Rows)
            {

                SqlCommand cmd3 = new SqlCommand("dbo.addCatToResProc", sqlCon);
                cmd3.CommandType = CommandType.StoredProcedure;
                string serial = row["SerialNO"].ToString();
                int n = Int32.Parse(serial);
                cmd3.Parameters.AddWithValue("@ID", SqlDbType.VarChar).Value = residents.Text;
                cmd3.Parameters.AddWithValue("@sid", SqlDbType.VarChar).Value = n;
                cmd3.ExecuteNonQuery();

            }
        }

        private void residents_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
          
            changeValues();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
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
