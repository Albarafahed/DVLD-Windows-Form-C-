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
    public partial class frmUpdatePeople : Form
    {
        private int _personId = -1;
        public delegate void DataBackEventHandler(object sender);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        public delegate void DataBackEvent(object sender);

        // Declare an event using the delegate
        public event DataBackEvent DataBack1;
        public frmUpdatePeople(int PersonId)
        {
            _personId = PersonId;

            InitializeComponent();
        }

        private void frmUpdatePeople_Load(object sender, EventArgs e)
        {
            addOrEditPresonInfo1.loadPersonInfor(_personId);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this);
            DataBack1?.Invoke(this);
            this.Close();

        }
    }
}
