using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }

            }
        }
        public IEnumerable<Order> getOrderListOfUser(string email)
        {
            List<Order> orders;
            try
            {

                using (var MySale = new Sale_ManagementContext())
                {
                    int id = MySale.Members.Where(x => x.Email == email).FirstOrDefault().MemberId;
                    orders = MySale.Orders.Where(x => x.MemberId == id).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orders;

        }
        public IEnumerable<Order> getOrderList()
        {
            List<Order> orders;
            try
            {

                using (var MySale = new Sale_ManagementContext())
                {
                    orders = MySale.Orders.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orders;

        }

        public Order getOrderByID(int orderID)
        {
            Order orders = null;
            try
            {
                using (var MySale = new Sale_ManagementContext())
                {
                    orders = MySale.Orders.SingleOrDefault(order => order.OrderId == orderID);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orders;
        }
        public void addNew(Order order)
        {
            try
            {
                Order p = getOrderByID(order.OrderId);
                if (p == null)
                {
                    using (var MySale = new Sale_ManagementContext())
                    {
                        MySale.Orders.Add(order);
                        MySale.SaveChanges();
                    }

                }
                else
                {
                    throw new Exception("The order is already exist");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        
        public void Update(Order order)
        {
            try
            {
                Order p = getOrderByID(order.OrderId);
                if (p != null)
                {
                    using (var MySale = new Sale_ManagementContext())
                    {
                        MySale.Orders.Update(order);
                        MySale.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The order does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Remove(Order order)
        {
            try
            {
                Order p = getOrderByID(order.OrderId);
                if (p != null)
                {
                    using (var MySale = new Sale_ManagementContext())
                    {
                        var orderDetailIDs = MySale.OrderDetails.Where(x => x.OrderId == p.OrderId).ToList();
                        MySale.RemoveRange(orderDetailIDs);
                        MySale.SaveChanges();
                        MySale.Remove(p);
                        MySale.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The order does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public IEnumerable<Order> getOrderListByDate(DateTime start,DateTime end)
        {
            List<Order> orders;
            try
            {

                using (var MySale = new Sale_ManagementContext())
                {
                    orders = MySale.Orders.Where(order => DateTime.Compare(start,order.OrderDate) <= 0 && DateTime.Compare(end, order.OrderDate) >= 0).ToList();
                    foreach(Order o in orders){
                        Console.WriteLine(o.OrderDate);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orders;

        }
    }
}
