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
    public partial class login2Form : Form
    {
        private String t;
        private char x;
        public login2Form()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(Program.cs);
            sql.Open();
            DataTable table = new DataTable();
            SqlDataAdapter dAdap = new SqlDataAdapter("dbo.login", sql);
            dAdap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAdap.SelectCommand.Parameters.AddWithValue("@user", user.Text.Trim());
            dAdap.SelectCommand.Parameters.AddWithValue("@pass", pass.Text.Trim());
            dAdap.Fill(table);

            if (table.Rows.Count == 1)
            {
             string t = table.Rows[0][1].ToString();
            

                try
                {
                    switch (t)
                    {
                        case "a":
                            this.Hide();
                            AdminMainForm admin = new AdminMainForm();
                            admin.Show();
                            break;
                        case "c":
                            this.Hide();
                            constractorMenuForm con = new constractorMenuForm(user.Text);
                            con.Show();
                            break;
                        case "r":
                            this.Hide();
                            ResidentMainForm r = new ResidentMainForm(user.Text);
                            r.Show();
                            break;
                    }
                }
                catch
                {
                    MessageBox.Show("Wrong password/user name.");
                }

            }
        }
    }
}
