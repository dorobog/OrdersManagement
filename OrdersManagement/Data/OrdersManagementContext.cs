using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrdersManagement.Model;
using OrderManagement.Model;

namespace OrdersManagement.Data
{
    public class OrdersManagementContext : DbContext
    {
        public OrdersManagementContext(DbContextOptions<OrdersManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Order { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Product> Product { get; set; }

    }
}
