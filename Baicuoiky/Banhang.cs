using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit; 

namespace Baicuoiky
{
    public partial class Banhang : Form
    {
        private string connectionString = "Data Source=VINCENT\\SQLEXPRESS;Initial Catalog=ShopApp;Integrated Security=True;";

        private List<ProductModel> availableProducts = new List<ProductModel>();
        private List<CustomerModel> existingCustomers = new List<CustomerModel>();
        private ProductModel currentSelectedProduct = null;
        private BindingList<CartItemModel> cartItems = new BindingList<CartItemModel>();

        public Banhang()
        {
            InitializeComponent();
            this.Load += Banhang_Load;

            cboProduct.SelectedIndexChanged += CboProduct_SelectedIndexChanged;
            numQuantity.ValueChanged += NumQuantity_ValueChanged;

            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnRefresh.Click += BtnRefresh_Click;
            kryptonDataGridView1.CellClick += KryptonDataGridView1_CellClick;

            cbo1.SelectedIndexChanged += Cbo1_Customer_SelectedIndexChanged; 
            cuiTextBox1.Leave += CuiTextBox1_PhoneNumber_Leave; 
            btnLogin.Click += BtnLogin_Pay_Click;
            pbBack.Click += PbBack_Click;

            this.FormClosing += Banhang_FormClosing;

            kryptonDataGridView1.AutoGenerateColumns = false;
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductName.DataPropertyName = "ItemName";
            this.Quantity.DataPropertyName = "Quantity";
            this.Price.DataPropertyName = "UnitPrice";
            this.TotalPrice.DataPropertyName = "TotalPrice";
            kryptonDataGridView1.DataSource = cartItems;
        }

        private void Banhang_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Load -= Banhang_Load;

            if (cboProduct != null) cboProduct.SelectedIndexChanged -= CboProduct_SelectedIndexChanged;
            if (numQuantity != null) numQuantity.ValueChanged -= NumQuantity_ValueChanged;
            if (btnAdd != null) btnAdd.Click -= BtnAdd_Click;
            if (btnDelete != null) btnDelete.Click -= BtnDelete_Click;
            if (btnRefresh != null) btnRefresh.Click -= BtnRefresh_Click;
            if (kryptonDataGridView1 != null) kryptonDataGridView1.CellClick -= KryptonDataGridView1_CellClick;

            if (cbo1 != null) cbo1.SelectedIndexChanged -= Cbo1_Customer_SelectedIndexChanged;

            if (cuiTextBox1 != null) cuiTextBox1.Leave -= CuiTextBox1_PhoneNumber_Leave;
            if (btnLogin != null) btnLogin.Click -= BtnLogin_Pay_Click;
            if (pbBack != null) pbBack.Click -= PbBack_Click;
        }

        private void Banhang_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCustomers_Manual();
            ClearProductSelectionFields();
            ClearCustomerFields_Manual();
            btnDelete.Enabled = false;
            numQuantity.Value = 0;
            numQuantity.Minimum = 0;
            numQuantity.Maximum = 1000;
        }

        #region Data Models
        private class ProductModel
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public decimal Price { get; set; }
            public int AvailableQuantity { get; set; }
            public byte[] ProductImageData { get; set; }
            public override string ToString() => ProductName;
        }

        private class CustomerModel
        {
            public int CustomerID { get; set; }
            public string CustomerName { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
            public override string ToString() => $"{CustomerName} ({PhoneNumber})";
        }

        private class CartItemModel
        {
            public int ProductID { get; set; }
            public string ItemName { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal TotalPrice => Quantity * UnitPrice;
        }
        #endregion

        #region Product Section Logic
        private void LoadProducts()
        {
            availableProducts.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductID, ProductName, Price, Quantity, ProductImage FROM Products WHERE Quantity > 0 ORDER BY ProductName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            byte[] imageData = reader["ProductImage"] != DBNull.Value ? (byte[])reader["ProductImage"] : null;
                            availableProducts.Add(new ProductModel
                            {
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                ProductName = reader["ProductName"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]),
                                AvailableQuantity = Convert.ToInt32(reader["Quantity"]),
                                ProductImageData = imageData
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            cboProduct.DataSource = null;
            cboProduct.DataSource = availableProducts; 
            cboProduct.DisplayMember = "ProductName";
            cboProduct.ValueMember = "ProductID"; 
           
        }

        private void CboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
     
            if (cboProduct.SelectedItem is ProductModel selected)
            {
                currentSelectedProduct = selected;
                txtProductName.Content = selected.ProductName;
                txtPrice.Content = selected.Price.ToString("N2");
                numQuantity.Minimum = 0;
                numQuantity.Maximum = selected.AvailableQuantity > 0 ? selected.AvailableQuantity : 0;
                numQuantity.Value = 0; 

                pictureBox2.Image = null;
                if (selected.ProductImageData != null && selected.ProductImageData.Length > 0)
                {
                    try { using (MemoryStream ms = new MemoryStream(selected.ProductImageData)) { pictureBox2.Image = Image.FromStream(ms); } pictureBox2.SizeMode = PictureBoxSizeMode.Zoom; }
                    catch { pictureBox2.Image = null; }
                }
                UpdateCurrentItemTotalPrice();
            }
            else if (cboProduct.SelectedIndex == -1) 
            {
            }
        }

        private void NumQuantity_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentItemTotalPrice();
        }

        private void UpdateCurrentItemTotalPrice()
        {
            if (currentSelectedProduct != null && numQuantity.Value > 0)
            {
                txtTotalPrice.Content = (currentSelectedProduct.Price * numQuantity.Value).ToString("N2");
            }
            else
            {
                txtTotalPrice.Content = "0.00";
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (currentSelectedProduct == null) { MessageBox.Show("Please select a product.", "No Product", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            int quantityToAdd = (int)numQuantity.Value;
            if (quantityToAdd <= 0) { MessageBox.Show("Quantity must be > 0.", "Invalid Qty", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (quantityToAdd > currentSelectedProduct.AvailableQuantity) { MessageBox.Show($"Only {currentSelectedProduct.AvailableQuantity} of {currentSelectedProduct.ProductName} available.", "Stock Low", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            var existingCartItem = cartItems.FirstOrDefault(item => item.ProductID == currentSelectedProduct.ProductID);
            if (existingCartItem != null)
            {
                if (existingCartItem.Quantity + quantityToAdd > currentSelectedProduct.AvailableQuantity) { MessageBox.Show("Total quantity would exceed stock.", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                existingCartItem.Quantity += quantityToAdd;
                var temp = kryptonDataGridView1.DataSource; kryptonDataGridView1.DataSource = null; kryptonDataGridView1.DataSource = temp; // Refresh
            }
            else
            {
                cartItems.Add(new CartItemModel { ProductID = currentSelectedProduct.ProductID, ItemName = currentSelectedProduct.ProductName, Quantity = quantityToAdd, UnitPrice = currentSelectedProduct.Price });
            }
            numQuantity.Value = 0;
        }

        private void KryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = (e.RowIndex >= 0 && e.RowIndex < cartItems.Count);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (kryptonDataGridView1.CurrentRow != null && kryptonDataGridView1.CurrentRow.Index < cartItems.Count)
            {
                cartItems.RemoveAt(kryptonDataGridView1.CurrentRow.Index);
                btnDelete.Enabled = false;
                kryptonDataGridView1.ClearSelection();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            ClearProductSelectionFields(true);
            ClearCustomerFields_Manual(true);
        }

        private void ClearProductSelectionFields(bool clearComboBox = true)
        {
            if (clearComboBox)
            {
               
                cboProduct.SelectedIndexChanged -= CboProduct_SelectedIndexChanged;
                cboProduct.DataSource = null;
                cboProduct.Items.Clear();
                cboProduct.DataSource = availableProducts; 
                cboProduct.SelectedIndex = -1;
               
                cboProduct.SelectedIndexChanged += CboProduct_SelectedIndexChanged;
            }
            txtProductName.Content = "";
            txtPrice.Content = "";
            numQuantity.Value = 0;
            txtTotalPrice.Content = "0.00";
            pictureBox2.Image = null;
            currentSelectedProduct = null;
        }
        #endregion

        #region Customer & Payment Section Logic
        private void LoadCustomers_Manual()
        {
            existingCustomers.Clear();
            

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT CustomerID, CustomerName, Address, PhoneNumber FROM Customers ORDER BY CustomerName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            existingCustomers.Add(new CustomerModel 
                            {
                                CustomerID = Convert.ToInt32(reader["CustomerID"]),
                                CustomerName = reader["CustomerName"].ToString(),
                                Address = reader["Address"]?.ToString(),
                                PhoneNumber = reader["PhoneNumber"]?.ToString()
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading customers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
      
            cbo1.DataSource = null;
            cbo1.DataSource = existingCustomers; 
            cbo1.DisplayMember = "CustomerName";    
            cbo1.ValueMember = "CustomerID";     
            cbo1.SelectedIndex = -1;               
        }

      
        private void Cbo1_Customer_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbo1.SelectedItem is CustomerModel selectedCustomer)
            {
                lblUserName.Content = selectedCustomer.CustomerName;
                lblPassword.Content = selectedCustomer.Address; 
                cuiTextBox1.Content = selectedCustomer.PhoneNumber;
            }
            else if (cbo1.SelectedIndex == -1) 
            {
            }
        }

        private void CuiTextBox1_PhoneNumber_Leave(object sender, EventArgs e)
        {
            string phoneNumber = cuiTextBox1.Content.Trim();
            if (string.IsNullOrWhiteSpace(phoneNumber)) return;

            var existingCustomer = existingCustomers.FirstOrDefault(c => c.PhoneNumber == phoneNumber);
            if (existingCustomer != null)
            {
                MessageBox.Show("This phone number belongs to an existing customer. Details loaded.", "Customer Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

      
                cbo1.SelectedIndexChanged -= Cbo1_Customer_SelectedIndexChanged;
                cbo1.SelectedItem = existingCustomer; 
                cbo1.SelectedIndexChanged += Cbo1_Customer_SelectedIndexChanged;
            }
        }

        private void ClearCustomerFields_Manual(bool clearComboBoxSelection = true)
        {
            if (clearComboBoxSelection)
            {
                cbo1.SelectedIndexChanged -= Cbo1_Customer_SelectedIndexChanged; 
                cbo1.DataSource = null;
                cbo1.Items.Clear();
                cbo1.DataSource = existingCustomers;
                cbo1.SelectedIndex = -1;
                cbo1.SelectedIndexChanged += Cbo1_Customer_SelectedIndexChanged; 
            }
            lblUserName.Content = "";
            lblPassword.Content = "";
            cuiTextBox1.Content = "";
        }

        private void BtnLogin_Pay_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0) { MessageBox.Show("Cart is empty.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            string custName = lblUserName.Content.Trim();
            string custAddress = lblPassword.Content.Trim();
            string custPhone = cuiTextBox1.Content.Trim();

            if (string.IsNullOrWhiteSpace(custName) || string.IsNullOrWhiteSpace(custPhone)) { MessageBox.Show("Customer name and phone are required.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            DialogResult payConfirmation = MessageBox.Show($"Total: {cartItems.Sum(item => item.TotalPrice):N2}\nProceed?", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (payConfirmation == DialogResult.No) return;

            int customerId = -1;
            CustomerModel identifiedCustomer = cbo1.SelectedItem as CustomerModel;

            if (identifiedCustomer != null)
            {
                customerId = identifiedCustomer.CustomerID;

                if (identifiedCustomer.CustomerName != custName || identifiedCustomer.Address != custAddress || identifiedCustomer.PhoneNumber != custPhone)
                {
                    if (identifiedCustomer.PhoneNumber != custPhone)
                    {
                        var customerByNewPhone = GetCustomerByPhoneNumber(custPhone); 
                        if (customerByNewPhone != null && customerByNewPhone.CustomerID != customerId)
                        {
                            MessageBox.Show($"Phone {custPhone} exists for another customer. Resolve conflict.", "Phone Conflict", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    UpdateCustomer(customerId, custName, custAddress, custPhone); 
                    var customerInList = existingCustomers.FirstOrDefault(c => c.CustomerID == customerId);
                    if (customerInList != null)
                    {
                        customerInList.CustomerName = custName;
                        customerInList.Address = custAddress;
                        customerInList.PhoneNumber = custPhone;
                        int selectedIdx = cbo1.SelectedIndex;
                        cbo1.DataSource = null;
                        cbo1.DataSource = existingCustomers;
                        cbo1.SelectedIndex = selectedIdx;
                    }
                }
            }
            else 
            {
                var customerByPhoneInTextbox = GetCustomerByPhoneNumber(custPhone); 
                if (customerByPhoneInTextbox != null)
                {
                    customerId = customerByPhoneInTextbox.CustomerID;
                    if (customerByPhoneInTextbox.CustomerName != custName || customerByPhoneInTextbox.Address != custAddress)
                    {
                        UpdateCustomer(customerId, custName, custAddress, custPhone);
                        var customerInList = existingCustomers.FirstOrDefault(c => c.CustomerID == customerId);
                        if (customerInList != null) { /* ... update list ... */ }
                    }
                }
                else
                {
                    customerId = AddNewCustomer(custName, custAddress, custPhone);
                    if (customerId != -1) LoadCustomers_Manual();
                    else { MessageBox.Show("Could not add new customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                }
            }

            if (customerId == -1) { MessageBox.Show("Could not determine customer.", "Customer Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            int billId = SaveBill(customerId, cartItems.Sum(item => item.TotalPrice));
            if (billId != -1)
            {
                if (SaveBillDetails(billId))
                {
                    UpdateProductStock();
                    MessageBox.Show("Payment successful! Bill saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cartItems.Clear();
                    ClearProductSelectionFields(true);
                    ClearCustomerFields_Manual(true); 
                    LoadProducts(); 
                    btnDelete.Enabled = false;
                }
                else MessageBox.Show("Failed to save all bill details.", "Partial Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Failed to save bill.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Database helper methods

        private CustomerModel GetCustomerByPhoneNumber(string phoneNumber)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT CustomerID, CustomerName, Address, PhoneNumber FROM Customers WHERE PhoneNumber = @PhoneNumber";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    try { conn.Open(); SqlDataReader reader = cmd.ExecuteReader(); if (reader.Read()) { return new CustomerModel { CustomerID = Convert.ToInt32(reader["CustomerID"]), CustomerName = reader["CustomerName"].ToString(), Address = reader["Address"]?.ToString(), PhoneNumber = reader["PhoneNumber"].ToString() }; } }
                    catch (Exception ex) { Console.WriteLine("DB Error GetCustomerByPhoneNumber: " + ex.Message); }
                }
            }
            return null;
        }

        private int AddNewCustomer(string name, string address, string phone)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Customers (CustomerName, Address, PhoneNumber) OUTPUT INSERTED.CustomerID VALUES (@Name, @Address, @Phone);";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name); cmd.Parameters.AddWithValue("@Address", (object)address ?? DBNull.Value); cmd.Parameters.AddWithValue("@Phone", phone);
                    try { conn.Open(); object result = cmd.ExecuteScalar(); if (result != null) return Convert.ToInt32(result); }
                    catch (SqlException ex) { MessageBox.Show("Error adding customer: " + ex.Message); }
                }
            }
            return -1;
        }

        private void UpdateCustomer(int customerId, string name, string address, string phone)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Customers SET CustomerName = @Name, Address = @Address, PhoneNumber = @Phone WHERE CustomerID = @CustomerID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerId); cmd.Parameters.AddWithValue("@Name", name); cmd.Parameters.AddWithValue("@Address", (object)address ?? DBNull.Value); cmd.Parameters.AddWithValue("@Phone", phone);
                    try { conn.Open(); cmd.ExecuteNonQuery(); }
                    catch (SqlException ex) { MessageBox.Show("Error updating customer: " + ex.Message); }
                }
            }
        }

        private int SaveBill(int customerId, decimal totalBillPrice)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Bills (CustomerID, TotalPrice, DateCreated) OUTPUT INSERTED.BillID VALUES (@CustID, @TotalPrice, @Date);";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustID", customerId); cmd.Parameters.AddWithValue("@TotalPrice", totalBillPrice); cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    try { conn.Open(); object result = cmd.ExecuteScalar(); if (result != null) return Convert.ToInt32(result); }
                    catch (SqlException ex) { MessageBox.Show("Error saving bill: " + ex.Message); }
                }
            }
            return -1;
        }

        private bool SaveBillDetails(int billId)
        {
            bool success = true;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in cartItems)
                {
                    string query = "INSERT INTO Invoice (BillID, ProductID, Quantity, Price) VALUES (@BillID, @ProdID, @Qty, @ItemPrice);";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BillID", billId); cmd.Parameters.AddWithValue("@ProdID", item.ProductID); cmd.Parameters.AddWithValue("@Qty", item.Quantity); cmd.Parameters.AddWithValue("@ItemPrice", item.UnitPrice);
                        try { if (cmd.ExecuteNonQuery() == 0) success = false; }
                        catch (SqlException ex) { MessageBox.Show($"Error saving bill detail for {item.ItemName}: {ex.Message}"); success = false; }
                    }
                }
            }
            return success;
        }

        private void UpdateProductStock()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in cartItems)
                {
                    string query = "UPDATE Products SET Quantity = Quantity - @SoldQty WHERE ProductID = @ProdID;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoldQty", item.Quantity); cmd.Parameters.AddWithValue("@ProdID", item.ProductID);
                        try { cmd.ExecuteNonQuery(); }
                        catch (SqlException ex) { MessageBox.Show($"Error updating stock for {item.ItemName}: {ex.Message}"); }
                    }
                }
            }
        }
        #endregion

        private void PbBack_Click(object sender, EventArgs e)
        {
            if (cbo1 != null && !cbo1.IsDisposed)
            {
                cbo1.SelectedIndexChanged -= Cbo1_Customer_SelectedIndexChanged;
                cbo1.DataSource = null; 
                cbo1.Items.Clear();     
                cbo1.SelectedIndex = -1;
                cbo1.Text = string.Empty;

            }

    
            if (cboProduct != null && !cboProduct.IsDisposed)
            {
                cboProduct.SelectedIndexChanged -= CboProduct_SelectedIndexChanged; 
                cboProduct.DataSource = null; 
                cboProduct.Items.Clear();    
                cboProduct.SelectedIndex = -1;
                cboProduct.Text = string.Empty;
            }


            if (txtProductName != null && !txtProductName.IsDisposed) txtProductName.Content = "";
            if (txtPrice != null && !txtPrice.IsDisposed) txtPrice.Content = "";
            if (numQuantity != null && !numQuantity.IsDisposed) numQuantity.Value = 0;
            if (txtTotalPrice != null && !txtTotalPrice.IsDisposed) txtTotalPrice.Content = "0.00";
            if (pictureBox2 != null && !pictureBox2.IsDisposed) pictureBox2.Image = null;
            currentSelectedProduct = null;

            if (lblUserName != null && !lblUserName.IsDisposed) lblUserName.Content = "";
            if (lblPassword != null && !lblPassword.IsDisposed) lblPassword.Content = ""; 
            if (cuiTextBox1 != null && !cuiTextBox1.IsDisposed) cuiTextBox1.Content = ""; 


            this.Close();
        }
    }
}