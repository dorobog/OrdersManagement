using OrdersManagement.Model;
using System;
using System.Collections.Generic;

namespace OrdersManagement.Repository.Interface
{
    public interface IOrderManagement
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderById(Guid orderId);
        void InsertOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Guid orderId);
        void SaveChanges();
    }
}
