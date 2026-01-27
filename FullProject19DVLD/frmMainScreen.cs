using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullProject19DVLD
{
    public partial class frmMainScreen : Form
    {
        public frmMainScreen()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMangedPeople fr=new frmMangedPeople();
            fr.ShowDialog();

        }

        private void frmMainScreen_Load(object sender, EventArgs e)
        {

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLoginScreen frmLoginScreen = new frmLoginScreen();
            frmLoginScreen.ShowDialog();
            
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMangedUser frm=new frmMangedUser();
            frm.ShowDialog();
        }

        private void chingePassowrdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlouble.UserID);
            frm.ShowDialog();
            
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserDatalis frm = new frmShowUserDatalis(clsGlouble.UserID);
            frm.ShowDialog();
        }

        private void mangeApplicToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mangeApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMangedAplicatinosTypes frm = new frmMangedAplicatinosTypes();    
            frm.ShowDialog();
        }

        private void mangeTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMangedTestTypes frm = new frmMangedTestTypes();
            frm.ShowDialog();
        }
    }
}
