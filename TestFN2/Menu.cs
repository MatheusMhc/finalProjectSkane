using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace TestFN2
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

            lblEasy.Visible = false;
            lblMedium.Visible = false;
            lblHard.Visible = false;
            lblBack.Visible = false;
            loadingProgress.Visible = false;
            lblAboutValue.Visible = false;
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
            enableDisableLabels(false);
        }

        private void lblEasy_MouseMove(object sender, MouseEventArgs e)
        {
            lblEasy.ForeColor = Color.Brown;
        }

        private void lblEasy_MouseLeave(object sender, EventArgs e)
        {
            lblEasy.ForeColor = Color.Black;
        }

        private void lblMedium_MouseMove(object sender, MouseEventArgs e)
        {
            lblMedium.ForeColor = Color.Brown;
        }

        private void lblMedium_MouseLeave(object sender, EventArgs e)
        {
            lblMedium.ForeColor = Color.Black;
        }

        private void lblHard_MouseMove(object sender, MouseEventArgs e)
        {
            lblHard.ForeColor = Color.Brown;
        }

        private void lblHard_MouseLeave(object sender, EventArgs e)
        {
            lblHard.ForeColor = Color.Black;
        }

        private void newGame(int interval)
        {
            var form2 = new Game(this, interval);
            form2.ShowDialog();
        }

        private void lblHard_Click(object sender, EventArgs e)
        {
            newGame(50);
        }

        private void lblMedium_Click(object sender, EventArgs e)
        {
            newGame(150);
        }

        private void lblEasy_Click(object sender, EventArgs e)
        {
            newGame(250);
        }

        private void lblBack_MouseLeave(object sender, EventArgs e)
        {
            lblBack.ForeColor = Color.Black;
        }

        private void lblBack_MouseMove(object sender, MouseEventArgs e)
        {
            lblBack.ForeColor = Color.Brown;
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            enableDisableLabels(true);
        }

        private void enableDisableLabels(bool value)
        {
            enableFirsScreenLabels(value);
            enableLevelLabels(!value);
            lblAboutValue.Visible = false;
        }

        private void enableFirsScreenLabels(bool value)
        {
            lblNewGame.Visible = value;
            lblAbout.Visible = value;
            lblExit.Visible = value;
        }

        private void enableLevelLabels(bool value)
        {
            lblEasy.Visible = value;
            lblMedium.Visible = value;
            lblHard.Visible = value;
            lblBack.Visible = value;
        }

        private void lblAbout_Click(object sender, EventArgs e)
        {
            enableFirsScreenLabels(false);
            lblBack.Visible = true;
            lblAboutValue.Visible = true;
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
