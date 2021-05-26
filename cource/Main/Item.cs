using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cource.Main
{
    class Catalog
    {
        public string Manufacturer { get; set; }
        public string Category { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Price { get; set; }
    }
    class Product
    {
        public string Productt { get; set; }
        public string Buyer { get; set; }
        public string Supplier { get; set; }
        public string Amount { get; set; }
        public string OrderDate { get; set; }
        public string SupplyDate { get; set; }
    }
    class Buyer
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
    }
    class Supplier
    {
        public string Name { get; set; }
        public string TermsOfPay { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
    }
    class User
    {
        public string Login { get; set; }
        public string Role { get; set; }
        public string Access { get; set; }
    }
}
