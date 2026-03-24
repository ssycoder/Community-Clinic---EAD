using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EAD_project
{
    public partial class InventoryForm : Form
    {
        public class InventoryItem
        {
            public string? ItemName { get; set; }
            public int Quantity { get; set; }
        }

        public InventoryForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Inventory information submitted successfully!", "Submission", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
