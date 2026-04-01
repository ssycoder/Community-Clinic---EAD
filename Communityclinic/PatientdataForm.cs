using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Communityclinic.Models.PatientModels;


namespace Communityclinic
{
    public partial class PatientdataForm : Form
    {
        public PatientdataForm()
        {
            InitializeComponent();
        }

        private void PatientdataForm_Load(object sender, EventArgs e)
        {
            // Optional: initialize DateTimePicker to today
            dtpDOB.Value = DateTime.Today;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate Age
                if (!int.TryParse(txtAge.Text, out int age))
                {
                    MessageBox.Show("Enter a valid age");
                    return;
                }

                // Create Patient object
                Patient patient = new Patient
                {
       
                    Name = txtName.Text,
                    DateOfBirth = dtpDOB.Value, // DateTimePicker provides DateTime
                    Age = age,
                    Address = txtAddress.Text,
                    PhoneNumber = txtPhonenumber.Text,
                    EmailAddress = txtEmail.Text,
                    Gender = txtGender.Text,
                    Allergies = txtAllergies.Text,
                    History = txtHistory.Text,
                    Medications = txtMedications.Text
                };

                // Call DAL to update patient
                PatientDAL dal = new PatientDAL();
                dal.UpdatePatient(patient);

                MessageBox.Show("Patient saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Optional: Clear form fields
        private void btnClear_Click(object sender, EventArgs e)
        {
            
            txtName.Text = "";
            dtpDOB.Value = DateTime.Today;
            txtAge.Text = "";
            txtAddress.Text = "";
            txtPhonenumber.Text = "";
            txtEmail.Text = "";
            txtGender.Text = "";
            txtAllergies.Text = "";
            txtHistory.Text = "";
            txtMedications.Text = "";
        }
    }
}