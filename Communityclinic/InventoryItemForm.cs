using Communityclinic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

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

            item.Item = txtItem.Text;
            item.DateAdded = DateTime.Parse(txtDateAdded.Text); // or DateTime.Now if you prefer
            item.Quantity = int.Parse(txtQuantity.Text);
            item.Description = txtDescription.Text;
            item.Price = decimal.Parse(txtPrice.Text);
            item.Expiration = DateTime.Parse(txtExpiration.Text);
            item.Category = txtCategory.Text;
            item.Unit = txtUnit.Text;
            item.BatchNumber = txtBatchNumber.Text;
            item.Manufacturer = txtManufacturer.Text;
            item.Supplier = txtSupplier.Text;
            item.Status = txtStatus.Text;
            item.Notes = txtNotes.Text;

            return item;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
   private void btn1_Click(object sender, EventArgs e)
        {
            InventoryItem item = GetFormData();
            if (item != null)
            {
                InventoryDAL dal = new InventoryDAL();
                dal.Insert(item);
                MessageBox.Show("Saved!");
            }
        }
    }
