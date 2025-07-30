namespace Baicuoiky
{
    partial class Bill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bill));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpBillDate = new CuoreUI.Controls.cuiCalendarDatePicker();
            this.btnPrintBill = new CuoreUI.Controls.cuiButton();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new CuoreUI.Controls.cuiButton();
            this.dgvBills = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.BillID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new CuoreUI.Controls.cuiButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpBillDate
            // 
            this.dtpBillDate.EnableThemeChangeButton = true;
            this.dtpBillDate.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBillDate.ForeColor = System.Drawing.Color.Gray;
            this.dtpBillDate.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dtpBillDate.HoverOutline = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dtpBillDate.Icon = null;
            this.dtpBillDate.IconTint = System.Drawing.Color.Gray;
            this.dtpBillDate.Location = new System.Drawing.Point(136, 18);
            this.dtpBillDate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dtpBillDate.Name = "dtpBillDate";
            this.dtpBillDate.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dtpBillDate.NormalOutline = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dtpBillDate.OutlineThickness = 1.5F;
            this.dtpBillDate.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dtpBillDate.PressedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dtpBillDate.Rounding = 8;
            this.dtpBillDate.ShowIcon = true;
            this.dtpBillDate.Size = new System.Drawing.Size(360, 45);
            this.dtpBillDate.TabIndex = 0;
            this.dtpBillDate.Theme = CuoreUI.Controls.Forms.DatePicker.Themes.Light;
            this.dtpBillDate.Value = new System.DateTime(2025, 4, 26, 0, 0, 0, 0);
            this.dtpBillDate.DateChanged += new System.EventHandler(this.dtpBillDate_DateChanged);
            this.dtpBillDate.Load += new System.EventHandler(this.dtpBillDate_Load);
            // 
            // btnPrintBill
            // 
            this.btnPrintBill.BackColor = System.Drawing.Color.Transparent;
            this.btnPrintBill.CheckButton = false;
            this.btnPrintBill.Checked = false;
            this.btnPrintBill.CheckedBackground = System.Drawing.Color.DarkKhaki;
            this.btnPrintBill.CheckedForeColor = System.Drawing.Color.White;
            this.btnPrintBill.CheckedImageTint = System.Drawing.Color.White;
            this.btnPrintBill.CheckedOutline = System.Drawing.Color.DarkKhaki;
            this.btnPrintBill.Content = "Print bill";
            this.btnPrintBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintBill.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrintBill.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintBill.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnPrintBill.HoverBackground = System.Drawing.Color.Cornsilk;
            this.btnPrintBill.HoveredImageTint = System.Drawing.Color.MidnightBlue;
            this.btnPrintBill.HoverForeColor = System.Drawing.Color.Black;
            this.btnPrintBill.HoverOutline = System.Drawing.Color.Cornsilk;
            this.btnPrintBill.Image = null;
            this.btnPrintBill.ImageAutoCenter = true;
            this.btnPrintBill.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnPrintBill.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnPrintBill.Location = new System.Drawing.Point(557, 18);
            this.btnPrintBill.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.NormalBackground = System.Drawing.Color.Cornsilk;
            this.btnPrintBill.NormalForeColor = System.Drawing.Color.MidnightBlue;
            this.btnPrintBill.NormalImageTint = System.Drawing.Color.White;
            this.btnPrintBill.NormalOutline = System.Drawing.Color.Black;
            this.btnPrintBill.OutlineThickness = 1F;
            this.btnPrintBill.PressedBackground = System.Drawing.Color.DarkKhaki;
            this.btnPrintBill.PressedForeColor = System.Drawing.Color.White;
            this.btnPrintBill.PressedImageTint = System.Drawing.Color.White;
            this.btnPrintBill.PressedOutline = System.Drawing.Color.DarkKhaki;
            this.btnPrintBill.Rounding = new System.Windows.Forms.Padding(8);
            this.btnPrintBill.Size = new System.Drawing.Size(144, 45);
            this.btnPrintBill.TabIndex = 5;
            this.btnPrintBill.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnPrintBill.TextOffset = new System.Drawing.Point(0, 0);
            this.btnPrintBill.Click += new System.EventHandler(this.btnPrintBill_Click);
            // 
            // pbBack
            // 
            this.pbBack.BackColor = System.Drawing.Color.Transparent;
            this.pbBack.ErrorImage = null;
            this.pbBack.Image = ((System.Drawing.Image)(resources.GetObject("pbBack.Image")));
            this.pbBack.InitialImage = null;
            this.pbBack.Location = new System.Drawing.Point(1173, 12);
            this.pbBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(78, 59);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBack.TabIndex = 18;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.pbBack_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.CheckButton = false;
            this.btnRefresh.Checked = false;
            this.btnRefresh.CheckedBackground = System.Drawing.Color.DarkKhaki;
            this.btnRefresh.CheckedForeColor = System.Drawing.Color.White;
            this.btnRefresh.CheckedImageTint = System.Drawing.Color.White;
            this.btnRefresh.CheckedOutline = System.Drawing.Color.DarkKhaki;
            this.btnRefresh.Content = "Refresh";
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRefresh.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnRefresh.HoverBackground = System.Drawing.Color.Cornsilk;
            this.btnRefresh.HoveredImageTint = System.Drawing.Color.MidnightBlue;
            this.btnRefresh.HoverForeColor = System.Drawing.Color.Black;
            this.btnRefresh.HoverOutline = System.Drawing.Color.Cornsilk;
            this.btnRefresh.Image = null;
            this.btnRefresh.ImageAutoCenter = true;
            this.btnRefresh.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnRefresh.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnRefresh.Location = new System.Drawing.Point(760, 18);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.NormalBackground = System.Drawing.Color.Cornsilk;
            this.btnRefresh.NormalForeColor = System.Drawing.Color.MidnightBlue;
            this.btnRefresh.NormalImageTint = System.Drawing.Color.White;
            this.btnRefresh.NormalOutline = System.Drawing.Color.Black;
            this.btnRefresh.OutlineThickness = 1F;
            this.btnRefresh.PressedBackground = System.Drawing.Color.DarkKhaki;
            this.btnRefresh.PressedForeColor = System.Drawing.Color.White;
            this.btnRefresh.PressedImageTint = System.Drawing.Color.White;
            this.btnRefresh.PressedOutline = System.Drawing.Color.DarkKhaki;
            this.btnRefresh.Rounding = new System.Windows.Forms.Padding(8);
            this.btnRefresh.Size = new System.Drawing.Size(144, 45);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnRefresh.TextOffset = new System.Drawing.Point(0, 0);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvBills
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvBills.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BillID,
            this.ProductID,
            this.ProductName,
            this.Quantity,
            this.Price,
            this.CustomerName,
            this.TotalPrice,
            this.DateCreated});
            this.dgvBills.Location = new System.Drawing.Point(12, 86);
            this.dgvBills.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.RowHeadersVisible = false;
            this.dgvBills.RowHeadersWidth = 62;
            this.dgvBills.RowTemplate.Height = 28;
            this.dgvBills.Size = new System.Drawing.Size(1239, 605);
            this.dgvBills.TabIndex = 20;
            this.dgvBills.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBills_CellContentClick);
            // 
            // BillID
            // 
            this.BillID.HeaderText = "BillID";
            this.BillID.MinimumWidth = 8;
            this.BillID.Name = "BillID";
            this.BillID.Width = 80;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.MinimumWidth = 8;
            this.ProductID.Name = "ProductID";
            this.ProductID.Width = 125;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Product name";
            this.ProductName.MinimumWidth = 8;
            this.ProductName.Name = "ProductName";
            this.ProductName.Width = 200;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 8;
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 90;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 8;
            this.Price.Name = "Price";
            this.Price.Width = 180;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "Customer name";
            this.CustomerName.MinimumWidth = 8;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Width = 200;
            // 
            // TotalPrice
            // 
            this.TotalPrice.HeaderText = "Total price";
            this.TotalPrice.MinimumWidth = 8;
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.Width = 200;
            // 
            // DateCreated
            // 
            this.DateCreated.HeaderText = "Date created";
            this.DateCreated.MinimumWidth = 8;
            this.DateCreated.Name = "DateCreated";
            this.DateCreated.Width = 200;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.CheckButton = false;
            this.btnDelete.Checked = false;
            this.btnDelete.CheckedBackground = System.Drawing.Color.DarkKhaki;
            this.btnDelete.CheckedForeColor = System.Drawing.Color.White;
            this.btnDelete.CheckedImageTint = System.Drawing.Color.White;
            this.btnDelete.CheckedOutline = System.Drawing.Color.DarkKhaki;
            this.btnDelete.Content = "Delete bill";
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnDelete.HoverBackground = System.Drawing.Color.Cornsilk;
            this.btnDelete.HoveredImageTint = System.Drawing.Color.MidnightBlue;
            this.btnDelete.HoverForeColor = System.Drawing.Color.Black;
            this.btnDelete.HoverOutline = System.Drawing.Color.Cornsilk;
            this.btnDelete.Image = null;
            this.btnDelete.ImageAutoCenter = true;
            this.btnDelete.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnDelete.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnDelete.Location = new System.Drawing.Point(956, 18);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.NormalBackground = System.Drawing.Color.Cornsilk;
            this.btnDelete.NormalForeColor = System.Drawing.Color.MidnightBlue;
            this.btnDelete.NormalImageTint = System.Drawing.Color.White;
            this.btnDelete.NormalOutline = System.Drawing.Color.Black;
            this.btnDelete.OutlineThickness = 1F;
            this.btnDelete.PressedBackground = System.Drawing.Color.DarkKhaki;
            this.btnDelete.PressedForeColor = System.Drawing.Color.White;
            this.btnDelete.PressedImageTint = System.Drawing.Color.White;
            this.btnDelete.PressedOutline = System.Drawing.Color.DarkKhaki;
            this.btnDelete.Rounding = new System.Windows.Forms.Padding(8);
            this.btnDelete.Size = new System.Drawing.Size(144, 45);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnDelete.TextOffset = new System.Drawing.Point(0, 0);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Bill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1267, 702);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvBills);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pbBack);
            this.Controls.Add(this.btnPrintBill);
            this.Controls.Add(this.dtpBillDate);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Bill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giao diện quản lý hóa đơn";
            this.Load += new System.EventHandler(this.Bill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CuoreUI.Controls.cuiCalendarDatePicker dtpBillDate;
        private CuoreUI.Controls.cuiButton btnPrintBill;
        private System.Windows.Forms.PictureBox pbBack;
        private CuoreUI.Controls.cuiButton btnRefresh;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvBills;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCreated;
        private CuoreUI.Controls.cuiButton btnDelete;
    }
}