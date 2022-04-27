using Microsoft.EntityFrameworkCore;
using OrdersManagement.Data;
using OrdersManagement.Model;
using OrdersManagement.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrdersManagement.Repository.Implementation
{
    public class OrderRepository : IOrderManagement
    {
        private OrdersManagementContext _dataContext;

        public OrderRepository(OrdersManagementContext dataContext)
        {
            this._dataContext = dataContext;
        }
       
        public void DeleteOrder(Guid OrderId)
        {
            Order product_ = _dataContext.Order.Find(OrderId);
            _dataContext.Order.Remove(product_);
        }

        public Order GetOrderById(Guid OrderId)
        {
            return _dataContext.Order.Find(OrderId);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _dataContext.Order.ToList();
        }

        public void InsertOrder(Order order)
        {
            _dataContext.Order.Add(order);
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _dataContext.Entry(order).State = EntityState.Modified;
        }
    }
}
