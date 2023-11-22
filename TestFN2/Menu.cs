using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFN2
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void lblNewGame_MouseMove(object sender, MouseEventArgs e)
        {
            lblNewGame.ForeColor = Color.Brown;
        }

        private void lblNewGame_MouseLeave(object sender, EventArgs e)
        {
            lblNewGame.ForeColor = Color.Black;
        }

        private void lblExit_MouseMove(object sender, MouseEventArgs e)
        {
            lblExit.ForeColor = Color.Brown;
        }

        private void lblExit_MouseLeave(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.Black;
        }

        private void lblAbout_MouseLeave(object sender, EventArgs e)
        {
            lblAbout.ForeColor = Color.Black;
        }

        private void lblAbout_MouseMove(object sender, MouseEventArgs e)
        {
            lblAbout.ForeColor = Color.Brown;
        }

        private void lblNewGame_MouseClick(object sender, MouseEventArgs e)
        {
            new Form1().Show();
            this.Hide();

        }


    }
}
