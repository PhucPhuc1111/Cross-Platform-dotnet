using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> getProductByPrice(decimal price) => ProductDAO.Instance.getProductByPrice(price);

        public IEnumerable<Product> getProductByStock(int stock) => ProductDAO.Instance.getProductByStock(stock);

        void IProductRepository.addNew(Product product) => ProductDAO.Instance.addNew(product);

        Product IProductRepository.getProductByID(int id) => ProductDAO.Instance.getProductByID(id);

        IEnumerable<Product> IProductRepository.getProductList() => ProductDAO.Instance.getProductList();

        void IProductRepository.Remove(Product product) => ProductDAO.Instance.Remove(product);

        void IProductRepository.Update(Product product) => ProductDAO.Instance.Update(product);
    }
}
