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
    public partial class Quanly : Form
    {
        public Quanly()
        {
            InitializeComponent();
        }

        private void btnSignout_Click_1(object sender, EventArgs e)
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

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Khachhang khachhang = new Khachhang();
            khachhang.FormClosed += (s, args) => this.Show();
            khachhang.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sanpham sanpham = new Sanpham();
            sanpham.FormClosed += (s, args) => this.Show();
            sanpham.Show();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bill bill = new Bill();
            bill.FormClosed += (s, args) => this.Show();
            bill.Show();
        }
    }
}
