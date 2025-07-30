using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Word = Microsoft.Office.Interop.Word; 
using System.Windows.Forms;
using System.Windows.Controls;
using ComponentFactory.Krypton.Toolkit;

namespace Baicuoiky
{
    public partial class Bill : Form
    {
        private string connectionString = "Data Source=VINCENT\\SQLEXPRESS;Initial Catalog=ShopApp;Integrated Security=True;";
        public Bill()
        {
            InitializeComponent();
            dtpBillDate.Value = DateTime.Now;
        }

        private void Bill_Load(object sender, EventArgs e)
        {

            dtpBillDate.Value = DateTime.Now; 
            LoadHoaDon(dtpBillDate.Value.Date);   

            dgvBills.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBills.MultiSelect = false;
        }
       
        private void LoadHoaDon(DateTime? filterDate = null)
        {
            DateTime selectedDate = dtpBillDate.Value.Date;

            dgvBills.Rows.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    b.BillID,
                    p.ProductID,
                    p.ProductName,
                    i.Quantity,
                    i.Price,
                    c.CustomerName,
                    (i.Quantity * i.Price) AS TotalPrice,
                    b.DateCreated
                FROM Bills b
                INNER JOIN Invoice i ON b.BillID = i.BillID
                INNER JOIN Products p ON i.ProductID = p.ProductID
                INNER JOIN Customers c ON b.CustomerID = c.CustomerID";

                    if (filterDate.HasValue) 
                    {
                        query += " WHERE CAST(b.DateCreated AS DATE) = @SelectedDate";
                    }
                    query += " ORDER BY b.DateCreated DESC, b.BillID DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (filterDate.HasValue)
                        {
                            command.Parameters.AddWithValue("@SelectedDate", filterDate.Value.Date);
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgvBills.Rows.Add(
                                    reader["BillID"],
                                    reader["ProductID"],
                                    reader["ProductName"],
                                    reader["Quantity"],
                                    Convert.ToDecimal(reader["Price"]).ToString("N0"),
                                    reader["CustomerName"],
                                    Convert.ToDecimal(reader["TotalPrice"]).ToString("N0"),
                                    Convert.ToDateTime(reader["DateCreated"]).ToString("dd/MM/yyyy")
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadHoaDon();
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            if (dgvBills.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để in.", "Chưa chọn hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Get information from the selected row in DataGridView
            DataGridViewRow selectedRow = dgvBills.SelectedRows[0];
            int selectedBillID;
            if (!int.TryParse(selectedRow.Cells["BillID"].Value?.ToString(), out selectedBillID)) // Assumes your BillID column is named "BillID"
            {
                MessageBox.Show("Mã hóa đơn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string customerName = selectedRow.Cells["CustomerName"].Value?.ToString() ?? "N/A"; // Assumes CustomerName column is named "CustomerName"
            string dateCreated = selectedRow.Cells["DateCreated"].Value?.ToString() ?? DateTime.Now.ToString("dd/MM/yyyy"); // Assumes DateCreated column is named "DateCreated"

            // Fetch items for the selected bill
            DataTable dtBillItems = GetInvoiceItemsForBill(selectedBillID);

            if (dtBillItems.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy chi tiết cho hóa đơn này hoặc hóa đơn rỗng.", "Không có dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Word.Application wordApp = new Word.Application();
                wordApp.Visible = true; // Make Word visible
                Word.Document doc = wordApp.Documents.Add();

                // --- Bill Header ---
                Word.Paragraph paraTitle = doc.Content.Paragraphs.Add();
                paraTitle.Range.Text = "HÓA ĐƠN BÁN HÀNG";
                paraTitle.Range.Font.Name = "Times New Roman";
                paraTitle.Range.Font.Size = 18;
                paraTitle.Range.Font.Bold = 1;
                paraTitle.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                paraTitle.Range.InsertParagraphAfter(); 

                // --- Shop Information (Optional) ---
                Word.Paragraph paraShopInfo = doc.Content.Paragraphs.Add();
                paraShopInfo.Range.Text = "Cửa hàng GameConsole\nĐịa chỉ: 123 Đường XYZ, Quận 0, TP.HCM\nĐiện thoại: 0123 456 789";
                paraShopInfo.Range.Font.Name = "Times New Roman";
                paraShopInfo.Range.Font.Size = 12;
                paraShopInfo.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft; // Or center
                paraShopInfo.Range.InsertParagraphAfter();
                paraShopInfo.Range.InsertParagraphAfter(); 

                // --- Bill Details ---
                Word.Paragraph paraBillInfo = doc.Content.Paragraphs.Add();
                paraBillInfo.Range.Text = $"Số Hóa Đơn: HD{selectedBillID:D5}"; // Example: HD00001
                paraBillInfo.Range.Font.Name = "Times New Roman";
                paraBillInfo.Range.Font.Size = 12;
                paraBillInfo.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                paraBillInfo.Range.InsertParagraphAfter();

                paraBillInfo.Range.Text = $"Ngày Lập: {dateCreated}";
                paraBillInfo.Range.InsertParagraphAfter();

                paraBillInfo.Range.Text = $"Khách Hàng: {customerName}";
                paraBillInfo.Range.InsertParagraphAfter();
                paraBillInfo.Range.InsertParagraphAfter();

                Word.Table wordTable = doc.Tables.Add(doc.Bookmarks.get_Item("\\endofdoc").Range, dtBillItems.Rows.Count + 1, 5);
                wordTable.Borders.Enable = 1; // Enable borders
                wordTable.Range.Font.Name = "Times New Roman";
                wordTable.Range.Font.Size = 11;

                // Header Row
                string[] headers = { "STT", "Tên Sản Phẩm", "Số Lượng", "Đơn Giá (VNĐ)", "Thành Tiền (VNĐ)" };
                for (int i = 0; i < headers.Length; i++)
                {
                    wordTable.Cell(1, i + 1).Range.Text = headers[i];
                    wordTable.Cell(1, i + 1).Range.Font.Bold = 1;
                    wordTable.Cell(1, i + 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    wordTable.Cell(1, i + 1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                }

                // Data Rows
                decimal grandTotal = 0;
                for (int r = 0; r < dtBillItems.Rows.Count; r++)
                {
                    DataRow dr = dtBillItems.Rows[r];
                    wordTable.Cell(r + 2, 1).Range.Text = (r + 1).ToString(); // STT
                    wordTable.Cell(r + 2, 2).Range.Text = dr["ProductName"].ToString();
                    wordTable.Cell(r + 2, 3).Range.Text = Convert.ToInt32(dr["Quantity"]).ToString();
                    wordTable.Cell(r + 2, 4).Range.Text = Convert.ToDecimal(dr["Price"]).ToString("N0");
                    wordTable.Cell(r + 2, 5).Range.Text = Convert.ToDecimal(dr["ItemTotalPrice"]).ToString("N0");

                    grandTotal += Convert.ToDecimal(dr["ItemTotalPrice"]);

                    // Align numeric columns to the right
                    wordTable.Cell(r + 2, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    wordTable.Cell(r + 2, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    wordTable.Cell(r + 2, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                    wordTable.Cell(r + 2, 5).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                }

                wordTable.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow);


                // --- Grand Total ---
                Word.Paragraph paraTotal = doc.Content.Paragraphs.Add(); // Add after table
                paraTotal.Range.InsertParagraphAfter(); // Blank line before total
                paraTotal.Range.Text = $"Tổng Cộng Thanh Toán: {grandTotal:N0} VNĐ";
                paraTotal.Range.Font.Name = "Times New Roman";
                paraTotal.Range.Font.Size = 13;
                paraTotal.Range.Font.Bold = 1;
                paraTotal.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                paraTotal.Range.InsertParagraphAfter();

                // --- Thank You Message (Optional) ---
                Word.Paragraph paraThanks = doc.Content.Paragraphs.Add();
                paraThanks.Range.InsertParagraphAfter();
                paraThanks.Range.Text = "Cảm ơn quý khách đã mua hàng!";
                paraThanks.Range.Font.Name = "Times New Roman";
                paraThanks.Range.Font.Size = 12;
                paraThanks.Range.Font.Italic = 1;
                paraThanks.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                paraThanks.Range.InsertParagraphAfter();

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo hóa đơn Word: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Consider cleanup of Word objects here too if wordApp was instantiated
            }
        }
        private DataTable GetInvoiceItemsForBill(int billID)
        {
            DataTable dtItems = new DataTable();
            dtItems.Columns.Add("ProductName", typeof(string));
            dtItems.Columns.Add("Quantity", typeof(int));
            dtItems.Columns.Add("Price", typeof(decimal));
            dtItems.Columns.Add("ItemTotalPrice", typeof(decimal));

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    p.ProductName,
                    i.Quantity,
                    i.Price,
                    (i.Quantity * i.Price) AS ItemTotalPrice
                FROM Invoice i
                INNER JOIN Products p ON i.ProductID = p.ProductID
                WHERE i.BillID = @BillID
                ORDER BY p.ProductName;"; 

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BillID", billID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dtItems.Rows.Add(
                                    reader["ProductName"],
                                    Convert.ToInt32(reader["Quantity"]),
                                    Convert.ToDecimal(reader["Price"]),
                                    Convert.ToDecimal(reader["ItemTotalPrice"])
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtItems;
        }
        private void dgvBills_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBills.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xóa.", "Chưa chọn hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dgvBills.SelectedRows[0];
            int billIDToDelete;

            if (selectedRow.Cells["BillID"]?.Value == null || !int.TryParse(selectedRow.Cells["BillID"].Value.ToString(), out billIDToDelete))
            {
                MessageBox.Show("Không thể lấy Mã Hóa Đơn để xóa. Vui lòng kiểm tra cột 'BillID'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmation = MessageBox.Show($"Bạn có chắc chắn muốn xóa Hóa đơn số {billIDToDelete} và tất cả chi tiết liên quan không?\nHành động này không thể hoàn tác.",
                                                        "Xác nhận xóa",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // 1. Delete from Invoice table (child table due to foreign key)
                        string deleteInvoiceQuery = "DELETE FROM Invoice WHERE BillID = @BillID";
                        using (SqlCommand cmdInvoice = new SqlCommand(deleteInvoiceQuery, connection, transaction))
                        {
                            cmdInvoice.Parameters.AddWithValue("@BillID", billIDToDelete);
                            cmdInvoice.ExecuteNonQuery(); // This will delete all items for the bill
                        }

                        // 2. Delete from Bills table (parent table)
                        string deleteBillQuery = "DELETE FROM Bills WHERE BillID = @BillID";
                        using (SqlCommand cmdBill = new SqlCommand(deleteBillQuery, connection, transaction))
                        {
                            cmdBill.Parameters.AddWithValue("@BillID", billIDToDelete);
                            int rowsAffected = cmdBill.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                transaction.Commit(); // Commit if both deletions were successful
                                MessageBox.Show($"Hóa đơn {billIDToDelete} đã được xóa thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                transaction.Rollback(); // Rollback if bill was not found (though invoice items might have been deleted if they existed)
                                MessageBox.Show($"Không tìm thấy hóa đơn {billIDToDelete} để xóa, hoặc đã bị xóa trước đó.", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (SqlException sqlEx) // Catch specific SQL errors
                    {
                        try { transaction.Rollback(); } catch { /* Ignore rollback error */ }
                        MessageBox.Show("Lỗi SQL khi xóa hóa đơn: " + sqlEx.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex) // Catch general errors
                    {
                        try { transaction.Rollback(); } catch { /* Ignore rollback error */ }
                        MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                LoadHoaDon(dtpBillDate.Value.Date);
            }
        }

        private void dtpBillDate_Load(object sender, EventArgs e)
        {

        }

        private void dtpBillDate_DateChanged(object sender, EventArgs e)
        {
            LoadHoaDon(dtpBillDate.Value.Date);
        }
    }
}
