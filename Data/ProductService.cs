using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductService
    {
        // TODO: Needs injection
        private IRepository<Product> _repo = new ProductRepository();

        public List<Product> Items { get; private set; }

        public Product GetProduct(Guid guid)
        {
            return _repo.GetItem(guid);
        }

        public List<Product> GetProducts()
        {
            return _repo.GetAllItems();
        }

        public List<Product> GetProductsByName(string name)
        {
            return _repo.GetItemsByName(name);
        }

        public bool Create(Product product)
        {
            return _repo.Save(product);
        }

        public bool Update(Product product)
        {
            return _repo.Update(product);
        }

        public bool Delete(Guid id)
        {
            return _repo.Delete(id);
        }
    }
}
