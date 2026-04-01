using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Communityclinic
{
    public partial class PatientListForm : Form
    {
        public PatientListForm()
        {
            InitializeComponent();
        }

        private void patientBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.patientBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.communityClinicLLOMDBDataSet);

        }

        private void PatientListForm_Load(object sender, EventArgs e)
        {
            //This line of code loads data into the 'communityClinicLLOMDBDataSet.Patient' table. You can move, or remove it, as needed.
            this.patientTableAdapter.Fill(this.communityClinicLLOMDBDataSet.Patient);

        }
    }
}
