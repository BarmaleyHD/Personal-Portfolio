using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using TravelExperts.TableClasses;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExperts.UserControlsPages;
using TravelExperts.ClassesDB;
/// <summary>
/// Author: Dmitry
/// Purpose: Main form for all programm, contains TabPanel that have tab for every page of the programm.
/// Contains built in pages like MainPage, Package page and Settings page
/// Contains navigation bar on left side
/// </summary>
namespace TravelExperts
{
    public partial class frmMain : Form
    {
        private Packages package; 
        private Packages currentPackage; // Selected Package
        private List<Button> buttonList; // Current button List
        private Products currentProduct; // Selected product
        int currentRow; // Current row selected in Package page gridview
        private int currentPackageID; // Current packageId selected on Package page
        bool editMode = false; // Show is editMode is on \ off
        bool PSAdded = false; // Show status of Product Supplier page
        enum Pages { Packages, Products, Suppliers, ProductSuppliers, WelcomePage, Settings } // Represents name of pages

        public frmMain()
        {
            InitializeComponent();
            tabMain.ItemSize = new Size(0, 1); // Puts size of TabPanel higher than for to hide tab navigation
            tabMain.SizeMode = TabSizeMode.Fixed; // Set all tabs in the control to same width
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = (int)Pages.WelcomePage; // On load starting page is always welcome page
            lblWelcome.BackColor = Color.FromArgb(1, 255, 255, 255); // Label for adding in future welcome text is set to be transperent
        }



        //         --- NAVIGATION MENU ---


        // Makes lbl clickable and leads to welcome page
        private void lblMain_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = (int)Pages.WelcomePage;
        }
        // Button on navigation panel represents Settings page
        private void btnSettings_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = (int)Pages.Settings;
        }
        // Button on navigation panel represents Product page
        private void btnNavProducts_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = (int)Pages.Products; // on click select
            ProductsPage pp = new ProductsPage(); // create new object of ProdcutPage UserControl
            pp.Dock = DockStyle.Fill; // Set so it fills all available space
            tabProducts.Controls.Add(pp); // adding new page to tabProduct tab
        }
        
        // Close button on navigation bar, closes all program not just current window
        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1); // Close whole program
        }

        // Button on navigation panel represents Product page
        private void btnNavPackages_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = (int)Pages.Packages;
            DisplayGui.FillGridView(gridPackages, PackagesDB.GetPackageDataSet());
            cmbSort.SelectedIndex = 0;
        }
        // Button on navigation panel represents Suppliers page
        private void btnPPS_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = (int)Pages.Suppliers;
        }
        // Button on navigation panel represents ProductSuppliers page
        private void btnNavProductSuppliers_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = (int)Pages.ProductSuppliers;
            if (PSAdded == false)
            {
                PSAdded = true;
            }
        }


        //         --- PACKAGES PAGE ---
      
        // Button on Package page Display all Packages in gridView
        private void btnPkgDisplayAll_Click(object sender, EventArgs e)
        {
            if (editMode != true)
            {
                ClearDisplayArea();
                DisplayGui.FillGridView(gridPackages, PackagesDB.GetPackageDataSet());
            }
        }

        // Adding Product to selected Package
        private void btnPkgAddProduct_Click(object sender, EventArgs e)
        {
            if (currentPackageID > 0 && editMode == false) // Check if Package selected and not in edit mode
            {
                frmAddPackageProduct form = new frmAddPackageProduct(currentPackageID); // creates form for adding new Product and passing Id of selected Package
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK) // If dialog window closed with Ok button 
                {
                    DisplayGui.FillGridView(gridPackages, PackagesDB.GetPackageDataSet()); // Update grid view by loading data from database
                    gridPackages.ClearSelection();
                    SelectRowForPackage(currentPackageID.ToString());
                }
            }
            DisplayCurrentPackage();
        }

        // Displays selected Package in display area from a row in DataGridView
        private void gridPackages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridPackages.SelectedCells.Count > 0)
            {
                currentRow = gridPackages.SelectedCells[0].RowIndex;
                if (gridPackages.Rows[currentRow] != null)
                {
                    DataGridViewRow selectedRow = gridPackages.Rows[currentRow];
                    if (Int32.TryParse(selectedRow.Cells["PackageID"].Value.ToString(), out currentPackageID))
                    {
                        DisplayCurrentPackage();
                    }
                }
            }
        }

        // Displays current package read from database in the Display area
        private void DisplayCurrentPackage()
        {
            if (currentPackageID > 0)
            {
                package = PackagesDB.GetPackage(currentPackageID);
                txtPkgID.Text = package.PackageID.ToString();
                txtPkgName.Text = package.PackageName.ToString();
                txtPkgDesc.Text = package.PackageDescription;
                dtpPkgStart.Value = package.PackageStartDate;
                dtpPkgEnd.Value = package.PackageEndDate;
                txtPkgPrice.Text = package.PackageBasePrice.ToString("C");
                txtPkgCommision.Text = package.PackageAgencyCommission.ToString("C");
                buttonList = DisplayGui.DisplayPackageProducts(currentPackageID, flpProducts);
                ProductButtonClickEvent(buttonList);
            }
        }

        // Adds event to all creates Product Buttons\Icons 
        private void ProductButtonClickEvent(List<Button> buttonList)
        {
            Suppliers sup;
            foreach (Button btn in buttonList)
            {
                btn.Click += (sender, e) => // sets up Click event Listener
                    {                        
                        currentProduct = (Products)btn.Tag; // Gets Product that buttons\icon represents from it's tag
                        lblPkgProductID.Text = currentProduct.ProductID.ToString();
                        lblPkgProductName.Text = currentProduct.ProductName;
                        sup = SuppliersDB.GetSupplierForTheProduct(currentProduct.ProductID, currentPackageID); // Gets from database supplier that supplies this product to current package
                        lblPkgProductSupplier.Text = sup.SupplierName;
                    };
                btn.LostFocus += (sender, e) => // sets up event Listener when burrent button\icon loose control
                {
                    lblPkgProductID.Text = "";
                    lblPkgProductName.Text = "";
                    lblPkgProductSupplier.Text = "";
                    //currentProduct = null;
                };
            }
        }

        // Enables blank display area
        private void btnPkgAdd_Click(object sender, EventArgs e)
        {
            if (editMode == false)
            {
                editMode = true;
                ClearDisplayArea();
                EnableControls();
            }
        }

        // Clear all controls in display area
        private void ClearDisplayArea()
        {
            txtPkgID.Clear();
            txtPkgName.Clear();
            txtPkgDesc.Clear();
            dtpPkgStart.Value = DateTime.Today;
            dtpPkgEnd.Value = DateTime.Today;
            txtPkgPrice.Clear();
            txtPkgCommision.Clear();
            flpProducts.Controls.Clear();
        }

        // Enables all controls in display area
        private void EnableControls()
        {
            txtPkgName.ReadOnly = false;
            txtPkgDesc.ReadOnly = false;
            dtpPkgStart.Enabled = true;
            dtpPkgEnd.Enabled = true;
            txtPkgPrice.ReadOnly = false;
            txtPkgCommision.ReadOnly = false;
            btnPkgSave.Enabled = true;
        }

        // Makes all constrols read only to prevent editing data 
        private void DisableControls()
        {
            txtPkgName.ReadOnly = true;
            txtPkgDesc.ReadOnly = true;
            dtpPkgStart.Enabled = false;
            dtpPkgEnd.Enabled = false;
            txtPkgPrice.ReadOnly = true;
            txtPkgCommision.ReadOnly = true;
            btnPkgSave.Enabled = false;
        }

        // Grabs data from display area, creates Packages object and saves it to database
        private void BtnPkgSave_Click(object sender, EventArgs e)
        {
            package = new Packages();
            // Checks all input data for right format
            if (Validator.IsPresent(txtPkgName, "Enter Package Name") && Validator.IsPresent(txtPkgDesc, "Enter Description") &&
                Validator.IsDecimal(txtPkgPrice, "Base price") && Validator.IsDecimal(txtPkgCommision, "Commision") &&
                Validator.IsNonNegativeDouble(txtPkgPrice, "Price") && Validator.IsNonNegativeDouble(txtPkgCommision, "Commision") &&
                Validator.IsLessThan(txtPkgPrice, txtPkgCommision, "Base price" , "Commision"))
            {
                // gets data from input controls
                package.PackageName = txtPkgName.Text;
                package.PackageDescription = txtPkgDesc.Text;
                package.PackageBasePrice = decimal.Parse(txtPkgPrice.Text.ToString(), NumberStyles.AllowCurrencySymbol | NumberStyles.Number);
                package.PackageAgencyCommission = decimal.Parse(txtPkgCommision.Text.ToString(), NumberStyles.AllowCurrencySymbol | NumberStyles.Number);
                package.PackageStartDate = dtpPkgStart.Value;
                package.PackageEndDate = dtpPkgEnd.Value;
                if (txtPkgID.Text == "") // if package Id empty -> we creating new package
                {
                    currentPackageID = PackagesDB.AddNewPackage(package); 
                }
                else // if there was ID means we updating existing package
                {

                    package.PackageID = Convert.ToInt32(txtPkgID.Text);
                    if (!PackagesDB.UpdatePackage(currentPackage, package)) // I DB class returng false means was unable to update
                    {
                        MessageBox.Show("Another user has updated or " +
                            "deleted this package. List updated!.", "Database Error");
                        this.DialogResult = DialogResult.Retry;
                    }
                    DisplayCurrentPackage();
                }
            DisplayGui.FillGridView(gridPackages, PackagesDB.GetPackageDataSet()); // update gridview
            gridPackages.ClearSelection();
            SelectRowForPackage(currentPackageID.ToString());
            //ClearDisplayArea();
            DisableControls();
            editMode = false;
            }       
        }

        // Enables Display area and populates it with selected Package data
        private void btnPkgEdit_Click(object sender, EventArgs e)
        {
            if (editMode == false)
            {
                if (txtPkgID.Text != "") // check if user selecte package
                {
                    currentPackage = new Packages()
                    {
                        PackageID = Convert.ToInt32(txtPkgID.Text),
                        PackageName = txtPkgName.Text.ToString(),
                        PackageDescription = txtPkgDesc.Text,
                        PackageStartDate = dtpPkgStart.Value,
                        PackageEndDate = dtpPkgEnd.Value,
                        PackageBasePrice = decimal.Parse(txtPkgPrice.Text.ToString(), NumberStyles.AllowCurrencySymbol | NumberStyles.Number),
                        PackageAgencyCommission = decimal.Parse(txtPkgCommision.Text.ToString(), NumberStyles.AllowCurrencySymbol | NumberStyles.Number)
                    };
                    EnableControls();
                    editMode = true;
                }
                else
                {
                    MessageBox.Show("Choose Package from list");
                }
            }
        }

        //Clears and disables display area
        private void btnPkgCencel_Click(object sender, EventArgs e)
        {
            ClearDisplayArea();
            DisableControls();
            editMode = false;
        }

        // If existing package diplay PackageId
        public void DisplayProductInfo(Products p)
        {
            lblPkgProductID.Text = p.ProductID.ToString();
        }

        // Test panel for extra functionality
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.D1)
            {
                Form f3 = new Form();
                Label l = new Label();
                l.Text = "Secret Form";
                f3.Controls.Add(l);
                f3.ShowDialog();
            }
        }        

        // Action for Button click
        private void btnSelectControlColor_Click(object sender, EventArgs e)
        {
            ChangeColor<Button>(GetColor());
        }      
        
        // Opening ColorDialog , let user to select color and return selected color
        private Color GetColor()
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = btnExit.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                return MyDialog.Color;
            return btnExit.BackColor;
        }

        // Receives color and type of control when called and changes this contol color
        private void ChangeColor<T>(Color color)
        {
            foreach (Control c in tlpNav.Controls)
            {
                if (c.GetType() == typeof(T))
                    c.BackColor = color;
            }
        }
        // Changin contol of the text in given control type 
        private void ChangeTextColor<T>(Color color)
        {
            foreach (Control c in tlpNav.Controls)
            {
                if (c.GetType() == typeof(T))
                    c.ForeColor = color;
            }
        }
        // Action butoon for changing background color
        private void btnBGColor_Click(object sender, EventArgs e)
        {
            Color col = GetColor();
            tlpNav.BackColor = col;
            tabSettings.BackColor = col;
        }
        
        private void btnLableColor_Click(object sender, EventArgs e)
        {
            Color color = GetColor();
            ChangeColor<Label>(color);
        }

        private void btnTextColor_Click(object sender, EventArgs e)
        {
            Color color = GetColor();
            ChangeTextColor<Label>(color);
        }

        private void btnButtonTextColor_Click(object sender, EventArgs e)
        {
            ChangeTextColor<Button>(GetColor());
        }

        // Default button clock action that reset all color to default
        private void btnDefault_Click(object sender, EventArgs e)
        {
            ChangeTextColor<Button>(Color.Black);
            ChangeTextColor<Label>(Color.Black);
            ChangeColor<Button>(Color.Aqua);
            ChangeColor<Label>(Color.Aqua);
            tlpNav.BackColor = Color.Teal;
            tabSettings.BackColor = default(Color);
        }

        // Event listener for button search on Package page
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClearDisplayArea();
            //  validates input
            if (Validator.IsPresent(txtInput, "Enter " + cmbSort.SelectedItem ))
            {
                List<Packages> pkg = PackagesDB.GetPackagesList();
                if (cmbSort.SelectedIndex == 0) // find by Package name
                {
                    string name = txtInput.Text;
                    // finds in the list by giveb creteria
                    List<Packages> newPkg = pkg.FindAll(x => x.PackageName.ToLower().Contains(name.ToLower()));
                    gridPackages.DataSource = newPkg;
                }
                else // find by Package ID
                { 
                    // validates input
                    if (Validator.IsInt32(txtInput, "ID" ))
                    {
                        int ID = Convert.ToInt32(txtInput.Text);
                        // finds in the list by given crateria
                        List<Packages> newPkg = pkg.FindAll(x => x.PackageID.Equals(ID));
                        gridPackages.DataSource = newPkg;
                    }
                }

            }
        }

        // Action when click on Product delete button
        private void btnPkgDeleteProduct_Click(object sender, EventArgs e)
        {
            if (currentPackageID > 0 && currentProduct != null) // validates
            {
                // confirmation window
                if (MessageBox.Show("Delete " + currentProduct.ProductName + "?", "Delete product", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    PackagesProductsSupplierDB.DeletePPS(currentPackageID, currentProduct.ProductID);
                }
                DisplayGui.FillGridView(gridPackages, PackagesDB.GetPackageDataSet()); // Update grid view by loading data from database
                DisplayCurrentPackage();
                gridPackages.ClearSelection();
                SelectRowForPackage(currentPackageID.ToString());
            }
        }
        // If date is changed validate it
        private void dtpPkgEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpPkgEnd.Value < dtpPkgStart.Value && editMode == true)
            {
                MessageBox.Show("End Date can't be earlier than Start Date");
                dtpPkgEnd.Value = dtpPkgStart.Value.AddDays(1);
            }
        }
        // Action when click on Package delete button
        private void btnPkgDelete_Click(object sender, EventArgs e)
        {
            if (editMode != true || MessageBox.Show("Delete " + currentProduct.ProductName + "?", "Delete product", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    PackagesDB.DeletePackage(currentPackageID);
                    DisplayGui.FillGridView(gridPackages, PackagesDB.GetPackageDataSet()); // Update grid view by loading data from databas
                    ClearDisplayArea();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You can't delete this package, it contains Products or was Booked", "Message");
                    ErrorLog.SaveException(ex);
                }
            }
        }

        // After some actions selects row with current package
        private void SelectRowForPackage(string value)
        {
            int rowIndex = -1;
            DataGridViewRow row = gridPackages.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells["PackageId"].Value.ToString().Equals(value))
                .First();

            rowIndex = row.Index;
            gridPackages.Rows[rowIndex].Selected = true;
        }

        // If date is changed validate it
        private void dtpPkgStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpPkgStart.Value < DateTime.Today && editMode == true)
            {
                MessageBox.Show("Start Date can't be in past");
                dtpPkgStart.Value = DateTime.Today;
            }
        }
    }
}

