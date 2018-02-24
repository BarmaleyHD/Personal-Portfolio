using System.Windows.Forms;

namespace TravelExperts
{
    partial class frmAddProduct
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddProCancel = new System.Windows.Forms.Button();
            this.btnSaveProduct = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOpenProductFileDialog = new System.Windows.Forms.Button();
            this.picAddProductBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEnterProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAddProductBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtEnterProductName, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(294, 409);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnAddProCancel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSaveProduct, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 368);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(288, 38);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnAddProCancel
            // 
            this.btnAddProCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddProCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddProCancel.Location = new System.Drawing.Point(147, 3);
            this.btnAddProCancel.Name = "btnAddProCancel";
            this.btnAddProCancel.Size = new System.Drawing.Size(138, 32);
            this.btnAddProCancel.TabIndex = 1;
            this.btnAddProCancel.Text = "Cancel";
            this.btnAddProCancel.UseVisualStyleBackColor = true;
            // 
            // btnSaveProduct
            // 
            this.btnSaveProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveProduct.Location = new System.Drawing.Point(3, 3);
            this.btnSaveProduct.Name = "btnSaveProduct";
            this.btnSaveProduct.Size = new System.Drawing.Size(138, 32);
            this.btnSaveProduct.TabIndex = 0;
            this.btnSaveProduct.Text = "Save";
            this.btnSaveProduct.UseVisualStyleBackColor = true;
            this.btnSaveProduct.Click += new System.EventHandler(this.btnSaveProduct_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.btnOpenProductFileDialog, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.picAddProductBox, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(288, 198);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // btnOpenProductFileDialog
            // 
            this.btnOpenProductFileDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenProductFileDialog.Location = new System.Drawing.Point(60, 161);
            this.btnOpenProductFileDialog.Name = "btnOpenProductFileDialog";
            this.btnOpenProductFileDialog.Size = new System.Drawing.Size(166, 34);
            this.btnOpenProductFileDialog.TabIndex = 1;
            this.btnOpenProductFileDialog.Text = "Open Picture";
            this.btnOpenProductFileDialog.UseVisualStyleBackColor = true;
            this.btnOpenProductFileDialog.Click += new System.EventHandler(this.btnOpenProductFileDialog_Click);
            // 
            // picAddProductBox
            // 
            this.picAddProductBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picAddProductBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picAddProductBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picAddProductBox.Location = new System.Drawing.Point(60, 3);
            this.picAddProductBox.Name = "picAddProductBox";
            this.picAddProductBox.Size = new System.Drawing.Size(166, 152);
            this.picAddProductBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAddProductBox.TabIndex = 0;
            this.picAddProductBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(3, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Product Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtEnterProductName
            // 
            this.txtEnterProductName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtEnterProductName.Location = new System.Drawing.Point(62, 287);
            this.txtEnterProductName.Name = "txtEnterProductName";
            this.txtEnterProductName.Size = new System.Drawing.Size(170, 20);
            this.txtEnterProductName.TabIndex = 3;
            this.txtEnterProductName.Enter += new System.EventHandler(this.txtEnterProductName_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 40);
            this.label2.TabIndex = 4;
            this.label2.Text = "Recommended format: .png 120x120";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // frmAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 409);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmAddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAddProductBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnAddProCancel;
        private System.Windows.Forms.Button btnSaveProduct;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnOpenProductFileDialog;
        private System.Windows.Forms.PictureBox picAddProductBox;
        private Label label1;
        private TextBox txtEnterProductName;
        private Label label2;
    }
}