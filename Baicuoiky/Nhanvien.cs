using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baicuoiky
{
    public partial class Nhanvien: Form
    {
        public Nhanvien()
        {
            InitializeComponent();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            this.Hide();
            Banhang banhang = new Banhang();

            banhang.FormClosed += (s, args) => this.Show();

            banhang.Show();
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
            Signin signin = new Signin();
            signin.Show();
        }
    }
}
