using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperts
{/// <summary>
/// Author: Dmitry Nagorny
/// Date: 1/11/2018
/// Purpose: Database level class, reads and writes data to and from database, table Packages
/// </summary>
    public static class PackagesDB
    {
        static SqlConnection con = TravelExpertsDB.GetConnection(); // getting connection

        // reads database and return List of products for specific Package
        public static List<Products> GetPackageProducts(int id)
        {
            Products pro; // create new object
            List<Products> proList = new List<Products>(); // list of products that will be returned
            string selectQuery = "SELECT p.ProductId, p.ProdName " +
                                 "FROM Products p " +
                                 "INNER JOIN Products_Suppliers ps " + 
                                 "ON p.ProductId = ps.ProductId " +
                                 "INNER JOIN Packages_Products_Suppliers pps " +
                                 "ON ps.ProductSupplierId = pps.ProductSupplierId " + 
                                 "WHERE pps.PackageId = @PackageId " + // @PackageId reference variable passed to query
                                 "GROUP BY p.ProductId, p.ProdName";
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
                    }; // create new products object
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

        // Read database and return List of Packages objects
        public static List<Packages> GetPackagesList()
        {
            Packages pkgs = null;
            List<Packages> pkgList = new List<Packages>();
            
            string selectQuery = "SELECT PackageId, PkgName, PkgStartDate, PkgEndDate, " +
                             "PkgDesc, PkgBasePrice, PkgAgencyCommission " +
                                 "FROM Packages";
            SqlCommand selectCommand = new SqlCommand(selectQuery, con);
            try
            {
                con.Open(); // open connection
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read()) // read if exists
                {
                    pkgs = new Packages(); // create new object
                    pkgs.PackageID = (int)reader["PackageId"];
                    pkgs.PackageName = reader["PkgName"].ToString();
                    pkgs.PackageStartDate = (DateTime)reader["PkgStartDate"];
                    pkgs.PackageEndDate = (DateTime)reader["PkgEndDate"];
                    pkgs.PackageDescription = reader["PkgDesc"].ToString();
                    pkgs.PackageBasePrice = Convert.ToDecimal(reader["PkgBasePrice"]);
                    pkgs.PackageAgencyCommission = Convert.ToDecimal(reader["PkgAgencyCommission"]);
                    pkgList.Add(pkgs);
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
            return pkgList;
        }


        // reads database and returns Package by it's id
        public static Packages GetPackage(int id)
        {
            Packages pkgs = null;
            SqlConnection con = TravelExpertsDB.GetConnection();
            string selectQuery = "SELECT PackageId, PkgName, PkgStartDate, PkgEndDate, " +
                                 "PkgDesc, PkgBasePrice, PkgAgencyCommission " +
                                 "FROM Packages " +
                                 "WHERE PackageId = @PackageId";
            SqlCommand selectCommand = new SqlCommand(selectQuery, con);
            selectCommand.Parameters.AddWithValue("@PackageId", id);
            try
            {
                con.Open(); // open connection
                SqlDataReader reader = selectCommand.ExecuteReader();
                if (reader.Read()) // read if exists
                {
                    pkgs = new Packages(); // create new customer object
                    pkgs.PackageID = (int)reader["PackageId"];
                    pkgs.PackageName = reader["PkgName"].ToString();
                    pkgs.PackageStartDate = (DateTime)reader["PkgStartDate"];
                    pkgs.PackageEndDate = (DateTime)reader["PkgEndDate"];
                    pkgs.PackageDescription = reader["PkgDesc"].ToString();
                    pkgs.PackageBasePrice = Convert.ToDecimal(reader["PkgBasePrice"]);
                    pkgs.PackageAgencyCommission = Convert.ToDecimal(reader["PkgAgencyCommission"]);
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
            return pkgs;
        }

        // Add new record to Packages table
        public static int AddNewPackage(Packages package)
        {
            SqlConnection con = TravelExpertsDB.GetConnection();
            string insertStatement = "INSERT INTO Packages " +
                                     " (PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission) " +
                                     "VALUES(@PkgName, @PkgStartDate, @PkgEndDate, @PkgDesc, @PkgBasePrice, @PkgAgencyCommission)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, con);
            insertCommand.Parameters.AddWithValue("@PkgName", package.PackageName);
            insertCommand.Parameters.AddWithValue("@PkgStartDate", package.PackageStartDate);
            insertCommand.Parameters.AddWithValue("@PkgEndDate", package.PackageEndDate);
            insertCommand.Parameters.AddWithValue("@PkgDesc", package.PackageDescription);
            insertCommand.Parameters.AddWithValue("@PkgBasePrice", package.PackageBasePrice);
            insertCommand.Parameters.AddWithValue("@PkgAgencyCommission", package.PackageAgencyCommission);
            try
            {
                con.Open();
                insertCommand.ExecuteNonQuery();
                string selectQuery = "SELECT IDENT_CURRENT('Packages') FROM Packages"; // get the generated ID
                SqlCommand selectCommand = new SqlCommand(selectQuery, con);
                int PkgID = Convert.ToInt32(selectCommand.ExecuteScalar()); // retrieves one value
                return PkgID;
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

        // Puts table Packages in to DataSet and reterns it
        public static DataSet GetPackageDataSet()
        {
            SqlConnection con = TravelExpertsDB.GetConnection();
            string selectQuery = "SELECT * FROM Packages";
            var dataAdapter = new SqlDataAdapter(selectQuery, con);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }

        //Updates existing Packages by Package ID
        public static bool UpdatePackage(Packages oldPackage, Packages newPackage)
        {
            SqlConnection con = TravelExpertsDB.GetConnection();
            string updateStatement = "UPDATE Packages SET " +
                                     " PkgName = @NewPkgName, " +
                                     " PkgStartDate = @NewPkgStartDate, " +
                                     " PkgEndDate = @NewPkgEndDate, " +
                                     " PkgDesc = @NewPkgDesc, " +
                                     " PkgBasePrice = @NewPkgBasePrice, " +
                                     " PkgAgencyCommission = @NewPkgAgencyCommission " +
                                     "WHERE PackageId = @OldPackageId " +
                                     " AND PkgName = @OldPkgName " + // for optimistic concurrency
                                     " AND PkgStartDate = @OldPkgStartDate " +
                                     " AND PkgEndDate = @OldPkgEndDate " +
                                     " AND PkgDesc = @OldPkgDesc " +
                                     " AND PkgBasePrice = @OldPkgBasePrice " +
                                     " AND PkgAgencyCommission = @OldPkgAgencyCommission";
            SqlCommand updateCommand = new SqlCommand(updateStatement, con);
            updateCommand.Parameters.AddWithValue("@NewPkgName", newPackage.PackageName);
            updateCommand.Parameters.AddWithValue("@NewPkgStartDate", newPackage.PackageStartDate);
            updateCommand.Parameters.AddWithValue("@NewPkgEndDate", newPackage.PackageEndDate);
            updateCommand.Parameters.AddWithValue("@NewPkgDesc", newPackage.PackageDescription);
            updateCommand.Parameters.AddWithValue("@NewPkgBasePrice", newPackage.PackageBasePrice);
            updateCommand.Parameters.AddWithValue("@NewPkgAgencyCommission", newPackage.PackageAgencyCommission);
            updateCommand.Parameters.AddWithValue("@OldPackageId", oldPackage.PackageID);
            updateCommand.Parameters.AddWithValue("@OldPkgName", oldPackage.PackageName);
            updateCommand.Parameters.AddWithValue("@OldPkgStartDate", oldPackage.PackageStartDate);
            updateCommand.Parameters.AddWithValue("@OldPkgEndDate", oldPackage.PackageEndDate);
            updateCommand.Parameters.AddWithValue("@OldPkgDesc", oldPackage.PackageDescription);
            updateCommand.Parameters.AddWithValue("@OldPkgBasePrice", oldPackage.PackageBasePrice);
            updateCommand.Parameters.AddWithValue("@OldPkgAgencyCommission", oldPackage.PackageAgencyCommission);
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

        // delete package, ensuring optimistic concurrency
        public static bool DeletePackage(int id)
        {
            SqlConnection con = TravelExpertsDB.GetConnection();
            string deleteStatement = "DELETE FROM Packages " +
                                     " WHERE PackageId = @PackageId "; // to identify record
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, con);
            deleteCommand.Parameters.AddWithValue("@PackageId", id);
            try
            {
                con.Open();
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
    }
}
