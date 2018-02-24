using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Author: Dmitry
/// Purpose: Save custom message about exception to file
/// </summary>
namespace TravelExperts.ClassesDB
{
    public static class ErrorLog
    {
        static string filePath = @"Error.txt"; // path where file locate

        /// <summary>
        /// If doesn't exist create file and write passed exception to file
        /// </summary>
        /// <param name="ex">Exceprion that will be written to the file</param>
        public static void SaveException(Exception ex)
        {
            if (!File.Exists(filePath)) // if .txt file doesn't exists
            {
                File.Create(filePath).Dispose(); // create new .txt file
            }

            using (StreamWriter sw = new StreamWriter(filePath, true)) // ussing 
            {
                sw.WriteLine("=============Error Logging ==========="); // Start of the record
                sw.WriteLine("===========Start============= " + DateTime.Now); // Date and time when error happened
                sw.WriteLine("Error Message: " + ex.Message); // Message of the error
                sw.WriteLine("Stack Trace: " + ex.StackTrace); 
                sw.WriteLine("===========End============= " + DateTime.Now); // Date and time when error happened
            }
        }
    }
}
