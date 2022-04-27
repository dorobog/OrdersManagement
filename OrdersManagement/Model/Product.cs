using System;

namespace OrderManagement.Model
{
    public class Product
    {
        public Guid ProductId { get; set; } 

        public string ProductName { get; set; }

        public string Description { get; set; }

        public Decimal CostPrice { get; set; }

        public Decimal SellingPrice { get; set; }

        public int QuantityInStock { get; set; }
    }
}
