using Communityclinic.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using static Communityclinic.Models.PatientModels;

namespace Communityclinic
{
    public class PatientDAL
    {
        /// <summary>
        /// Add a new patient to the database.
        /// </summary>
        public bool AddPatient(Patient patient)
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
                return cmd.ExecuteNonQuery() > 0; // returns true if inserted
            }
        }

        
        /// Update an existing patient. Returns true if updated successfully.
       
        public bool UpdatePatient(Patient patient)
        {
           // if patient.EmailAddress
               // throw new ArgumentException("Patient ID is required for update.");

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"UPDATE Patient SET
                                    Name=@Name,
                                    DateOfBirth=@DateOfBirth,
                                    Age=@Age,
                                    Address=@Address,
                                    PhoneNumber=@PhoneNumber,
                                    EmailAddress=@EmailAddress,
                                    Gender=@Gender,
                                    Allergies=@Allergies,
                                    History=@History,
                                    Medications=@Medications
                                 WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                //cmd.Parameters.AddWithValue("@Id", patient.Id);
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
                return cmd.ExecuteNonQuery() > 0; // returns true if rows were affected
            }
        }

        
        /// Get a patient by email
        public Patient GetPatientByEmail(string email)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Patient WHERE EmailAddress=@Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return MapReaderToPatient(reader);
                    else
                        return null;
                }
            }
        }

        /// <summary>
        /// Retrieve all patients (optional)
        /// </summary>
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

        
        // Helper: maps SqlDataReader row to Patient object
     
        private Patient MapReaderToPatient(SqlDataReader reader)
        {
            return new Patient
            {
               // Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                DateOfBirth = (DateTime)reader["DateOfBirth"],
                Age = (int)reader["Age"],
                Address = reader["Address"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString(),
                EmailAddress = reader["EmailAddress"].ToString(),
                Gender = reader["Gender"].ToString(),
                Allergies = reader["Allergies"].ToString(),
                History = reader["History"].ToString(),
                Medications = reader["Medications"].ToString()
            };
        }
    }
}