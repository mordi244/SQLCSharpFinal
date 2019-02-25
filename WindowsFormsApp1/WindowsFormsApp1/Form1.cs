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
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewResidentsForm form = new viewResidentsForm();
            form.Show();
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            login2Form form = new login2Form();
            form.Show();
        }

        private void add_Click(object sender, EventArgs e)
        {
            this.Hide();
            addResidentsForm form = new addResidentsForm();
            form.Show();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {
            this.Hide();
            updateDetailsForm form = new updateDetailsForm();
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
