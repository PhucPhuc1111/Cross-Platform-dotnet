using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }

            }
        }
        public IEnumerable<Product> getProductList()
        {
            List<Product> products;
            try
            {

                using (var MySale = new Sale_ManagementContext())
                {
                    products = MySale.Products.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return products;

        }

        public Product getProductByID(int productID)
        {
            Product product = null;
            try
            {
                using (var MySale = new Sale_ManagementContext())
                {
                    product = MySale.Products.SingleOrDefault(product => product.ProductId == productID);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return product;
        }
        public void addNew(Product product)
        {
            try
            {
                Product p = getProductByID(product.ProductId);
                if (p == null)
                {
                    using (var MySale = new Sale_ManagementContext())
                    {
                        MySale.Products.Add(product);
                        MySale.SaveChanges();
                    }

                }
                else
                {
                    throw new Exception("The product is already exist");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Update(Product product)
        {
            try
            {
                Product p = getProductByID(product.ProductId);
                if (p != null)
                {
                    using (var MySale = new Sale_ManagementContext())
                    {
                        MySale.Entry<Product>(product).State = EntityState.Modified;
                        MySale.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The product does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Remove(Product product)
        {
            try
            {
                Product p = getProductByID(product.ProductId);
                if (p != null)
                {
                    using (var MySale = new Sale_ManagementContext())
                    {
                        var orderDetailIDs = MySale.OrderDetails.Where(x => x.ProductId == p.ProductId).ToList();
                        MySale.RemoveRange(orderDetailIDs);
                        MySale.SaveChanges();
                        MySale.Products.Remove(product);
                        MySale.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The product does not exist");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public IEnumerable<Product> getProductByPrice(decimal price)
        {
            List<Product> products;
            try
            {

                using (var MySale = new Sale_ManagementContext())
                {
                    products = MySale.Products.Where(product => product.UnitPrice == price).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return products;

        }
        public IEnumerable<Product> getProductByStock(int stock)
        {
            List<Product> products;
            try
            {

                using (var MySale = new Sale_ManagementContext())
                {
                    products = MySale.Products.Where(product => product.UnitsInStock == stock).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return products;

        }

    }
}
