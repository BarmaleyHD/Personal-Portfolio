using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Author: Dmitry
/// </summary>
namespace TravelExperts
{
    public class Packages
    {
        public int PackageID { get; set; }
        public string PackageName { get; set; }
        public DateTime PackageStartDate { get; set; }
        public DateTime PackageEndDate { get; set; }
        public string PackageDescription { get; set; }
        public decimal PackageBasePrice { get; set; }
        public decimal PackageAgencyCommission { get; set; }
        public string PackageDestination { get; set; }

    }
}
