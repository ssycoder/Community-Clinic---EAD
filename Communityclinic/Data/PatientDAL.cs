using Communityclinic;
using System;
using System.Data;
using System.Data.SqlClient;
using static Communityclinic.Models.PatientModels;

namespace Communityclinic
{
    internal class PatientDAL
    {
        // Add a new patient
        public void AddPatient(Patient patient)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"INSERT INTO Patient 
                                (Name, DateOfBirth, Age, Address, PhoneNumber, EmailAddress, Gender, Allergies, History, Medications)
                                VALUES 
                                (@Name, @DateOfBirth, @Age, @Address, @PhoneNumber, @EmailAddress, @Gender, @Allergies, @History, @Medications)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Name", patient.Name);
                cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                cmd.Parameters.AddWithValue("@Age", patient.Age);
                cmd.Parameters.AddWithValue("@Address", patient.Address);
                cmd.Parameters.AddWithValue("@PhoneNumber", patient.PhoneNumber);
                cmd.Parameters.AddWithValue("@EmailAddress", patient.EmailAddress);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@Allergies", patient.Allergies);
                cmd.Parameters.AddWithValue("@History", patient.History);
                cmd.Parameters.AddWithValue("@Medications", patient.Medications);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Update an existing patient
        public void UpdatePatient(Patient patient)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"UPDATE Patient 
                                 SET Name=@Name, 
                                     DateOfBirth=@DateOfBirth, 
                                     Age=@Age, 
                                     Address=@Address, 
                                     PhoneNumber=@PhoneNumber, 
                                     EmailAddress=@EmailAddress, 
                                     Gender=@Gender, 
                                     Allergies=@Allergies, 
                                     History=@History, 
                                     Medications=@Medications
                                 WHERE Id=@Id"; // make sure your Patient table has Id as primary key

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Name", patient.Name);
                cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                cmd.Parameters.AddWithValue("@Age", patient.Age);
                cmd.Parameters.AddWithValue("@Address", patient.Address);
                cmd.Parameters.AddWithValue("@PhoneNumber", patient.PhoneNumber);
                cmd.Parameters.AddWithValue("@EmailAddress", patient.EmailAddress);
                cmd.Parameters.AddWithValue("@Gender", patient.Gender);
                cmd.Parameters.AddWithValue("@Allergies", patient.Allergies);
                cmd.Parameters.AddWithValue("@History", patient.History);
                cmd.Parameters.AddWithValue("@Medications", patient.Medications);
                

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Retrieve all patients
        public DataTable GetPatients()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Patient";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();

                da.Fill(dt);
                return dt;
            }
        }
    }
}