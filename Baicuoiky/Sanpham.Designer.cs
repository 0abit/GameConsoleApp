namespace Baicuoiky
{
    partial class Sanpham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sanpham));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtProductName = new CuoreUI.Controls.cuiTextBox();
            this.txtProductPrice = new CuoreUI.Controls.cuiTextBox();
            this.btnAdd = new CuoreUI.Controls.cuiButton();
            this.btnAddPicture = new CuoreUI.Controls.cuiButton();
            this.btnEdit = new CuoreUI.Controls.cuiButton();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.btnDelete = new CuoreUI.Controls.cuiButton();
            this.pbProductImage = new System.Windows.Forms.PictureBox();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductImage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastModifiedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.Color.Transparent;
            this.txtProductName.BackgroundColor = System.Drawing.Color.White;
            this.txtProductName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtProductName.Content = "";
            this.txtProductName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProductName.FocusBackgroundColor = System.Drawing.Color.White;
            this.txtProductName.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.txtProductName.FocusImageTint = System.Drawing.Color.White;
            this.txtProductName.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.ForeColor = System.Drawing.Color.Gray;
            this.txtProductName.Image = null;
            this.txtProductName.ImageExpand = new System.Drawing.Point(0, 0);
            this.txtProductName.ImageOffset = new System.Drawing.Point(0, 0);
            this.txtProductName.Location = new System.Drawing.Point(24, 32);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductName.Multiline = false;
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.NormalImageTint = System.Drawing.Color.White;
            this.txtProductName.Padding = new System.Windows.Forms.Padding(25, 10, 25, 0);
            this.txtProductName.PasswordChar = false;
            this.txtProductName.PlaceholderColor = System.Drawing.SystemColors.WindowText;
            this.txtProductName.PlaceholderText = "Product name";
            this.txtProductName.Rounding = new System.Windows.Forms.Padding(8);
            this.txtProductName.Size = new System.Drawing.Size(360, 45);
            this.txtProductName.TabIndex = 1;
            this.txtProductName.TextOffset = new System.Drawing.Size(0, 0);
            this.txtProductName.UnderlinedStyle = true;
            // 
            // txtProductPrice
            // 
            this.txtProductPrice.BackColor = System.Drawing.Color.Transparent;
            this.txtProductPrice.BackgroundColor = System.Drawing.Color.White;
            this.txtProductPrice.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtProductPrice.Content = "";
            this.txtProductPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProductPrice.FocusBackgroundColor = System.Drawing.Color.White;
            this.txtProductPrice.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.txtProductPrice.FocusImageTint = System.Drawing.Color.White;
            this.txtProductPrice.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductPrice.ForeColor = System.Drawing.Color.Gray;
            this.txtProductPrice.Image = null;
            this.txtProductPrice.ImageExpand = new System.Drawing.Point(0, 0);
            this.txtProductPrice.ImageOffset = new System.Drawing.Point(0, 0);
            this.txtProductPrice.Location = new System.Drawing.Point(24, 98);
            this.txtProductPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductPrice.Multiline = false;
            this.txtProductPrice.Name = "txtProductPrice";
            this.txtProductPrice.NormalImageTint = System.Drawing.Color.White;
            this.txtProductPrice.Padding = new System.Windows.Forms.Padding(25, 10, 25, 0);
            this.txtProductPrice.PasswordChar = false;
            this.txtProductPrice.PlaceholderColor = System.Drawing.SystemColors.WindowText;
            this.txtProductPrice.PlaceholderText = "Product Price";
            this.txtProductPrice.Rounding = new System.Windows.Forms.Padding(8);
            this.txtProductPrice.Size = new System.Drawing.Size(360, 45);
            this.txtProductPrice.TabIndex = 3;
            this.txtProductPrice.TextOffset = new System.Drawing.Size(0, 0);
            this.txtProductPrice.UnderlinedStyle = true;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.CheckButton = false;
            this.btnAdd.Checked = false;
            this.btnAdd.CheckedBackground = System.Drawing.Color.DarkKhaki;
            this.btnAdd.CheckedForeColor = System.Drawing.Color.White;
            this.btnAdd.CheckedImageTint = System.Drawing.Color.White;
            this.btnAdd.CheckedOutline = System.Drawing.Color.DarkKhaki;
            this.btnAdd.Content = "Add";
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnAdd.HoverBackground = System.Drawing.Color.Cornsilk;
            this.btnAdd.HoveredImageTint = System.Drawing.Color.MidnightBlue;
            this.btnAdd.HoverForeColor = System.Drawing.Color.Black;
            this.btnAdd.HoverOutline = System.Drawing.Color.Cornsilk;
            this.btnAdd.Image = null;
            this.btnAdd.ImageAutoCenter = true;
            this.btnAdd.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnAdd.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnAdd.Location = new System.Drawing.Point(24, 219);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.NormalBackground = System.Drawing.Color.Cornsilk;
            this.btnAdd.NormalForeColor = System.Drawing.Color.MidnightBlue;
            this.btnAdd.NormalImageTint = System.Drawing.Color.White;
            this.btnAdd.NormalOutline = System.Drawing.Color.Black;
            this.btnAdd.OutlineThickness = 1F;
            this.btnAdd.PressedBackground = System.Drawing.Color.DarkKhaki;
            this.btnAdd.PressedForeColor = System.Drawing.Color.White;
            this.btnAdd.PressedImageTint = System.Drawing.Color.White;
            this.btnAdd.PressedOutline = System.Drawing.Color.DarkKhaki;
            this.btnAdd.Rounding = new System.Windows.Forms.Padding(8);
            this.btnAdd.Size = new System.Drawing.Size(144, 45);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnAdd.TextOffset = new System.Drawing.Point(0, 0);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddPicture
            // 
            this.btnAddPicture.BackColor = System.Drawing.Color.Transparent;
            this.btnAddPicture.CheckButton = false;
            this.btnAddPicture.Checked = false;
            this.btnAddPicture.CheckedBackground = System.Drawing.Color.DarkKhaki;
            this.btnAddPicture.CheckedForeColor = System.Drawing.Color.White;
            this.btnAddPicture.CheckedImageTint = System.Drawing.Color.White;
            this.btnAddPicture.CheckedOutline = System.Drawing.Color.DarkKhaki;
            this.btnAddPicture.Content = "Add picture";
            this.btnAddPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPicture.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddPicture.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPicture.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnAddPicture.HoverBackground = System.Drawing.Color.Cornsilk;
            this.btnAddPicture.HoveredImageTint = System.Drawing.Color.MidnightBlue;
            this.btnAddPicture.HoverForeColor = System.Drawing.Color.Black;
            this.btnAddPicture.HoverOutline = System.Drawing.Color.Cornsilk;
            this.btnAddPicture.Image = null;
            this.btnAddPicture.ImageAutoCenter = true;
            this.btnAddPicture.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnAddPicture.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnAddPicture.Location = new System.Drawing.Point(927, 244);
            this.btnAddPicture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddPicture.Name = "btnAddPicture";
            this.btnAddPicture.NormalBackground = System.Drawing.Color.Cornsilk;
            this.btnAddPicture.NormalForeColor = System.Drawing.Color.MidnightBlue;
            this.btnAddPicture.NormalImageTint = System.Drawing.Color.White;
            this.btnAddPicture.NormalOutline = System.Drawing.Color.Black;
            this.btnAddPicture.OutlineThickness = 1F;
            this.btnAddPicture.PressedBackground = System.Drawing.Color.DarkKhaki;
            this.btnAddPicture.PressedForeColor = System.Drawing.Color.White;
            this.btnAddPicture.PressedImageTint = System.Drawing.Color.White;
            this.btnAddPicture.PressedOutline = System.Drawing.Color.DarkKhaki;
            this.btnAddPicture.Rounding = new System.Windows.Forms.Padding(8);
            this.btnAddPicture.Size = new System.Drawing.Size(144, 45);
            this.btnAddPicture.TabIndex = 6;
            this.btnAddPicture.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnAddPicture.TextOffset = new System.Drawing.Point(0, 0);
            this.btnAddPicture.Click += new System.EventHandler(this.btnAddPicture_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.CheckButton = false;
            this.btnEdit.Checked = false;
            this.btnEdit.CheckedBackground = System.Drawing.Color.DarkKhaki;
            this.btnEdit.CheckedForeColor = System.Drawing.Color.White;
            this.btnEdit.CheckedImageTint = System.Drawing.Color.White;
            this.btnEdit.CheckedOutline = System.Drawing.Color.DarkKhaki;
            this.btnEdit.Content = "Edit";
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEdit.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnEdit.HoverBackground = System.Drawing.Color.Cornsilk;
            this.btnEdit.HoveredImageTint = System.Drawing.Color.MidnightBlue;
            this.btnEdit.HoverForeColor = System.Drawing.Color.Black;
            this.btnEdit.HoverOutline = System.Drawing.Color.Cornsilk;
            this.btnEdit.Image = null;
            this.btnEdit.ImageAutoCenter = true;
            this.btnEdit.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnEdit.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnEdit.Location = new System.Drawing.Point(174, 219);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.NormalBackground = System.Drawing.Color.Cornsilk;
            this.btnEdit.NormalForeColor = System.Drawing.Color.MidnightBlue;
            this.btnEdit.NormalImageTint = System.Drawing.Color.White;
            this.btnEdit.NormalOutline = System.Drawing.Color.Black;
            this.btnEdit.OutlineThickness = 1F;
            this.btnEdit.PressedBackground = System.Drawing.Color.DarkKhaki;
            this.btnEdit.PressedForeColor = System.Drawing.Color.White;
            this.btnEdit.PressedImageTint = System.Drawing.Color.White;
            this.btnEdit.PressedOutline = System.Drawing.Color.DarkKhaki;
            this.btnEdit.Rounding = new System.Windows.Forms.Padding(8);
            this.btnEdit.Size = new System.Drawing.Size(144, 45);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnEdit.TextOffset = new System.Drawing.Point(0, 0);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // pbBack
            // 
            this.pbBack.BackColor = System.Drawing.Color.Transparent;
            this.pbBack.ErrorImage = null;
            this.pbBack.Image = ((System.Drawing.Image)(resources.GetObject("pbBack.Image")));
            this.pbBack.InitialImage = null;
            this.pbBack.Location = new System.Drawing.Point(1009, 12);
            this.pbBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(78, 59);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBack.TabIndex = 18;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.pbBack_Click);
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
            this.btnDelete.Content = "Delete";
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
            this.btnDelete.Location = new System.Drawing.Point(324, 219);
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
            this.btnDelete.TabIndex = 19;
            this.btnDelete.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnDelete.TextOffset = new System.Drawing.Point(0, 0);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pbProductImage
            // 
            this.pbProductImage.Location = new System.Drawing.Point(567, 12);
            this.pbProductImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbProductImage.Name = "pbProductImage";
            this.pbProductImage.Size = new System.Drawing.Size(336, 278);
            this.pbProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProductImage.TabIndex = 20;
            this.pbProductImage.TabStop = false;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudQuantity.Location = new System.Drawing.Point(24, 161);
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(360, 32);
            this.nudQuantity.TabIndex = 21;
            // 
            // kryptonDataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Cornsilk;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.kryptonDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.kryptonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kryptonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.ProductName,
            this.Price,
            this.Quantity,
            this.ProductImage,
            this.LastModifiedDate});
            this.kryptonDataGridView1.Location = new System.Drawing.Point(24, 305);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.RowHeadersWidth = 62;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cornsilk;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.kryptonDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.kryptonDataGridView1.RowTemplate.Height = 28;
            this.kryptonDataGridView1.Size = new System.Drawing.Size(1046, 501);
            this.kryptonDataGridView1.TabIndex = 22;
            this.kryptonDataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.kryptonDataGridView1_CellClick);
            this.kryptonDataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.kryptonDataGridView1_RowPostPaint);
            // 
            // ProductId
            // 
            this.ProductId.HeaderText = "";
            this.ProductId.MinimumWidth = 8;
            this.ProductId.Name = "ProductId";
            this.ProductId.Visible = false;
            this.ProductId.Width = 150;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Product name";
            this.ProductName.MinimumWidth = 8;
            this.ProductName.Name = "ProductName";
            this.ProductName.Width = 250;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 8;
            this.Price.Name = "Price";
            this.Price.Width = 200;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 8;
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 140;
            // 
            // ProductImage
            // 
            this.ProductImage.HeaderText = "Product image";
            this.ProductImage.MinimumWidth = 8;
            this.ProductImage.Name = "ProductImage";
            this.ProductImage.Width = 235;
            // 
            // LastModifiedDate
            // 
            this.LastModifiedDate.HeaderText = "Last Modified Date";
            this.LastModifiedDate.MinimumWidth = 8;
            this.LastModifiedDate.Name = "LastModifiedDate";
            this.LastModifiedDate.Width = 200;
            // 
            // Sanpham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1099, 830);
            this.Controls.Add(this.kryptonDataGridView1);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.pbProductImage);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.pbBack);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAddPicture);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtProductPrice);
            this.Controls.Add(this.txtProductName);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Sanpham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giao diện sản phẩm";
            this.Load += new System.EventHandler(this.Sanpham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProductImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CuoreUI.Controls.cuiTextBox txtProductName;
        private CuoreUI.Controls.cuiTextBox txtProductPrice;
        private CuoreUI.Controls.cuiButton btnAdd;
        private CuoreUI.Controls.cuiButton btnAddPicture;
        private CuoreUI.Controls.cuiButton btnEdit;
        private System.Windows.Forms.PictureBox pbBack;
        private CuoreUI.Controls.cuiButton btnDelete;
        private System.Windows.Forms.PictureBox pbProductImage;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastModifiedDate;
    }
}