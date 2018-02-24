using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TravelExperts.TableClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Author: Dmitry
/// Date: 20 Jan, 2018
/// </summary>
namespace TravelExperts
{
    public static class PackagesProductsSupplierDB
    {
        static SqlConnection con = TravelExpertsDB.GetConnection();

        // Gets all data from this table
        public static DataSet GetPackageProductSupplierDataSet()
        {            
            string selectQuery = "SELECT * FROM Packages_Products_Suppliers";
            var dataAdapter = new SqlDataAdapter(selectQuery, con);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }

        // Get Supplier name by ProductID
        public static List<Suppliers> GetProductSuppliersList(int id)
        {
            List<Suppliers> supList = new List<Suppliers>();
            Suppliers sup;
            string selectQuery = "SELECT s.SupplierId, s.SupName " +
                                 "FROM Suppliers s  " +
                                 "INNER JOIN Products_Suppliers ps " +
                                 "ON s.SupplierId = ps.SupplierId " +
                                 "WHERE ps.ProductId = @ProductId " +
                                 "GROUP BY s.SupplierId, s.SupName ";
            SqlCommand selectCommand = new SqlCommand(selectQuery, con);
            selectCommand.Parameters.AddWithValue("@ProductId", id);
            try
            {
                con.Open(); // open connection
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    sup = new Suppliers
                    {
                        SupplierID = (int)reader["SupplierId"],
                        SupplierName = reader["SupName"].ToString()
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

        public static void AddProductsToPackage(PackagesProductsSupplier pps)
        {
            string insertStatement = "INSERT INTO Packages_Products_Suppliers " +
                                     " (PackageId, ProductSupplierId) " +
                                     "VALUES(@PackageId, @ProductSupplierId)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, con);
            insertCommand.Parameters.AddWithValue("@PackageId", pps.PackageID);
            insertCommand.Parameters.AddWithValue("@ProductSupplierId", pps.ProductSupplierID);
            try
            {
                con.Open();
                insertCommand.ExecuteNonQuery();
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

        public static void DeletePPS(int PackageID, int ProductID)
        {
            string deleteStatement = "DELETE FROM Packages_Products_Suppliers " +
                                     "WHERE PackageId = @PackageId " +
                                     "AND ProductSupplierId IN (SELECT pps.ProductSupplierId FROM Packages_Products_Suppliers pps " +
                                     "INNER JOIN Products_Suppliers ps ON pps.ProductSupplierId = ps.ProductSupplierId " +
                                     "WHERE pps.PackageId = @PackageId AND ps.ProductId = @ProductId)";

            SqlCommand deleteCommand = new SqlCommand(deleteStatement, con);
            deleteCommand.Parameters.AddWithValue("@PackageId", PackageID);
            deleteCommand.Parameters.AddWithValue("@ProductId", ProductID);
            try
            {
                con.Open();
                deleteCommand.ExecuteNonQuery();
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
