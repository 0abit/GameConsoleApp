using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Baicuoiky
{
    public partial class Quenmk : Form
    {
        string connectionString = "Data Source=VINCENT\\SQLEXPRESS;Initial Catalog=ShopApp;Integrated Security=True";
        public Quenmk()
        {
            InitializeComponent();
        }
        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string idEmployee = txtId.Content.Trim(); 
            string newPassword = txtNewPassword.Content.Trim();
            string confirmPassword = txtConfirmPassword.Content.Trim();

            
            if (string.IsNullOrWhiteSpace(idEmployee) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin (ID Employee, Mật khẩu mới, Xác nhận mật khẩu mới)!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewPassword.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    
                    string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE Id = @Id"; 
                    SqlCommand checkUserCmd = new SqlCommand(checkUserQuery, conn);
                    checkUserCmd.Parameters.AddWithValue("@Id", idEmployee);

                    int userExists = (int)checkUserCmd.ExecuteScalar();

                    if (userExists > 0)
                    {
                        
                        string updateQuery = "UPDATE Users SET Password = @NewPassword WHERE Id = @IDEmployeeToUpdate";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, conn);

                        updateCmd.Parameters.AddWithValue("@NewPassword", newPassword);
                        updateCmd.Parameters.AddWithValue("@IDEmployeeToUpdate", idEmployee);

                        int rowsAffected = updateCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            Signin signinForm = new Signin();
                            signinForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Không thể cập nhật mật khẩu. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
          
                        MessageBox.Show("ID Employee không tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtId.Focus();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi không mong muốn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
