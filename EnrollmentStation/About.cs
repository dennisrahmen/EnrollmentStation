using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnrollmentStation
{
    public partial class About : MetroForm
    {
        public About()
        {
            InitializeComponent();
        }

        private void link_old_project_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/CSIS/EnrollmentStation");
        }

        private void link_new_project_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/jnsgsbz/EnrollmentStation");
        }

        private void fechter_link_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/scVENUS/EnrollmentStation");
        }
    }
}
