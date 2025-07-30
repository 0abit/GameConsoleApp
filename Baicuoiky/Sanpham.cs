using ComponentFactory.Krypton.Toolkit;
using CuoreUI.Controls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging; // Thêm using này cho ImageFormat
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Globalization; // Thêm using này cho CultureInfo

namespace Baicuoiky
{
    public partial class Sanpham : Form
    {
        private string connectionString = "Data Source=VINCENT\\SQLEXPRESS;Initial Catalog=ShopApp;Integrated Security=True;";

        // Biến để lưu đường dẫn của hình ảnh hiện tại đang được chọn/hiển thị từ file
        private string currentImagePath = null;
        // Biến để lưu ProductID của sản phẩm đang được chọn trong DataGridView
        private int selectedProductId = 0;

        public Sanpham()
        {
            InitializeComponent();
        }

        private void Sanpham_Load(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            LoadProducts();
        }

        private void LoadProducts()
        {
            kryptonDataGridView1.Rows.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Chỉ lấy các cột cần thiết cho hiển thị ban đầu trên grid
                    string query = "SELECT ProductID, ProductName, Price, Quantity, LastModifiedDate FROM Products ORDER BY ProductID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                kryptonDataGridView1.Rows.Add(
                                    reader["ProductID"],
                                    reader["ProductName"],
                                    Convert.ToDecimal(reader["Price"]).ToString("N0"), // Định dạng số có dấu phẩy
                                    reader["Quantity"],
                                    null, // Cột ProductImage (path) không dùng, để null
                                    Convert.ToDateTime(reader["LastModifiedDate"]).ToString("dd/MM/yyyy HH:mm:ss")
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ClearInputFields();
        }

        private void ClearInputFields()
        {
            txtProductName.Content = "";
            txtProductPrice.Content = "";
            nudQuantity.Value = 1; // Số lượng mặc định là 1
            pbProductImage.Image = null;
            currentImagePath = null; // Reset đường dẫn ảnh mới
            txtProductName.Focus();

            selectedProductId = 0; // Reset ID sản phẩm đang chọn
            kryptonDataGridView1.ClearSelection();

            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true; // Nút Add luôn sẵn sàng
        }

        // Chuyển Image thành byte[]
        public byte[] ImageToByteArray(Image imageIn)
        {
            if (imageIn == null) return null;
            using (var ms = new MemoryStream())
            {
                // Cố gắng lưu với định dạng gốc nếu có, nếu không thì PNG
                ImageFormat format = imageIn.RawFormat;
                if (format.Equals(ImageFormat.MemoryBmp) || format.Guid == new Guid("{b96b3caa-0728-11d3-9d7b-0000f81ef32e}")) // MemoryBmp
                {
                    format = ImageFormat.Png; // PNG hỗ trợ alpha và không mất dữ liệu
                }
                imageIn.Save(ms, format);
                return ms.ToArray();
            }
        }

        // Chuyển byte[] thành Image
        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null || byteArrayIn.Length == 0) return null;
            using (var ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        // Lấy byte[] từ file path
        private byte[] GetImageBytesFromFile(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
                return null;
            try
            {
                return File.ReadAllBytes(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đọc file ảnh: {ex.Message}", "Lỗi File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn hình ảnh sản phẩm";
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    currentImagePath = openFileDialog.FileName;
                    pbProductImage.Image = Image.FromFile(currentImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    currentImagePath = null;
                    pbProductImage.Image = null;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Content))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtProductPrice.Content))
            {
                MessageBox.Show("Vui lòng nhập giá sản phẩm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductPrice.Focus();
                return;
            }

            decimal price;
            // Xử lý giá có thể chứa dấu phẩy từ định dạng N0
            string priceString = txtProductPrice.Content.Replace(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator, "");
            if (!decimal.TryParse(priceString, NumberStyles.Any, CultureInfo.CurrentCulture, out price) || price < 0)
            {
                MessageBox.Show("Giá sản phẩm không hợp lệ. Vui lòng nhập số dương.", "Sai định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductPrice.Focus();
                return;
            }


            if (nudQuantity.Value <= 0)
            {
                MessageBox.Show("Số lượng sản phẩm phải lớn hơn 0.", "Số lượng không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudQuantity.Focus();
                return;
            }

            if (pbProductImage.Image == null || string.IsNullOrEmpty(currentImagePath))
            {
                MessageBox.Show("Vui lòng chọn hình ảnh cho sản phẩm.", "Thiếu hình ảnh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] imageBytes = GetImageBytesFromFile(currentImagePath);
            if (imageBytes == null)
            {
                MessageBox.Show("Không thể đọc dữ liệu từ file hình ảnh đã chọn.", "Lỗi Ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Products (ProductName, Price, Quantity, ProductImage, LastModifiedDate) VALUES (@Name, @Price, @Quantity, @Image, @Date)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", txtProductName.Content.Trim());
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@Quantity", (int)nudQuantity.Value);
                        command.Parameters.Add("@Image", SqlDbType.VarBinary, -1).Value = imageBytes; // Sử dụng SqlDbType.VarBinary cho MAX
                        command.Parameters.AddWithValue("@Date", DateTime.Now);

                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadProducts(); // Tải lại và clear fields
                        }
                        else
                        {
                            MessageBox.Show("Thêm sản phẩm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra click vào dòng có dữ liệu (không phải header, không phải dòng trống mới)
            if (e.RowIndex >= 0 && e.RowIndex < kryptonDataGridView1.Rows.Count && kryptonDataGridView1.Rows[e.RowIndex].Cells["ProductId"].Value != null)
            {
                DataGridViewRow selectedRow = kryptonDataGridView1.Rows[e.RowIndex];
                selectedProductId = Convert.ToInt32(selectedRow.Cells["ProductId"].Value);

                txtProductName.Content = selectedRow.Cells["ProductName"].Value?.ToString() ?? "";
                // Giá trị trong grid đã được định dạng N0, hiển thị trực tiếp
                txtProductPrice.Content = selectedRow.Cells["Price"].Value?.ToString() ?? "";

                if (selectedRow.Cells["Quantity"].Value != null && int.TryParse(selectedRow.Cells["Quantity"].Value.ToString(), out int quantity))
                {
                    nudQuantity.Value = quantity;
                }
                else
                {
                    nudQuantity.Value = 1; // Mặc định nếu không parse được
                }

                // Tải hình ảnh từ database cho sản phẩm được chọn
                pbProductImage.Image = null; // Xóa ảnh cũ
                currentImagePath = null;   // Reset đường dẫn file ảnh mới
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "SELECT ProductImage FROM Products WHERE ProductID = @Id";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", selectedProductId);
                            object imageDataObj = command.ExecuteScalar(); // Lấy dữ liệu ảnh
                            if (imageDataObj != null && imageDataObj != DBNull.Value)
                            {
                                byte[] imageData = (byte[])imageDataObj;
                                pbProductImage.Image = ByteArrayToImage(imageData);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải ảnh sản phẩm: " + ex.Message, "Lỗi Ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false; // Không cho Add khi đang chọn một item
            }
            else
            {
                // Nếu click vào header hoặc dòng trống ở cuối
                ClearInputFields();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedProductId == 0)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để sửa.", "Chưa chọn sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtProductName.Content))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtProductPrice.Content))
            {
                MessageBox.Show("Vui lòng nhập giá sản phẩm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductPrice.Focus();
                return;
            }

            decimal price;
            // Xử lý giá có thể chứa dấu phẩy từ định dạng N0
            string priceString = txtProductPrice.Content.Replace(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator, "");
            if (!decimal.TryParse(priceString, NumberStyles.Any, CultureInfo.CurrentCulture, out price) || price < 0)
            {
                MessageBox.Show("Giá sản phẩm không hợp lệ. Vui lòng nhập số dương.", "Sai định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductPrice.Focus();
                return;
            }

            if (nudQuantity.Value <= 0)
            {
                MessageBox.Show("Số lượng sản phẩm phải lớn hơn 0.", "Số lượng không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudQuantity.Focus();
                return;
            }

            // Khi sửa, hình ảnh không nhất thiết phải được chọn lại từ file
            // Nếu người dùng không chọn ảnh mới (currentImagePath là null),
            // thì ta sẽ giữ nguyên ảnh cũ trong database (nếu có) hoặc cập nhật từ pbProductImage nếu nó có ảnh.
            // Nếu pbProductImage là null, nghĩa là sản phẩm không có ảnh hoặc ảnh bị lỗi
            if (pbProductImage.Image == null && string.IsNullOrEmpty(currentImagePath))
            {
                MessageBox.Show("Sản phẩm phải có hình ảnh. Vui lòng chọn lại ảnh nếu ảnh hiện tại bị lỗi hoặc không có.", "Thiếu hình ảnh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            byte[] imageBytesToUpdate = null;
            bool updateImage = false;

            if (!string.IsNullOrEmpty(currentImagePath) && File.Exists(currentImagePath))
            {
                // Người dùng đã chọn một file ảnh mới
                imageBytesToUpdate = GetImageBytesFromFile(currentImagePath);
                if (imageBytesToUpdate == null) return; // Lỗi đọc file đã báo
                updateImage = true;
            }
            else if (pbProductImage.Image != null && string.IsNullOrEmpty(currentImagePath))
            {
                // Không chọn file mới, nhưng PictureBox có ảnh (là ảnh từ DB hoặc ảnh đã chọn trước đó)
                // Chúng ta sẽ lưu lại ảnh đang hiển thị trên PictureBox
                imageBytesToUpdate = ImageToByteArray(pbProductImage.Image);
                updateImage = true; // Vẫn coi là có cập nhật ảnh nếu PictureBox có ảnh
            }
            // Nếu currentImagePath rỗng VÀ pbProductImage.Image cũng rỗng, thì không cập nhật ảnh

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query;
                    if (updateImage && imageBytesToUpdate != null)
                    {
                        query = "UPDATE Products SET ProductName = @Name, Price = @Price, Quantity = @Quantity, ProductImage = @Image, LastModifiedDate = @Date WHERE ProductID = @Id";
                    }
                    else
                    {
                        // Không cập nhật trường ProductImage
                        query = "UPDATE Products SET ProductName = @Name, Price = @Price, Quantity = @Quantity, LastModifiedDate = @Date WHERE ProductID = @Id";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", txtProductName.Content.Trim());
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@Quantity", (int)nudQuantity.Value);
                        command.Parameters.AddWithValue("@Date", DateTime.Now);
                        command.Parameters.AddWithValue("@Id", selectedProductId);

                        if (updateImage && imageBytesToUpdate != null)
                        {
                            command.Parameters.Add("@Image", SqlDbType.VarBinary, -1).Value = imageBytesToUpdate;
                        }

                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadProducts();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật sản phẩm thất bại hoặc không có gì thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sản phẩm: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedProductId == 0)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Chưa chọn sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?",
                                                       "Xác nhận xóa",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM Products WHERE ProductID = @Id";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", selectedProductId);
                            int result = command.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadProducts();
                            }
                            else
                            {
                                MessageBox.Show("Xóa sản phẩm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sanpham_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void kryptonDataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Lấy DataGridView hiện tại
            DataGridView dgv = sender as DataGridView;
            if (dgv != null)
            {
                // Lấy số thứ tự của dòng (e.RowIndex bắt đầu từ 0, nên cộng 1)
                string rowIndex = (e.RowIndex + 1).ToString();

                // Thiết lập Font và Brush để vẽ số
                // Bạn có thể tùy chỉnh Font và màu sắc ở đây
                Font rowFont = new Font(dgv.Font, FontStyle.Bold); // Hoặc Font khác
                SolidBrush brush = new SolidBrush(dgv.RowHeadersDefaultCellStyle.ForeColor); // Màu chữ của RowHeader

                // Tính toán vị trí để vẽ số thứ tự sao cho nó căn giữa trong RowHeaderCell
                SizeF textSize = e.Graphics.MeasureString(rowIndex, rowFont);
                float textX = e.RowBounds.Left + (dgv.RowHeadersWidth - textSize.Width) / 2;
                float textY = e.RowBounds.Top + (e.RowBounds.Height - textSize.Height) / 2;

                // Vẽ số thứ tự lên RowHeader
                // e.Graphics là đối tượng Graphics để vẽ
                // e.RowBounds là hình chữ nhật bao quanh dòng, bao gồm cả RowHeader
                e.Graphics.DrawString(rowIndex, rowFont, brush, textX, textY);

                // Giải phóng tài nguyên (quan trọng)
                brush.Dispose();
                rowFont.Dispose();
            }
        }
    }
}