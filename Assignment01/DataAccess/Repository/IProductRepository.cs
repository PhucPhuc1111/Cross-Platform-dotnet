using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> getProductList();
        Product getProductByID(int id);
        void addNew(Product product);
        void Update(Product product);
        void Remove(Product product);
        IEnumerable<Product> getProductByPrice(decimal price);
        IEnumerable<Product> getProductByStock(int stock);
    }
}
