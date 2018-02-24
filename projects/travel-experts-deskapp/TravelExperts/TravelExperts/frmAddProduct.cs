using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using TravelExperts.ClassesDB;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// Author: Dmitry
/// </summary>
namespace TravelExperts
{
    public partial class frmAddProduct : Form
    {
        private Products currentProduct;
        bool add = false;
        public frmAddProduct()
        {
            InitializeComponent();
            this.Text = "New Product";
            add = true;
        }

        // constructor
        public frmAddProduct(Products p)
        {
            InitializeComponent();
            currentProduct = p;
            txtEnterProductName.Text = p.ProductName;
            this.Text = "Edit Product";
            if (ProductsImagesDB.GetImage(p.ProductID) == null)
            {
                picAddProductBox.Image = Image.FromFile(@"../../Images/default_logo.png");
            }
            else
            {
                MemoryStream ms = new MemoryStream(ProductsImagesDB.GetImage(p.ProductID));
                picAddProductBox.Image = Image.FromStream(ms);
            }
        }

        // use file explorer to look for the file
        private void btnOpenProductFileDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picAddProductBox.Image = new Bitmap(ofd.FileName);
            }
        }

        // Update product if it exist already or create new one
        private void SaveProduct()
        {
            if (add) // creates new product
            {
                currentProduct = new Products();
                currentProduct.ProductID = ProductsDB.AddProduct(txtEnterProductName.Text);
                currentProduct.ProductName = txtEnterProductName.Text;
                ConvertImage();
                add = false;
            }
            else // Update existing product
            {
                Products newProduct = new Products()
                {
                    ProductID = currentProduct.ProductID,
                    ProductName = txtEnterProductName.Text,
                };
                ConvertImage();                
                ProductsDB.UpdateProduct(currentProduct, newProduct);
            }
        }

        private void ConvertImage()
        {
            //converting photo to binary data and savig it to database
            if (picAddProductBox.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                picAddProductBox.Image.Save(ms, ImageFormat.Jpeg);
                byte[] photoAray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photoAray, 0, photoAray.Length);
                ProductsImagesDB.AddNewProductImage(photoAray, currentProduct.ProductID);
            }
        }

        // Action on button click, checks if name of the prodcut was entered
        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            if (txtEnterProductName.Text != "")
            {
                SaveProduct();
                this.DialogResult = DialogResult.OK;
            }
            else // If name is missing , show error message and set background color of text box in red
            {
                MessageBox.Show("Enter name for this product");
                txtEnterProductName.BackColor = Color.Red;
            }

        }

        // When focus textbox it's color returs to default
        private void txtEnterProductName_Enter(object sender, EventArgs e)
        {
            txtEnterProductName.BackColor = default(Color);
        }
    }
}
