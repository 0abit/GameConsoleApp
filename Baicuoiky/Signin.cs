using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Baicuoiky
{
    public partial class Signin : Form
    {
        public Signin()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=VINCENT\\SQLEXPRESS;Initial Catalog=ShopApp;Integrated Security=True";

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void lblCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dangki dangki = new Dangki();
            dangki.FormClosed += (s, args) => this.Show();
            dangki.Show();
        }

        private void lblForgot_Click(object sender, EventArgs e)
        {
            this.Hide();
            Quenmk quenmk = new Quenmk();
            quenmk.FormClosed += (s, args) => this.Show();
            quenmk.Show();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Content.Trim(); 
            string password = txtPassword.Content.Trim(); 

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT RoleID FROM Users WHERE Username = @username AND Password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        object result = cmd.ExecuteScalar(); 

                        if (result != null && result != DBNull.Value)
                        {
                            int roleId = Convert.ToInt32(result);
                            MessageBox.Show("Đăng nhập thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (roleId == 2)
                            {
                                Quanly quanlyForm = new Quanly();
                                quanlyForm.Show();
                                this.Hide();
                            }
                            else if (roleId == 1)
                            {
                                Nhanvien nhanvienForm = new Nhanvien(); 
                                nhanvienForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                
                                MessageBox.Show("Vai trò người dùng không hợp lệ hoặc không được xác định.", "Lỗi Vai Trò", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi Đăng Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPassword.Content = ""; 
                            txtPassword.Focus();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi không mong muốn: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}