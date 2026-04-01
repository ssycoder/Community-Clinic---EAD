using Communityclinic.Models;
using System;
using System.Text;
using System.Windows.Forms;

namespace Communityclinic
{
    public partial class InventoryItemForm : Form
    {
        public InventoryItemForm()
        {
            InitializeComponent();
        }

        
        private InventoryItem GetFormData()
        {
            InventoryItem item = new InventoryItem();

            item.Item = txtItem.Text.Trim();
            item.DateAdded = DateTime.Parse(txtDateAdded.Text); 
            item.Quantity = int.Parse(txtQuantity.Text);        
            item.Description = txtDescription.Text.Trim();
            item.Price = decimal.Parse(txtPrice.Text);          
            item.Expiration = DateTime.Parse(txtExpiration.Text);
            item.Category = txtCategory.Text.Trim();
            item.Unit = txtUnit.Text.Trim();
            item.BatchNumber = txtBatchNumber.Text.Trim();
            item.Manufacturer = txtManufacturer.Text.Trim();
            item.Supplier = txtSupplier.Text.Trim();
            item.Status = txtStatus.Text.Trim();
            item.Notes = txtNotes.Text.Trim();

            return item;
        }

        
        private bool ValidateForm()
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(txtItem.Text))
                errors.AppendLine("Item name is required.");

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity < 0)
                errors.AppendLine("Quantity must be a positive number.");

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
                errors.AppendLine("Price must be a positive number.");

            if (!DateTime.TryParse(txtDateAdded.Text, out _))
                errors.AppendLine("Date Added must be a valid date.");

            if (!DateTime.TryParse(txtExpiration.Text, out _))
                errors.AppendLine("Expiration must be a valid date.");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        
        private void btn1_Click(object sender, EventArgs e)
        {
            
            if (!ValidateForm())
                return;

            try
            {
                InventoryItem item = GetFormData();
                InventoryDAL dal = new InventoryDAL();
                bool success = dal.InsertItem(item);

                if (success)
                    MessageBox.Show("Item saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Error saving item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}