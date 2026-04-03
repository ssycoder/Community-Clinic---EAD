using Communityclinic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Communityclinic.Models.PatientModels;

namespace Communityclinic
{
    public partial class PatientPortalForm : Form
    {
        private int patientId; // Store logged-in patient's ID

        public PatientPortalForm(int id)
        {
            InitializeComponent();
            patientId = id;

            // Wire up button events
            Update.Click += BtnUpdate_Click;
            Logout.Click += BtnLogout_Click;
        }

        // this is a Form Load event
        private void PatientPortalForm_Load(object sender, EventArgs e)
        {
            LoadPatientData();
        }

        // Load patient info from database
        private void LoadPatientData()
        {
            try
            {
                PatientDAL dal = new PatientDAL();
                PatientModels.Patient patient = dal.GetPatientByEmail(Email);

                if (patient == null)
                {
                    MessageBox.Show("Patient record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }


                // Fill textboxes with patient info
                txtName.Text = patient.Name;
                txtDOB.Text = patient.DateOfBirth.ToShortDateString();
                txtAge.Text = patient.Age.ToString();
                txtAddress.Text = patient.Address;
                txtPhonenumber.Text = patient.PhoneNumber;
                txtEmail.Text = patient.EmailAddress;
                txtGender.Text = patient.Gender;
                txtAllergies.Text = patient.Allergies;
                txtHistory.Text = patient.History;
                txtMedications.Text = patient.Medications;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patient data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Update button click
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                Patient patient = new Patient
                {
                   // Id = patientId, // important: keep the same patient ID
                    Name = txtName.Text.Trim(),
                    DateOfBirth = DateTime.Parse(txtDOB.Text),
                    Age = int.Parse(txtAge.Text),
                    Address = txtAddress.Text.Trim(),
                    PhoneNumber = txtPhonenumber.Text.Trim(),
                    EmailAddress = txtEmail.Text.Trim(),
                    Gender = txtGender.Text.Trim(),
                    Allergies = txtAllergies.Text.Trim(),
                    History = txtHistory.Text.Trim(),
                    Medications = txtMedications.Text.Trim()
                };

                PatientDAL dal = new PatientDAL();
                bool success = dal.UpdatePatient(patient);

                if (success)
                    MessageBox.Show("Your information has been updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Logout button click
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Close(); // closes portal and returns to login form
        }

        // Simple form validation
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (!DateTime.TryParse(txtDOB.Text, out DateTime dob))
            {
                MessageBox.Show("Date of Birth must be valid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDOB.Focus();
                return false;
            }

            if (!int.TryParse(txtAge.Text, out int age) || age <= 0)
            {
                MessageBox.Show("Age must be a positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAge.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhonenumber.Text))
            {
                MessageBox.Show("Phone number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhonenumber.Focus();
                return false;
            }

            if (!txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }
    }
}