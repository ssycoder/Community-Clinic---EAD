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
            // Loads initial data if needed
        }

        // Save button click
        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Name is required");
                    txtName.Focus();
                    return;
                }

                if (!int.TryParse(txtAge.Text, out int age) || age <= 0)
                {
                    MessageBox.Show("Enter a valid age");
                    txtAge.Focus();
                    return;
                }

                if (!DateTime.TryParse(txtDOB.Text, out DateTime dob))
                {
                    MessageBox.Show("Enter a valid Date of Birth");
                    txtDOB.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPhonenumber.Text))
                {
                    MessageBox.Show("Phone number is required");
                    txtPhonenumber.Focus();
                    return;
                }

                if (!txtEmail.Text.Contains("@"))
                {
                    MessageBox.Show("Enter a valid email");
                    txtEmail.Focus();
                    return;
                }

                // Create patient object
                Patient patient = new Patient
                {
                    Name = txtName.Text.Trim(),
                    DateOfBirth = dob,
                    Age = age,
                    Address = txtAddress.Text.Trim(),
                    PhoneNumber = txtPhonenumber.Text.Trim(),
                    EmailAddress = txtEmail.Text.Trim(),
                    Gender = txtGender.Text.Trim(),
                    Allergies = txtAllergies.Text.Trim(),
                    History = txtHistory.Text.Trim(),
                    Medications = txtMedications.Text.Trim()
                };

                // Save to database
                PatientDAL dal = new PatientDAL();
                dal.UpdatePatient(patient); // or AddPatient depending on use

                MessageBox.Show("Patient saved successfully!");

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Update button click
        private void Update_Click(object sender, EventArgs e)
        {
            Save_Click(sender, e); // reuse of  save logic
        }

        // Name textbox change event
        private void txtName_TextChanged(object sender, EventArgs e)
        {
           
        }

        // Label click (prevents error)
        private void label1_Click(object sender, EventArgs e)
        {
            // Does nothing
        }

        // Clear button click
        private void Clear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // Helper method to clear all form fields
        private void ClearForm()
        {
            txtName.Clear();
            txtDOB.Clear();
            txtAge.Clear();
            txtAddress.Clear();
            txtPhonenumber.Clear();
            txtEmail.Clear();
            txtGender.Clear();
            txtAllergies.Clear();
            txtHistory.Clear();
            txtMedications.Clear();
        }
    }
}