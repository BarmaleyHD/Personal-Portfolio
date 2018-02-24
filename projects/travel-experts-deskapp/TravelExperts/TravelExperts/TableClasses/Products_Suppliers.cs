using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Author: Dmitry
/// Date: 15 Jan, 2018
/// </summary>
 
   
namespace TravelExperts.TableClasses
{
    public class Products_Suppliers
    {
        public int ProductSupplierId { get; set; }
        public int ProductId { get; set; }
        public string ProdName { get; set; }
        public int SupplierId{ get; set; }
        public string SupName { get; set; }
    }
}
