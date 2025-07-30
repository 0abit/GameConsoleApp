using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Baicuoiky
{
    public partial class Dangki : Form
    {
        public Dangki()
        {
            InitializeComponent();
        }
        // Giữ lại khai báo này, nó sẽ được dùng chung
        string connectionString = "Data Source=VINCENT\\SQLEXPRESS;Initial Catalog=ShopApp;Integrated Security=True"; // thay tên CSDL nếu khác

        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Content.Trim(); // Or txtUsername.Text.Trim();
            string password = txtPassword.Content.Trim(); // Or txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Content.Trim(); // Or txtConfirmPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin (Tên đăng nhập, Mật khẩu, Nhập lại mật khẩu)!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu và mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus(); 
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = @usernameCheck";
                    using (SqlCommand checkUserCmd = new SqlCommand(checkUserQuery, conn))
                    {
                        checkUserCmd.Parameters.AddWithValue("@usernameCheck", username);
                        int userCount = (int)checkUserCmd.ExecuteScalar();
                        if (userCount > 0)
                        {
                            MessageBox.Show("Tên người dùng này đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtUsername.Focus(); // Assuming txtUsername is a control that can receive focus
                            return;
                        }
                    }

                    // Modified query to include RoleID
                    string query = "INSERT INTO Users (Username, Password, RoleID) VALUES (@usernameInsert, @passwordInsert, @roleIDInsert)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usernameInsert", username);
                        cmd.Parameters.AddWithValue("@passwordInsert", password); // Store hashed password here in a real app
                        cmd.Parameters.AddWithValue("@roleIDInsert", 1); // Default RoleID is 1

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Đăng ký thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            Signin signin = new Signin();
                            signin.Show();
                        }
                        else
                        {
                            MessageBox.Show("Đăng ký thất bại! Không có dòng nào được thêm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Lỗi Unique Key Violation (likely on Username if it has a unique constraint)
                    {
                        MessageBox.Show("Tên người dùng này đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsername.Focus(); // Assuming txtUsername is a control that can receive focus
                    }
                    else
                    {
                        MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi không mong muốn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}