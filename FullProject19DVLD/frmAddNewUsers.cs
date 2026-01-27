using BussnisProject;
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
    public partial class frmAddNewUsers : Form
    {
        public frmAddNewUsers()
        {
            InitializeComponent();
        }
        public delegate void DataBackEventHandler(object sender);
        public event DataBackEventHandler DataBack;

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this);
            this.Close();
        }

        private void personinfoByFilttiring1_Load(object sender, EventArgs e)
        {

        }
    }
}
