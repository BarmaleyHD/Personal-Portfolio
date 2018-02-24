using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Author: Dmitry
/// Purpose: Works with databse to save and read picture byte array, that represents pickute for Products 
/// </summary>
namespace TravelExperts.ClassesDB
{
    public static class ProductsImagesDB
    {
        // Ads new picture byte array to database, linked to the product by ProductID
        public static bool AddNewProductImage(byte[] b, int ID)
        {
            SqlConnection con = TravelExpertsDB.GetConnection();
            // Checks if picture for current Prodcut exists
            // If picture exists update it else create new one
            string insertStatement = @"IF EXISTS (SELECT * FROM Products_Images WHERE ProductID=@ProductID) 
                                       UPDATE Products_Images 
                                       SET ImageArray = @Array
                                       WHERE ProductID=@ProductID 
                                   ELSE
                                       INSERT INTO Products_Images (ProductID, ImageArray) 
                                       VALUES(@ProductID, @Array)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, con);
            insertCommand.Parameters.AddWithValue("@ProductID", ID);
            insertCommand.Parameters.AddWithValue("@Array", b);
            try
            {
                con.Open();
                // reads number of rows effected to identify if query was succesful
                int count = insertCommand.ExecuteNonQuery();
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

        // Reads database but passed id and returns image byte array
        public static byte[] GetImage(int id)
        {
            byte[] array = null;
            SqlConnection con = TravelExpertsDB.GetConnection();
            string selectQuery = "SELECT ImageArray " +
                                 "FROM Products_Images " +
                                 "WHERE ProductID = @ProductID";
            SqlCommand selectCommand = new SqlCommand(selectQuery, con);
            selectCommand.Parameters.AddWithValue("@ProductID", id);
            try
            {
                con.Open(); // open connection
                SqlDataReader reader = selectCommand.ExecuteReader();
                if (reader.Read()) // read if exists
                {
                    array = (byte [])reader["ImageArray"];
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
            return array;
        }
    }
}
