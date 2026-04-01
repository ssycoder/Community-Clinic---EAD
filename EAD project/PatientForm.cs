using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;

namespace EAD_project
{
    public partial class PatientForm : Form
    {
        public PatientForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string dob = txtDOB.Text;
            string age = txtAge.Text;
            string address = txtAddress.Text;
            string phone = txtPhoneNumber.Text;
            string email = txtEmailAddress.Text;
            string gender = txtGender.Text;
            string allergies = txtAllergies.Text;
            string history = txtMedicalHistory.Text;
            string meds = txtMedications.Text;

            MessageBox.Show("Record Saved!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InventoryForm inv = new InventoryForm();
            inv.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtDOB.Clear();
            txtAge.Clear();
            txtAddress.Clear();
            txtPhoneNumber.Clear();
            txtEmailAddress.Clear();
            txtGender.Clear();
            txtAllergies.Clear();
            txtMedicalHistory.Clear();
            txtMedications.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Record Updated!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;

            MessageBox.Show("Record Deleted!");
        }
    }
}
