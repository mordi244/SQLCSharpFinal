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
    public partial class ResidentPersonalForm : Form
    {
        private string resId;
        public ResidentPersonalForm(string resId)
        {
            InitializeComponent();
            this.resId = resId;
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
        private void ResidentPersonalForm_Load(object sender, EventArgs e)
        {
            changeLable();
            comboLoad();
                SqlConnection sql = new SqlConnection(Program.cs);
                sql.Open();
                DataTable table = new DataTable();
                SqlDataAdapter dAdap = new SqlDataAdapter("dbo.residentDetailsProc", sql);
                dAdap.SelectCommand.Parameters.AddWithValue("@id",this.resId);
                dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
                dAdap.Fill(table);
            System.Diagnostics.Debug.WriteLine("hereeee.."+table.Rows[0][1].ToString());
            System.Diagnostics.Debug.WriteLine("hereeee.." + table.Rows[0][5].ToString());
            status.Text = table.Rows[0][5].ToString();
                firstname.Text = table.Rows[0][1].ToString();
                lastname.Text = table.Rows[0][2].ToString();
                city.Text = table.Rows[0][4].ToString();
                bd.Text = table.Rows[0][3].ToString();

            
        }
        public void changeLable()
        {
            SqlConnection sqlCon = new SqlConnection(Program.cs);
            sqlCon.Open();
            DataTable dtbl = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("dbo.ResidentFullNameProc", sqlCon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@ID", this.resId);
            da.Fill(dtbl);
            string result = dtbl.Rows[0][0].ToString();
            lbl.Text = "Hello " + result;

        }

        private void btnUsersAndApps_Click(object sender, EventArgs e)
        {
            this.Hide();
            rafflesForm2 form = new rafflesForm2(this.resId);
            form.Show();
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            login2Form form = new login2Form();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResidentChartsForm form = new ResidentChartsForm(this.resId);
            form.Show();
        }

        private void add_Click(object sender, EventArgs e)
        {

            DataTable dtbl = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("dbo.ResEntitlesProc", Program.cs);
            da.SelectCommand.Parameters.AddWithValue("@ID", this.resId);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dtbl);




            SqlConnection sqlCon = new SqlConnection(Program.cs);
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("dbo.UpdateProc", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", SqlDbType.VarChar).Value = this.resId;
            cmd.Parameters.AddWithValue("@first", SqlDbType.VarChar).Value = firstname.Text;
            cmd.Parameters.AddWithValue("@last", SqlDbType.VarChar).Value = lastname.Text;
            cmd.Parameters.AddWithValue("@bd", SqlDbType.VarChar).Value = bd.Value.Date;
            cmd.Parameters.AddWithValue("@status", SqlDbType.VarChar).Value = status.Text;
            cmd.Parameters.AddWithValue("@city", SqlDbType.VarChar).Value = city.Text;


            cmd.ExecuteNonQuery();


            //delete
            foreach (DataRow row in dtbl.Rows)
            {



                SqlCommand cmd2 = new SqlCommand("dbo.RemoveCatFromResProc", sqlCon);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@ID", SqlDbType.VarChar).Value = this.resId;
                string sid = row["SerialNO"].ToString();
                Console.Write("SERIAL IS : --------------------11-1-1-1-1----------" + sid);
                System.Diagnostics.Debug.WriteLine("SERIAL IS : --------------------11-1-1-1-1----------" + sid);
                int numVal = Int32.Parse(sid);
                cmd2.Parameters.AddWithValue("@sid", SqlDbType.VarChar).Value = numVal;
                cmd2.ExecuteNonQuery();

            }



            addToCat();





            MessageBox.Show("Resident Details Updated Successduly");
            MessageBox.Show("Residents in Entitles Table were updated.");
            sqlCon.Close();
        }

        public void addToCat()
        {
            SqlConnection sqlCon = new SqlConnection(Program.cs);
            sqlCon.Open();
            DataTable dtbl2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("dbo.OptionalEntForResident", Program.cs);
            da2.SelectCommand.Parameters.AddWithValue("@ID", this.resId);
            da2.SelectCommand.CommandType = CommandType.StoredProcedure;
            da2.Fill(dtbl2);



            foreach (DataRow row in dtbl2.Rows)
            {




                SqlCommand cmd3 = new SqlCommand("dbo.addCatToResProc", sqlCon);
                cmd3.CommandType = CommandType.StoredProcedure;
                string serial = row["SerialNO"].ToString();
                int n = Int32.Parse(serial);
                cmd3.Parameters.AddWithValue("@ID", SqlDbType.VarChar).Value = this.resId;
                cmd3.Parameters.AddWithValue("@sid", SqlDbType.VarChar).Value = n;
                cmd3.ExecuteNonQuery();


            }
        }
    
    }
}
