using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
/// <summary>
/// Author: Dmitry
/// </summary>
namespace TravelExperts.ClassesDB
{
    public static class SuppliersDB
    {
        static SqlConnection con = TravelExpertsDB.GetConnection();

        // reads database and return List of Suppliers for specific Product
        public static List<Suppliers> GetProductSuppliers(int id)
        {
            Suppliers sup;
            List<Suppliers> supList = new List<Suppliers>();
            string selectQuery = "SELECT s.SupplierId, s.SupName " +
                                 "FROM Suppliers s " +
                                 "INNER JOIN Products_Suppliers ps " +
                                 "ON s.SupplierId = ps.SupplierId " +
                                 "WHERE ps.ProductId = @ProductId " +
                                 "GROUP BY s.SupplierId, s.SupName";
            SqlCommand selectCommand = new SqlCommand(selectQuery, con);
            selectCommand.Parameters.AddWithValue("@ProductId", id);
            try
            {
                con.Open(); // open connection
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read()) // read the customer if exists
                {
                    sup = new Suppliers
                    {
                        SupplierID = (int)reader["SupplierId"],
                        SupplierName = reader["SupName"].ToString()
                    }; // create new products object
                    supList.Add(sup);
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
            return supList;
        }

        public static List<Suppliers> GetAllSuppliers()
        {
            Suppliers sup;
            List<Suppliers> supList = new List<Suppliers>();
            string selectQuery = "SELECT SupplierId, SupName " +
                                 "FROM Suppliers";
            SqlCommand selectCommand = new SqlCommand(selectQuery, con);
            try
            {
                con.Open(); // open connection
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read()) // read the Supplier if exists
                {
                    sup = new Suppliers
                    {
                        SupplierID = (int)reader["SupplierId"],
                        SupplierName = reader["SupName"].ToString(),
                    };
                    supList.Add(sup);
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
            return supList;
        }

        public static Suppliers GetSupplier(int ID)
        {
            Suppliers sup = new Suppliers();
            string selectQuery = "SELECT SupplierId, SupName " +
                                 "FROM Suppliers " +
                                 "WHERE SupplierId = @SupplierId";
            SqlCommand selectCommand = new SqlCommand(selectQuery, con);
            selectCommand.Parameters.AddWithValue("@SupplierId", ID);
            try
            {
                con.Open(); // open connection
                SqlDataReader reader = selectCommand.ExecuteReader();
                reader.Read();
                sup = new Suppliers
                {
                    SupplierID = (int)reader["SupplierId"],
                    SupplierName = reader["SupName"].ToString(),
                };
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close(); // close connection
            }
            return sup;
        }

        public static Suppliers GetSupplierForTheProduct(int ProductID, int PackageID)
        {
            Suppliers sup = new Suppliers();
            string  selectQuery = "SELECT s.SupplierId, s.SupName " +
                                   "FROM Suppliers s " +
                                   "INNER JOIN Products_Suppliers ps " +
                                   "ON s.SupplierId = ps.SupplierId " +
                                   "INNER JOIN Packages_Products_Suppliers pps " +
                                   "ON ps.ProductSupplierId = pps.ProductSupplierId " +
                                   "WHERE pps.PackageId = @PackageId AND ps.ProductId = @ProductId";
            SqlCommand selectCommand = new SqlCommand(selectQuery, con);
            selectCommand.Parameters.AddWithValue("PackageId", PackageID);
            selectCommand.Parameters.AddWithValue("ProductId", ProductID);
            try
            {
                con.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                reader.Read();
                sup = new Suppliers()
                {
                    SupplierID = (int)reader["SupplierId"],
                    SupplierName = reader["SupName"].ToString(),
                };                
            } 
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return sup;
        }

        private static int GetSupNewID()
        {
            SqlConnection con = TravelExpertsDB.GetConnection();
            string selectQuery = "SELECT MAX(SupplierId) From Suppliers"; // get the biggest ID
            SqlCommand selectCommand = new SqlCommand(selectQuery, con);
            try
            {
                con.Open();
                int supID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return supID + 1;
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

        // delete customer
        public static bool DeleteSupplier(Suppliers sup)
        {


            SqlConnection con = TravelExpertsDB.GetConnection();

            string deleteStatement = "DELETE FROM Suppliers " +
                                 " WHERE SuppplierId = @SupplierId " + // to identify record
                                 " AND SupName = @SupName ";
            //string deleteStatement = "DELETE FROM Products " +
            //                     " WHERE @ProductID not in ( select ProductId from Products_Suppliers )";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, con);
            deleteCommand.Parameters.AddWithValue("@SupplierID", sup.SupplierID);

            deleteCommand.Parameters.AddWithValue("@SupName", sup.SupplierName);

            try
            {
                con.Open();
                //fk.ExecuteNonQuery();
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

        public static Suppliers GetSupplier(string suppName)
        {
            Suppliers sup = null;
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectQuery = "SELECT SupplierId, SupName " +
                                 "FROM Suppliers " +
                                 "WHERE SupName = @SupName";

            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@SupName", suppName);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                if (reader.Read())
                {
                    sup = new Suppliers();
                    sup.SupplierID = (int)reader["SupplierID"];
                    sup.SupplierName = reader["SupName"].ToString();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return sup;
        }

        public static bool UpdateSupplier(Suppliers newSupplier)
        {
            SqlConnection con = TravelExpertsDB.GetConnection();
            string updateStatement = "UPDATE Suppliers SET SupName = @NewSupName  " +
                                     " WHERE SupplierId = @OldSupplierId ";
            SqlCommand updateCommand = new SqlCommand(updateStatement, con);

            updateCommand.Parameters.AddWithValue("@NewSupName", newSupplier.SupplierName);
            updateCommand.Parameters.AddWithValue("@OldSupplierId", newSupplier.SupplierID);
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
    }
}
