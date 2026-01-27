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
    public partial class frmAddNewPeople : Form
    {
        
        public frmAddNewPeople()
        {
            InitializeComponent();
        }

        public delegate void DataBackEventHandler(object sender);
        public delegate void DataBackevent(object sender,int personId);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        public event DataBackevent DataBack1;


        private void addOrEditPresonInfo1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this);
            
            DataBack1?.Invoke(this, addOrEditPresonInfo1.personId);
            this.Close();
        }

        private void frmAddNewPeople_Load(object sender, EventArgs e)
        {

        }
    }
}
