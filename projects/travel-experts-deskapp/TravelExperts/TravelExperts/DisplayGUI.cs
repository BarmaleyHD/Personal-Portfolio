using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TravelExperts.ClassesDB;
/// <summary>
/// Author: Dmitry
/// Class used to create customs constrols and display inforamtion in gridviews and panels
/// </summary>
namespace TravelExperts
{
    public static class DisplayGui
    {
        static List<Products> products = null;
        static List<Button> buttons = null;

        // Populate referenced DataGridView from DataTable
        public static void FillGridView(DataGridView dt, DataSet data)
        {
            dt.ReadOnly = false;
            dt.DataSource = data.Tables[0];
        }
        public static List<Button> DisplayPackageProducts(int id, FlowLayoutPanel flp)
        {
            flp.Controls.Clear();
            products = PackagesDB.GetPackageProducts(id);
            buttons = new List<Button>();
            foreach (Products p in products)
            {
                Button dp = CreateResponsiveButton(p);
                flp.Controls.Add(dp);
                buttons.Add(dp);
            }
            return buttons;
        }

        //Creates and return List Button for Products that are not included in specified Package
        public static List<Button> GetProducts(int id, FlowLayoutPanel flp)
        {
            flp.Controls.Clear();
            products = PackagesDB.GetPackageProducts(id);
            buttons = new List<Button>();
            foreach (Products p in products)
            {
                Button dp = CreateResponsiveButton(p);
                flp.Controls.Add(dp);
                buttons.Add(dp);
            }
            return buttons;
        }

        // Displays all Products from database
        public static List<Button> DisplayAllProducts(FlowLayoutPanel flp)
        {
            flp.Controls.Clear();
            products = ProductsDB.GetProductsList();
            buttons = new List<Button>();
            foreach (Products p in products)
            {
                Button dp = CreateResponsiveButton(p);
                flp.Controls.Add(dp);
                buttons.Add(dp);
            }
            return buttons;
        }

        public static List<Button> GetProductsNotIncludedInPackage(int id)
        {
            products = ProductsDB.GetProductsExeptPackageProducts(id);
            buttons = new List<Button>();
            foreach (Products p in products)
            {
                Button dp = CreateResponsiveButton(p);
                buttons.Add(dp);
            }
            return buttons;
        }

        // Creates custom button for displaying products
        public static Button CreateResponsiveButton(Products p)
        {
            Image logo;
            if(ProductsImagesDB.GetImage(p.ProductID) == null)
            {
                logo = Image.FromFile(@"../../Images/default_logo.png");
            }
            else
            {
                MemoryStream ms = new MemoryStream(ProductsImagesDB.GetImage(p.ProductID));
                logo = Image.FromStream(ms);
            };
            
            Label lbl = new Label
            {
                Text = p.ProductName,
                Dock = DockStyle.Bottom,
                TextAlign = ContentAlignment.MiddleCenter,                
                Enabled = false,
                FlatStyle = FlatStyle.Flat,
                BorderStyle = BorderStyle.FixedSingle,
            };
            Button btn = new Button
            {
                BackgroundImage = logo,
                BackgroundImageLayout = ImageLayout.Zoom,
                FlatStyle = FlatStyle.Flat,
                Height = 120,
                Width = 120,
                Tag = p,
            };
            btn.Controls.Add(lbl);    
            return btn;
        }

        public static Button CreateResponsiveTextButton(Suppliers s)
        {
            Button btn = new Button
            {               
                FlatStyle = FlatStyle.Flat,                
                Height = 30,
                Tag = s,
                Text = s.SupplierName,
            };
            btn.FlatAppearance.BorderColor = Color.Black;
            btn.FlatAppearance.BorderSize = 1;
            return btn;
        }
    }
}
