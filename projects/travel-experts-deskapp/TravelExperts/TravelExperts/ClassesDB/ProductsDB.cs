using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Author: Nour
/// Author: Maru
/// </summary>
namespace TravelExperts
{
    public static class ProductsDB
    {
        static SqlConnection con = TravelExpertsDB.GetConnection();

        // Retutns DataSet with all Products from database
        public static DataSet GetProductsDataSet()
        {            
            string selectQuery = "SELECT * FROM Products";
            var dataAdapter = new SqlDataAdapter(selectQuery, con);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }

        // Read database and return List of Products objects
        public static List<Products> GetProductsList()
        {
            Products pro = null;
            List<Products> proList = new List<Products>();

            string selectQuery = "SELECT ProductId, ProdName " +
                                 "FROM Products";
            SqlCommand selectCommand = new SqlCommand(selectQuery, con);
            try
            {
                con.Open(); // open connection
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read()) // read the products if exists
                {
                    pro = new Products(); // create new product object
                    pro.ProductID = (int)reader["ProductId"];
                    pro.ProductName = reader["ProdName"].ToString();
                    proList.Add(pro);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close(); // close connection
            }
            return proList;
        }

        public static List<Products> GetProductsExeptPackageProducts(int id)
        {
            Products pro;
            List<Products> proList = new List<Products>();
            string selectQuery = "SELECT * FROM Products p WHERE p.ProductId NOT IN (" +
                                 "SELECT p.ProductId " +
                                 "FROM Products p " +
                                 "INNER JOIN Products_Suppliers ps " +
                                 "ON p.ProductId = ps.ProductId " +
                                 "INNER JOIN Packages_Products_Suppliers pps " +
                                 "ON ps.ProductSupplierId = pps.ProductSupplierId " +
                                 "WHERE pps.PackageId = @PackageId " +
                                 "GROUP BY p.ProductId, p.ProdName)";
            SqlCommand selectCommand = new SqlCommand(selectQuery, con);
            selectCommand.Parameters.AddWithValue("@PackageId", id);
            try
            {
                con.Open(); // open connection
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read()) // read if exists
                {
                    pro = new Products
                    {
                        ProductID = (int)reader["ProductId"],
                        ProductName = reader["ProdName"].ToString()
                    }; // create new object
                    proList.Add(pro);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close(); // close connection
            }
            return proList;
        }

        // adding new Product to database
        public static int AddProduct(string  name)
        {
            int prodID = 0;
            SqlConnection con = TravelExpertsDB.GetConnection();
            string insertStatement = "INSERT INTO Products (ProdName) " +
                                     "OUTPUT INSERTED.ProductId " +
                                     "VALUES (@ProdName) ";
            SqlCommand insertCommand = new SqlCommand(insertStatement, con);
            insertCommand.Parameters.AddWithValue("@ProdName", name);
            try
            {

                con.Open();
                prodID = (int)insertCommand.ExecuteScalar();
                //string type = selectCommand.ExecuteScalar().GetType().ToString();
                return prodID;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        // delete Product, ensuring optimistic concurrency
        public static bool DeleteProduct(Products prod)
        {
            SqlConnection con = TravelExpertsDB.GetConnection();
            string deleteImageStatement = "DELETE FROM Products_Images " +
                                          " WHERE ProductID = @ProductID";
            string deleteStatement = "DELETE FROM Products " +
                                     " WHERE ProductId = @ProductID " + // to identify record
                                     " AND ProdName = @ProdName ";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, con);
            deleteCommand.Parameters.AddWithValue("@ProductID", prod.ProductID);
            deleteCommand.Parameters.AddWithValue("@ProdName", prod.ProductName);
            SqlCommand deleteImageCommand = new SqlCommand(deleteImageStatement, con);
            deleteImageCommand.Parameters.AddWithValue("@ProductID", prod.ProductID);
            try
            {
                con.Open();
                int imgCount = deleteImageCommand.ExecuteNonQuery();
                int count = deleteCommand.ExecuteNonQuery(); // returns number of rows deleted
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool UpdateProduct(Products oldProduct, Products newProduct)
        {
            SqlConnection con = TravelExpertsDB.GetConnection();
            string updateStatement = "UPDATE Products SET ProdName = @NewProdName  " +
                                     " WHERE ProductID = @OldProductID ";
            SqlCommand updateCommand = new SqlCommand(updateStatement, con);

            updateCommand.Parameters.AddWithValue("@NewProdName", newProduct.ProductName);
            updateCommand.Parameters.AddWithValue("@OldProductID", oldProduct.ProductID);
            //updateCommand.Parameters.AddWithValue("@OldProdName", oldProduct.ProductName);
            try
            {
                con.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public static int CheckInUse(int ProductID)
        {
            int packages;
            string selectQuery = "SELECT COUNT(PackageId) " +
                                 "FROM Packages_Products_Suppliers pps " +
                                 "INNER JOIN Products_Suppliers ps " +
                                 "ON ps.ProductSupplierId = pps.ProductSupplierId " +
                                 "WHERE ps.ProductId = @ProductID";
            SqlCommand selectCommand = new SqlCommand(selectQuery, con);
            selectCommand.Parameters.AddWithValue("@ProductID", ProductID);
            try
            {
                con.Open(); // open connection
                packages = selectCommand.ExecuteNonQuery();
                return packages;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close(); // close connection
            }
        }
    }
}
