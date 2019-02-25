using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class BuildingForm : Form
    {
        string conId;
        public BuildingForm(string conId)
        {
            InitializeComponent();
            this.conId = conId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            addBuildingForm form = new addBuildingForm(this.conId);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            consChartForm form = new consChartForm(this.conId);
            form.Show();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            projectsForm form = new projectsForm(this.conId);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewBuildingsForm form = new viewBuildingsForm(this.conId);
            form.Show();
        }
    }
}
