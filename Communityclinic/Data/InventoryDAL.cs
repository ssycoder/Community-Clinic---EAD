
using System;
using System.Data;
using System.Data.SqlClient;
using Communityclinic.Models;

namespace Communityclinic
{
    public class InventoryDAL
    {
      
        public bool InsertItem(InventoryItem item)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"INSERT INTO Inventory
                (Item, DateAdded, Quantity, Description, Price, Expiration,
                 Category, Unit, BatchNumber, Manufacturer, Supplier, Status, Notes)
                VALUES
                (@Item, @DateAdded, @Quantity, @Description, @Price, @Expiration,
                 @Category, @Unit, @BatchNumber, @Manufacturer, @Supplier, @Status, @Notes)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Item", item.Item);
                cmd.Parameters.AddWithValue("@DateAdded", item.DateAdded);
                cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                cmd.Parameters.AddWithValue("@Description", item.Description);
                cmd.Parameters.AddWithValue("@Price", item.Price);
                cmd.Parameters.AddWithValue("@Expiration", item.Expiration);
                cmd.Parameters.AddWithValue("@Category", item.Category);
                cmd.Parameters.AddWithValue("@Unit", item.Unit);
                cmd.Parameters.AddWithValue("@BatchNumber", item.BatchNumber);
                cmd.Parameters.AddWithValue("@Manufacturer", item.Manufacturer);
                cmd.Parameters.AddWithValue("@Supplier", item.Supplier);
                cmd.Parameters.AddWithValue("@Status", item.Status);
                cmd.Parameters.AddWithValue("@Notes", item.Notes);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        
        public void Update(InventoryItem item)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = @"UPDATE Inventory SET
                    Item=@Item,
                    DateAdded=@DateAdded,
                    Quantity=@Quantity,
                    Description=@Description,
                    Price=@Price,
                    Expiration=@Expiration,
                    Category=@Category,
                    Unit=@Unit,
                    BatchNumber=@BatchNumber,
                    Manufacturer=@Manufacturer,
                    Supplier=@Supplier,
                    Status=@Status,
                    Notes=@Notes
                    WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", item.Id);
                cmd.Parameters.AddWithValue("@Item", item.Item);
                cmd.Parameters.AddWithValue("@DateAdded", item.DateAdded);
                cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                cmd.Parameters.AddWithValue("@Description", item.Description);
                cmd.Parameters.AddWithValue("@Price", item.Price);
                cmd.Parameters.AddWithValue("@Expiration", item.Expiration);
                cmd.Parameters.AddWithValue("@Category", item.Category);
                cmd.Parameters.AddWithValue("@Unit", item.Unit);
                cmd.Parameters.AddWithValue("@BatchNumber", item.BatchNumber);
                cmd.Parameters.AddWithValue("@Manufacturer", item.Manufacturer);
                cmd.Parameters.AddWithValue("@Supplier", item.Supplier);
                cmd.Parameters.AddWithValue("@Status", item.Status);
                cmd.Parameters.AddWithValue("@Notes", item.Notes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

       
        public DataTable GetAll()
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT * FROM Inventory";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }

        
        public void Delete(int id)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM Inventory WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}