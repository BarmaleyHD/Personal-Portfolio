using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExperts.ClassesDB;
/// <summary>
/// Date: 1/1/2018
/// Author: Dmitry
/// </summary>
namespace TravelExperts.UserControlsPages
{
    public partial class ProductsPage : UserControl
    {
        List<Button> buttonList;
        Products currentProduct;
        public ProductsPage()
        {
            InitializeComponent();
        }

        private void ProductsPage_Load(object sender, EventArgs e)
        {
            RefreshProducts();
        }

        private void SetButtonActionEvent(List<Button> bt)
        {
            foreach (Button btn in buttonList)
            {
                btn.Click += (sender, e) =>
                {
                    flpSuppliers.Controls.Clear();
                    currentProduct = (Products)btn.Tag;
                    List<Suppliers> supList = PackagesProductsSupplierDB.GetProductSuppliersList(currentProduct.ProductID);
                    txtProductID.Text = currentProduct.ProductID.ToString();
                    txtProductName.Text = currentProduct.ProductName;
                    DisplaySuppliersForProduct();
                };

                btn.LostFocus += (sender, e) =>
                {
                    //txtProductID.Text = "";
                    //txtProductName.Text = "";
                    //lblPkgProductSupplier.Text = "";
                    //currentProduct = null;
                };
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmAddProduct form = new frmAddProduct();
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
                RefreshProducts();
        }

        // Opens form for editing selected Product
        private void btnEditProducts_Click(object sender, EventArgs e)
        {
            if (currentProduct == null)
            {
                MessageBox.Show("Select Product first");
            }
            else
            {
                frmAddProduct form = new frmAddProduct(currentProduct);
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK)
                    RefreshProducts();
            }
        }

        private void RefreshProducts()
        {
            flpSuppliers.Controls.Clear();
            buttonList = DisplayGui.DisplayAllProducts(flpDisplayAllProducts);
            SetButtonActionEvent(buttonList);
        }

        private void btnDeleteProducts_Click(object sender, EventArgs e)
        {
            int used = ProductsDB.CheckInUse(currentProduct.ProductID);
            if (currentProduct == null)
            {
                MessageBox.Show("Select Product first");
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Delete " + currentProduct.ProductName + "?", "Delete product", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes && ProductsDB.DeleteProduct(currentProduct))
                    {
                        RefreshProducts();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You can't deleete this products, it's in use \n", "Message" );
                    ErrorLog.SaveException(ex);
                }
            }
        }

        public void DisplaySuppliersForProduct()
        {
            List<Suppliers> supList = SuppliersDB.GetProductSuppliers(currentProduct.ProductID);
            foreach (Suppliers s in supList)
            {
                Button btn = DisplayGui.CreateResponsiveTextButton(s);
                flpSuppliers.Controls.Add(btn);
                btn.Width = flpSuppliers.Width - 25;
            }
        }
    }
}
