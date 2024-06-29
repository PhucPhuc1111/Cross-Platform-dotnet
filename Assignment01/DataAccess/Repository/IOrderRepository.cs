using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> getOrderList();
        Order getOrderByID(int id);
        void addNew(Order order);
        void Update(Order order);
        void Remove(Order order);
        IEnumerable<Order> getOrderListOfUser(string email);
        IEnumerable<Order> getOrderListByDate(DateTime start,DateTime end);

    }
}
