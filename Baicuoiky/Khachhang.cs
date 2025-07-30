using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; // Required for SQL Server interaction
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baicuoiky
{
    public partial class Khachhang : Form
    {
        // IMPORTANT: Replace with your actual SQL Server connection string
        private string connectionString = "Data Source=VINCENT\\SQLEXPRESS;Initial Catalog=ShopApp;Integrated Security=True;";
        // Or if using SQL Server authentication:
        // private string connectionString = "Data Source=YOUR_SERVER_NAME;Initial Catalog=YOUR_DATABASE_NAME;User ID=your_user;Password=your_password;";

        private List<CustomerModel> customerList = new List<CustomerModel>();
        private int selectedCustomerId = -1;

        public Khachhang()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Khachhang_Load);
        }

        private void Khachhang_Load(object sender, EventArgs e)
        {
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            LoadCustomerDataFromDatabase();
            DisplayCustomerData();
        }

        // Data model for a customer
        private class CustomerModel
        {
            public int CustomerID { get; set; }
            public string CustomerName { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
        }

        private void LoadCustomerDataFromDatabase()
        {
            customerList.Clear(); // Clear existing list

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT CustomerID, CustomerName, Address, PhoneNumber FROM Customers ORDER BY CustomerName"; // Assuming table name is Customers
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customerList.Add(new CustomerModel
                                {
                                    CustomerID = Convert.ToInt32(reader["CustomerID"]),
                                    CustomerName = reader["CustomerName"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    PhoneNumber = reader["PhoneNumber"].ToString()
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error loading customer data from database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DisplayCustomerData()
        {
            kryptonDataGridView1.Rows.Clear();

            foreach (var customer in customerList)
            {
                kryptonDataGridView1.Rows.Add(customer.CustomerID, customer.CustomerName, customer.Address, customer.PhoneNumber);
            }

            kryptonDataGridView1.ClearSelection();
            ClearInputFields();
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            selectedCustomerId = -1;
        }

        private void ClearInputFields()
        {
            txtCustomerName.Content = "";
            txtPhoneNumber.Content = "";
            txtAddress.Content = "";
        }

        private void kryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < kryptonDataGridView1.Rows.Count && !kryptonDataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow selectedRow = kryptonDataGridView1.Rows[e.RowIndex];

                txtCustomerName.Content = selectedRow.Cells["CustomerName"].Value?.ToString() ?? "";
                txtPhoneNumber.Content = selectedRow.Cells["PhoneNumber"].Value?.ToString() ?? "";
                txtAddress.Content = selectedRow.Cells["Address"].Value?.ToString() ?? "";

                if (selectedRow.Cells["CustomerID"].Value != null && int.TryParse(selectedRow.Cells["CustomerID"].Value.ToString(), out int custId))
                {
                    selectedCustomerId = custId;
                }
                else
                {
                    selectedCustomerId = -1;
                }

                btnEdit.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                ClearInputFields();
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                selectedCustomerId = -1;
                kryptonDataGridView1.ClearSelection();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            selectedCustomerId = -1;
            kryptonDataGridView1.ClearSelection();

            LoadCustomerDataFromDatabase(); // Reload data from DB
            DisplayCustomerData(); // Refresh the grid

            MessageBox.Show("Data refreshed from database.", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1)
            {
                MessageBox.Show("Please select a customer from the list to edit.", "No Customer Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate input fields (optional, but good practice)
            if (string.IsNullOrWhiteSpace(txtCustomerName.Content))
            {
                MessageBox.Show("Customer name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus(); // Assuming Focus() works for cuiTextBox
                return;
            }
            // Add more validation for phone, address if needed

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Customers SET CustomerName = @Name, PhoneNumber = @Phone, Address = @Address WHERE CustomerID = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", txtCustomerName.Content.Trim());
                    command.Parameters.AddWithValue("@Phone", txtPhoneNumber.Content.Trim());
                    command.Parameters.AddWithValue("@Address", txtAddress.Content.Trim());
                    command.Parameters.AddWithValue("@ID", selectedCustomerId);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCustomerDataFromDatabase(); // Reload data
                            DisplayCustomerData();          // Refresh grid
                        }
                        else
                        {
                            MessageBox.Show("No customer found with the selected ID, or data was unchanged.", "Update Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error updating customer: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1)
            {
                MessageBox.Show("Please select a customer from the list to delete.", "No Customer Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmation = MessageBox.Show($"Are you sure you want to delete customer '{txtCustomerName.Content}' (ID: {selectedCustomerId})?",
                                                        "Confirm Delete",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Customers WHERE CustomerID = @ID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", selectedCustomerId);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show($"Customer '{txtCustomerName.Content}' deleted successfully.", "Customer Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadCustomerDataFromDatabase(); // Reload data
                                DisplayCustomerData();          // Refresh grid
                            }
                            else
                            {
                                MessageBox.Show("No customer found with the selected ID.", "Delete Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (SqlException ex)
                        {
                            // Handle foreign key constraint violations if this customer is referenced elsewhere
                            if (ex.Number == 547) // SQL Server error code for foreign key violation
                            {
                                MessageBox.Show("Cannot delete this customer as they are referenced in other records (e.g., orders).", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("Error deleting customer: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonDataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
    }
}