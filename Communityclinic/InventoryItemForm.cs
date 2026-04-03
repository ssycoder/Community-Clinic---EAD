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

            // Wire up button events with clear names
            Save.Click += BtnSave_Click;
            Clear.Click += BtnClear_Click;
            Update.Click += BtnUpdate_Click;
        }

        // Retrieve form data into InventoryItem object
        private InventoryItem GetFormData()
        {
            InventoryItem item = new InventoryItem();

            item.Item = txtItem.Text.Trim();

            DateTime.TryParse(txtDateAdded.Text, out DateTime dateAdded);
            item.DateAdded = dateAdded;

            int.TryParse(txtQuantity.Text, out int quantity);
            item.Quantity = quantity;

            item.Description = txtDescription.Text.Trim();

            decimal.TryParse(txtPrice.Text, out decimal price);
            item.Price = price;

            DateTime.TryParse(txtExpiration.Text, out DateTime expiration);
            item.Expiration = expiration;

            item.Category = txtCategory.Text.Trim();
            item.Unit = txtUnit.Text.Trim();
            item.BatchNumber = txtBatchNumber.Text.Trim();
            item.Manufacturer = txtManufacturer.Text.Trim();
            item.Supplier = txtSupplier.Text.Trim();
            item.Status = txtStatus.Text.Trim();
            item.Notes = txtNotes.Text.Trim();

            return item;
        }

        // Validates the form fields
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

        // Save button click
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                InventoryItem item = GetFormData();
                InventoryDAL dal = new InventoryDAL();
                bool success = dal.InsertItem(item);

                MessageBox.Show(
                    success ? "Item saved successfully!" : "Error saving item.",
                    success ? "Success" : "Error",
                    MessageBoxButtons.OK,
                    success ? MessageBoxIcon.Information : MessageBoxIcon.Error
                );

                if (success) ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Clear button click
        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // Update button click
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                InventoryItem item = GetFormData();
                InventoryDAL dal = new InventoryDAL();
                dal.Update(item); // Calling data from DAL to update the item

                MessageBox.Show("Item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // this Clears all fields
        private void ClearForm()
        {
            txtItem.Text = "";
            txtDateAdded.Text = "";
            txtQuantity.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtExpiration.Text = "";
            txtCategory.Text = "";
            txtUnit.Text = "";
            txtBatchNumber.Text = "";
            txtManufacturer.Text = "";
            txtSupplier.Text = "";
            txtStatus.Text = "";
            txtNotes.Text = "";
        }

        
        private void label9_Click(object sender, EventArgs e) { 
        //does absolutely nothing but makes error go away
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // does nothing
        }
        private void label6_Click(object sender, EventArgs e)
        {
            // Does nothing
        }
    }
}