using System;
using System.Collections.Generic;
using System.Text;

namespace AppProducts.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string Designer { get; set; }
    }
}
