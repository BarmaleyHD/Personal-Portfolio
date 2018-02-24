using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TravelExperts.TableClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * Author Marimel Llamoso
 * content: methods to get and save to the data base
 * 
 * 
 * */
namespace TravelExperts.ClassesDB
{
    public static class Products_SuppliersDB
    {
        //this method get the product supplier list using product suplier id
        public static Products_Suppliers GetProducsuppliersObject(int prodsID)
        {
            Products_Suppliers prods = null;// initialize so else will be null
            SqlConnection con = TravelExpertsDB.GetConnection();
            string selectQuery = "SELECT ProductSupplierId, ProductId, SupplierId " +
                "FROM Products_Suppliers " + "WHERE ProductSupplierId = @ProductSupplierId";
            SqlCommand selectCommand = new SqlCommand(selectQuery, con);
            selectCommand.Parameters.AddWithValue("@ProductSupplierId", prodsID);
            try
            {
                con.Open();
                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (reader.Read())//read the customer if exist
                {
                    prods = new Products_Suppliers();
                    prods.ProductSupplierId = (int)reader["ProductSupplierId"];
                    prods.ProductId = (int)reader["ProductId"];
                    prods.SupplierId = (int)reader["SupplierId"];

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return prods;
        }
        //get the list of product supplier
        public static List<Products_Suppliers> GetProductSuppliers()
        {
            List<Products_Suppliers> productsupplier = new List<Products_Suppliers>();
            Products_Suppliers ps;
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectQuery = "select ps.ProductSupplierId, ps.ProductId, p.ProdName, ps.SupplierId, s.supname "+
                                 "from Suppliers s join Products_Suppliers ps on s.SupplierId = ps.SupplierId "+
                                 "join Products p on ps.ProductId = p.ProductId Order By ps.ProductSupplierId";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            try
            {
                connection.Open();
                SqlDataReader dr = selectCommand.ExecuteReader();
                while (dr.Read())
                {
                    ps = new Products_Suppliers();
                    ps.ProductSupplierId = (int)dr["ProductSupplierId"];
                    ps.ProductId = (int)dr["ProductId"];
                    ps.ProdName = dr["ProdName"].ToString();
                    ps.SupplierId = (int)dr["SupplierId"];
                    ps.SupName = dr["SupName"].ToString();
                    productsupplier.Add(ps);
                }
            }
            //connecction exception etc
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return productsupplier;
        }
        //get the product and supplier bu product id
        public static List<Products_Suppliers>GetProdsupplierIDandSuppliersbyProdID(int prodID)
        {
            List<Products_Suppliers> prodsup = new List<Products_Suppliers>();
            Products_Suppliers prods;
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string queryString = "select ps.ProductSupplierId, ps.ProductId, p.ProdName, ps.SupplierId, s.supname " +
                                 "from Suppliers s join Products_Suppliers ps on s.SupplierId = ps.SupplierId " +
                                 "join Products p on ps.ProductId = p.ProductId "+
                                 "where ps.ProductId = @ProductID order by ProductSupplierId";


            SqlCommand selectCommand = new SqlCommand(queryString, connection);
            selectCommand.Parameters.AddWithValue("@ProductID", prodID);
            try
            {
                connection.Open();
                SqlDataReader dr = selectCommand.ExecuteReader();
                while (dr.Read())
                {
                    prods = new Products_Suppliers();
                    prods.ProductSupplierId = (int)dr["ProductSupplierId"];
                    prods.ProductId = (int)dr["ProductId"];
                    prods.ProdName = dr["ProdName"].ToString();
                    prods.SupplierId = (int)dr["SupplierId"];
                    prods.SupName = dr["SupName"].ToString();
                    prodsup.Add(prods);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return prodsup;
        }
        //get the list of product supplier by supplier id
        public static List<Products_Suppliers> GetProdsupplierIDandSuppliersbySupID(int supID)
        {
            List<Products_Suppliers> prodsup = new List<Products_Suppliers>();
            Products_Suppliers prods;
            SqlConnection connection = TravelExpertsDB.GetConnection();
            //string queryString = "SELECT ProductSupplierId,ProductId, SupplierID " +
            //                     "FROM Products_Suppliers "+
            //                     "where productID=@ProductID";
            string queryString = "SELECT ps.ProductSupplierId, ps.ProductId, p.ProdName, ps.SupplierId " +
                                 "from Products_Suppliers ps join Products p on ps.ProductId = p.ProductId " +
                                 "where ps.SupplierId = @SupplierId ";

            SqlCommand selectCommand = new SqlCommand(queryString, connection);
            selectCommand.Parameters.AddWithValue("@SupplierId", supID);
            try
            {
                connection.Open();
                SqlDataReader dr = selectCommand.ExecuteReader();
                while (dr.Read())
                {
                    prods = new Products_Suppliers();
                    prods.ProductSupplierId = (int)dr["ProductSupplierId"];
                    prods.ProductId = (int)dr["ProductId"];
                    prods.ProdName = dr["ProdName"].ToString();
                    prods.SupplierId = (int)dr["SupplierId"];
                    prodsup.Add(prods);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return prodsup;
        }
        //get the list of product supplier by productsupplier id 
        public static List<Products_Suppliers> GetProductSuppliersbyProdSupID(int prodsupID)
        {
            List<Products_Suppliers> prodsuppliers = new List<Products_Suppliers>();
            Products_Suppliers prodsup;
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string queryString = "select ps.ProductSupplierId, ps.ProductId, p.ProdName, ps.SupplierId, s.supname "+
                                 "from Suppliers s join Products_Suppliers ps on s.SupplierId = ps.SupplierId "+
                                 "join Products p on ps.ProductId = p.ProductId " +
                                 "where ps.ProductSupplierId=@ProductSupplierId";


            SqlCommand selectCommand = new SqlCommand(queryString, connection);
            selectCommand.Parameters.AddWithValue("@ProductSupplierId", prodsupID);
            try
            {
                connection.Open();
                SqlDataReader dr = selectCommand.ExecuteReader();
                while (dr.Read())
                {
                    prodsup = new Products_Suppliers();
                    prodsup.ProductSupplierId = (int)dr["ProductSupplierId"];
                    prodsup.ProductId = (int)dr["ProductId"];
                    prodsup.ProdName = dr["ProdName"].ToString();
                    prodsup.SupplierId = (int)dr["SupplierId"];
                    prodsup.SupName = dr["SupName"].ToString();
                    prodsuppliers.Add(prodsup);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return prodsuppliers;
        }

        //add a product supplier to the data base
        public static int AddProductSupplier(Products_Suppliers prosup)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string insertStatement = "Insert Into Products_Suppliers "+
                                 "(ProductId, SupplierId) "+
                                 "VALUES(@ProductId, @SupplierId)";


            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@ProductID", prosup.ProductId);
            insertCommand.Parameters.AddWithValue("@SupplierId", prosup.SupplierId);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();// for DML statemenets
                string selectQuery = "Select IDENT_Current('Products_Suppliers') From Products_Suppliers";// get the generated ID
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                int prodsupID = Convert.ToInt32(selectCommand.ExecuteScalar());//retrieves one value
                //int does not work
                return prodsupID;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        //remove a product supplier
        public static bool RemoveProductSupplier(Products_Suppliers prod)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string deleteStatement = "Delete from Products_Suppliers " +
                                 "where ProductSupplierId = @ProductSupplierId " +
                                 "and ProductId = @ProductID " +
                                 "and SupplierId = @SupplierId ";


            SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@ProductSupplierId", prod.ProductSupplierId);
            deleteCommand.Parameters.AddWithValue("@ProductID", prod.ProductId);
            deleteCommand.Parameters.AddWithValue("@SupplierId", prod.SupplierId);
            try
            {
                connection.Open();
                int count = deleteCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;

            }
            catch (SqlException ex)
            {
                return false;
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        //update a product supplier
        public static bool UpdateProductSupplier(Products_Suppliers oldProductSupplier, Products_Suppliers newProductSupplier)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string deleteStatement = "Update Products_Suppliers Set " +
                                 "ProductId = @newProductID, " +
                                 "SupplierId = @newSupplierId " +
                                 "Where ProductSupplierId=@oldProductSupplierId " +
                                 "And ProductId = @oldProductID " +
                                 "And SupplierId = @oldSupplierId ";


            SqlCommand updateCommand = new SqlCommand(deleteStatement, connection);
            updateCommand.Parameters.AddWithValue("@newProductID", newProductSupplier.ProductId);
            updateCommand.Parameters.AddWithValue("@newSupplierId", newProductSupplier.SupplierId);
            updateCommand.Parameters.AddWithValue("@oldProductSupplierId", oldProductSupplier.ProductSupplierId);
            updateCommand.Parameters.AddWithValue("@oldProductID", oldProductSupplier.ProductId);
            updateCommand.Parameters.AddWithValue("@oldSupplierId", oldProductSupplier.SupplierId);
            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;

            }
            catch (SqlException ex)
            {
                return false;
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
