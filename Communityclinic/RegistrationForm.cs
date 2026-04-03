using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Net.Mail;

namespace Communityclinic
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
            private void btnRegister_Click(object sender, EventArgs e)
        {
            // Trims input
            string fullName = txtFullname.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmpassword.Text;

            // Validates fields
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(fullName)) errors.Add("Full Name is required");

            if (string.IsNullOrWhiteSpace(email))
                errors.Add("Email is required");
            else
            {
                try
                {
                    var addr = new MailAddress(email);
                }
                catch
                {
                    errors.Add("Enter a valid email address");
                }
            }

            if (string.IsNullOrWhiteSpace(password)) errors.Add("Password is required");
            else if (password.Length < 6) errors.Add("Password must be at least 6 characters");

            if (password != confirmPassword) errors.Add("Passwords do not match");

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors), "Validation Error");
                return;
            }

            // Hashes password
            string passwordHash = HashPassword(password);

            // Saves to SQL Server
            string connectionString = "Data Source=23.95.235.16;Initial Catalog=CommunityClinicLLOMDB;Integrated Security=True";
            string query = "INSERT INTO Users (FullName, Email, PasswordHash) VALUES (@FullName, @Email, @PasswordHash)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        // 5. Open Success form
                        SuccessForm successForm = new SuccessForm();

                        // Optional: pass user info to next form
                        // successForm.FullName = fullName;
                        // successForm.Email = email;

                        successForm.Show();
                        this.Hide(); // hide registration form
                    }
                    else
                    {
                        MessageBox.Show("Error saving registration.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }

        }
    }
}
