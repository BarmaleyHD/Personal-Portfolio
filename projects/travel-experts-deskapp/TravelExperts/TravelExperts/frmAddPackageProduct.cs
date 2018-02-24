using System.Collections.Generic;
using System.Drawing;
using TravelExperts.TableClasses;
using System.Windows.Forms;
using TravelExperts.ClassesDB;

/// <summary>
/// Author: Dmitry Nagorny
/// Date: 1/20/2018
/// Purpose: Form is used to add Products and Product Suppliers to existing Package
/// <param name="currentPackageID">Represents ID of Package that this form is working with</param>
/// </summary>
namespace TravelExperts
{
    public partial class frmAddPackageProduct : Form
    {
        private int currentPackageID { get;  set; } // ID of the Package for what this form was open 
        private int comboBoxIndex = 0; // Represents index of combo box in List of selected suppliers
        private int sizeOFList = 0;
        private Products pro; // Prodcut type object
        private List<Products> proList = new List<Products>(); // List of product that was selected for adding 
        private List<Suppliers> supList = new List<Suppliers>(); // List of suppliers for each product
        List<Button> newButList = new List<Button>(); // List of buttons for selected products

        TableLayoutPanel tblFooter = new TableLayoutPanel() // Creating new Panel that will contain footer buttons
        {
            Dock = DockStyle.Bottom, // Docking to bottom of parent container
            ColumnCount = 2, // There will be 2 colons for 2 buttons
            Height = 50, // Height is set for 50px
            CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset, // Creating border for each cell of panel for better visual appereance
        };        
        
        Button btnCancel = new Button // Creating button Cancel for footer panel
        {
            Dock = DockStyle.Fill, // Dock Fill so it takes all available space
            Text = "Cancel",  // Setting text to Cancel
            DialogResult = DialogResult.Cancel, // Setting Result to Cancel, this value receives Parent From that created this Dialog
        };

        // Constructor get ID of package we adding products
        public frmAddPackageProduct(int i)
        {
            InitializeComponent();
            tblFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F)); // Creating add adding new style for footer panel 
            tblFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F)); // Each colomn will take 50% of available space 
            Button btnNext = new Button // Creating button for moving to next panel once pressed
            {
                Dock = DockStyle.Fill,
                Text = "Next",
            };
            btnNext.Click += (sender, e) => // Adding event listener for button next
            {
                if (newButList.Count == 0) // If list of selected buttons is empty 
                {
                    MessageBox.Show("Please select at least 1 product"); // Display message to user so he selects at least 1 product
                }
                else // Else means there are products in the list 
                {
                    ChangePanel(); // Going to method change panel to display new panel with posobility to select suppliers for each selected product
                }
            };
            tblFooter.Controls.Add(btnNext, 0, 1);
            tblFooter.Controls.Add(btnCancel, 1, 1);
            this.Controls.Add(tblFooter);
            
            this.currentPackageID = i; // Applying passes Id to local variable
            List<Button> butList = DisplayGui.GetProductsNotIncludedInPackage(currentPackageID); // Receiving List of buttons for product that not in current package yet. 
            foreach (Button btn in butList)  {  // For all buttons in received list perfoming action 
                flpAvailableProducts.Controls.Add(btn); // Adding all buttons to the panel of available products
                btn.Click += (sender, e) =>   //  Applying event listener for all buttons in received list
                {                   
                    Button b = (Button)sender; // Casting event sender to type Button add creating new object of this type
                    if (b.Parent.Name.Equals(flpAvailableProducts.Name)) // If button located in panel available products
                    {
                        flpSelectedProducts.Controls.Add(b); // adding it to panel Selected 
                        flpAvailableProducts.Controls.Remove(b);  // add removing from panel Available
                        newButList.Add(b); // adding to the list of all selected buttons to pass it futher
                    }
                    else // if button wasn't in panel available we asume that it's in selected already, so on Click event we move it back in Available
                    {
                        flpAvailableProducts.Controls.Add(b); // Adding to the panel Available
                        flpSelectedProducts.Controls.Remove(b); // Removing from panel Selected
                        newButList.Remove(b); // Removing from list of selected buttons
                    }                    
                };
            }
        }

        private void ChangePanel() // Displays new panel inside current form, panel contains selected product
        { // and provide posobility to select supplier for each product 
            sizeOFList = newButList.Count; // Represents count of of selected products
            int[] suppIDs = new int[sizeOFList]; // creates Array to be filed with sup values for each product            
            tblMain.Hide(); // Hides previous page 
            tblFooter.Controls.Clear(); // clear controls from footer panel
            tblFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F)); // creates 2 new styles for panel
            tblFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F)); // to put new buttons in it
            Button btnFinishAdding = new Button // creates new button
            {
                Dock = DockStyle.Fill, // button fill all available space
                Text = "Finish",  // Text that will be displayed on the button
                DialogResult = DialogResult.OK, // Set value of this button that will be returned to Form from which this form was called
            };
            tblFooter.Controls.Add(btnFinishAdding, 0, 1); // Add button "Finish" to footer panel 
            tblFooter.Controls.Add(btnCancel, 1, 1); // Add button "Cancel" to footer panel
            this.Controls.Add(tblFooter);

            FlowLayoutPanel flpSupSelect = new FlowLayoutPanel() // creating new panel for display new information
            {
                Dock = DockStyle.Fill, // Panel takes all available space
                AutoScroll = true, // If there will be too much info to display in one panel , scroll will apear
            };
            this.Controls.Add(flpSupSelect); // Adding newly created panel to current Control(this Form)

            btnFinishAdding.Click += (sender, e) => // Adding event listener to button "Finish"
            {
                int count = 0; // Counter that will increase with each and works as index in Supplier ID array
                foreach (Products p in proList) // For every Product object in proList 
                {
                    Products_Suppliers ps = new Products_Suppliers(); // creating new Product_supplier object
                    ps.ProductId = p.ProductID; // Assigning to new PS object value of ProductID from Product object from supList
                    ps.SupplierId = suppIDs[count]; // Assigning to new PS object value of SupplierID form Array
                    count++; // Increase counter to progress in array with a next loop
                    int psID = Products_SuppliersDB.AddProductSupplier(ps); // Creating new record in Prodyuct_supplier table and returning it's ID
                    PackagesProductsSupplier pps = new PackagesProductsSupplier(); // Creating new object of PackagesProductsSupplier
                    pps.PackageID = currentPackageID; // Assigning to new PPS object value of PackageId from value received in constructor of this form
                    pps.ProductSupplierID = psID; // Assigning to new PPS object value of ProductSupplierID from return ID after creating record
                    PackagesProductsSupplierDB.AddProductsToPackage(pps); // Adding new record in PackagesProductsSupplier table that assigns product form supList to current Package
                }
            };

            foreach (Button b in newButList) // For each Product user selected we creaated display button
            { // For each of this button we will create Panel to allow user to select Supplier for each Product
                pro = (Products)b.Tag; // Buttons Tag contains object of Product it represents, here we convert Tag to actual Product object
                proList.Add(pro); // Adding this object to List of object that represents all selected products
                supList = SuppliersDB.GetProductSuppliers(pro.ProductID); // Reading all available suppliers for current Product and adding it to the list
                Panel pp = new Panel() // create new panel for each button
                {
                    AutoScroll = true, // If there will be too much info to display in one panel , scroll will apear
                    Height = 121, // Buttons height is 120 , we make panel a bit higher 
                    Width = flpSupSelect.Width - 8, // Putting width same as Parent Panel, -8 to make it small for autoscroll control
                    BorderStyle = BorderStyle.FixedSingle, // Fotr better visibility creating border around panel
                };

                Label l = new Label() // Creaitng new label to display instructions to user
                {
                    Text = "Select supplier for this product: ", // Text to be displayed
                    Dock = DockStyle.Fill,  // Takes all available space
                    TextAlign = ContentAlignment.MiddleCenter, // Text is located in the center of the label
                    Font = new Font("Modern No. 20", 14.0F), // Adding forn to match rest of Application
                };

                ComboBox cb = new ComboBox()  // To display all suppliers for given Product will create combobox 
                {
                    Anchor = AnchorStyles.Left, // Putting anchor to the left only so keep it tight to the label and in the center
                    Width = 250, // putting width to 250 so even longer names can be displayed
                    DataSource = supList, // As source of data we put List of suppliers we received from database for current product
                    DisplayMember = "SupplierName",
                    ValueMember = "SupplierID",
                    BindingContext = this.BindingContext,
                    Tag = comboBoxIndex, // Taging comboboc with unique Index, that will be used to save supplier only under one index in Array
                };
                comboBoxIndex++; // after we assign index to the combobox we increase it to make it unique
                cb.ParentChanged += (sender, e) =>
                {
                    ComboBox combo = (ComboBox)sender; // Casting sender as combobox to get combobox functionality
                    suppIDs[(int)combo.Tag] = (int)cb.SelectedValue; // Saving selected value from combobox to array under index of current Combobox tag
                };
                cb.SelectedIndexChanged += (sender, e) => // Adiing event listener to combobox so when user change select it will be recorder
                {
                    ComboBox combo = (ComboBox)sender; // Casting sender as combobox to get combobox functionality
                    suppIDs[(int)combo.Tag] = (int)cb.SelectedValue; // Saving selected value from combobox to array under index of current Combobox tag
                    //MessageBox.Show(combo.Tag.ToString()); // used for testing purpose
                };

                flpSupSelect.Controls.Add(pp); // 
                TableLayoutPanel tlp = new TableLayoutPanel()
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 3, 
                };
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F));
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F));



                tlp.Controls.Add(b, 0, 1);
                tlp.Controls.Add(l, 1, 1);
                tlp.Controls.Add(cb, 2, 1);
                pp.Controls.Add(tlp);
            }
        }
    }
}
