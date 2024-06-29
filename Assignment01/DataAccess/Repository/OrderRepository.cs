using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void addNew(Order order) => OrderDAO.Instance.addNew(order);

        public Order getOrderByID(int id) => OrderDAO.Instance.getOrderByID(id);

        public IEnumerable<Order> getOrderList() => OrderDAO.Instance.getOrderList();

        public IEnumerable<Order> getOrderListByDate(DateTime start, DateTime end) => OrderDAO.Instance.getOrderListByDate(start, end);

        public IEnumerable<Order> getOrderListOfUser(string email) => OrderDAO.Instance.getOrderListOfUser(email);

        public void Remove(Order order) => OrderDAO.Instance.Remove(order);

        public void Update(Order order) => OrderDAO.Instance.Update(order);
    }
}
