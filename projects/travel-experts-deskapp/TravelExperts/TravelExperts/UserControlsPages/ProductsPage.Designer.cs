namespace TravelExperts.UserControlsPages
{
    partial class ProductsPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeleteProducts = new System.Windows.Forms.Button();
            this.btnEditProducts = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.flpDisplayAllProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.flpSuppliers = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(978, 508);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel9, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.flpDisplayAllProducts, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(674, 498);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel9.Controls.Add(this.btnDeleteProducts, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.btnEditProducts, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.btnAddProduct, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(5, 449);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(664, 44);
            this.tableLayoutPanel9.TabIndex = 2;
            // 
            // btnDeleteProducts
            // 
            this.btnDeleteProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteProducts.Location = new System.Drawing.Point(445, 3);
            this.btnDeleteProducts.Name = "btnDeleteProducts";
            this.btnDeleteProducts.Size = new System.Drawing.Size(216, 38);
            this.btnDeleteProducts.TabIndex = 2;
            this.btnDeleteProducts.Text = "Delete";
            this.btnDeleteProducts.UseVisualStyleBackColor = true;
            this.btnDeleteProducts.Click += new System.EventHandler(this.btnDeleteProducts_Click);
            // 
            // btnEditProducts
            // 
            this.btnEditProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditProducts.Location = new System.Drawing.Point(224, 3);
            this.btnEditProducts.Name = "btnEditProducts";
            this.btnEditProducts.Size = new System.Drawing.Size(215, 38);
            this.btnEditProducts.TabIndex = 1;
            this.btnEditProducts.Text = "Edit";
            this.btnEditProducts.UseVisualStyleBackColor = true;
            this.btnEditProducts.Click += new System.EventHandler(this.btnEditProducts_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddProduct.Location = new System.Drawing.Point(3, 3);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(215, 38);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "Add";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // flpDisplayAllProducts
            // 
            this.flpDisplayAllProducts.AutoScroll = true;
            this.flpDisplayAllProducts.CausesValidation = false;
            this.flpDisplayAllProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDisplayAllProducts.Location = new System.Drawing.Point(5, 5);
            this.flpDisplayAllProducts.Name = "flpDisplayAllProducts";
            this.flpDisplayAllProducts.Size = new System.Drawing.Size(664, 436);
            this.flpDisplayAllProducts.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.flpSuppliers, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(687, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(286, 498);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "This product supplied:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpSuppliers
            // 
            this.flpSuppliers.AutoScroll = true;
            this.flpSuppliers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpSuppliers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSuppliers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSuppliers.Location = new System.Drawing.Point(3, 141);
            this.flpSuppliers.Name = "flpSuppliers";
            this.flpSuppliers.Size = new System.Drawing.Size(280, 354);
            this.flpSuppliers.TabIndex = 1;
            this.flpSuppliers.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtProductName);
            this.panel1.Controls.Add(this.txtProductID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 93);
            this.panel1.TabIndex = 2;
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(143, 49);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(100, 25);
            this.txtProductName.TabIndex = 3;
            // 
            // txtProductID
            // 
            this.txtProductID.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductID.Location = new System.Drawing.Point(143, 19);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.ReadOnly = true;
            this.txtProductID.Size = new System.Drawing.Size(100, 25);
            this.txtProductID.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Product Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Product ID: ";
            // 
            // ProductsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProductsPage";
            this.Size = new System.Drawing.Size(978, 508);
            this.Load += new System.EventHandler(this.ProductsPage_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flpDisplayAllProducts;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Button btnDeleteProducts;
        private System.Windows.Forms.Button btnEditProducts;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpSuppliers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
