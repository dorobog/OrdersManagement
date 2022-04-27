using OrdersManagement.Common.Enums;
using System;

namespace OrdersManagement.Model
{
    public class Order
    {
        public Guid OrderId { get; set; }

        public Guid CustomerId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStatus status { get; set; }

        public Decimal? Price { get; set; }
    }
}
