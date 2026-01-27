using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FullProject19DVLD.frmUpdatePeople;

namespace FullProject19DVLD
{
    public partial class frmUpdateUser : Form
    {
       private int _UserId=-1;
        public delegate void DataBackEvent(object sender);
        public event DataBackEvent DataBack;

        public frmUpdateUser(int UserId)
        {
            _UserId=UserId;
           
            InitializeComponent();
            addOrUpdateUserControl1.UpdateUser(_UserId);
        }

        private void frmUpdateUser_Load(object sender, EventArgs e)
        {
          

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this);
            this.Close();

        }
    }
}
