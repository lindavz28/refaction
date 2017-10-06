using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductOptionService
    {
        // TODO: Needs injection
        private IRepository<ProductOption> _repo = new ProductOptionRepository();

        public List<Product> Items { get; private set; }

        public ProductOption GetProduct(Guid guid)
        {
            return _repo.GetItem(guid);
        }

        public List<ProductOption> GetProducts()
        {
            return _repo.GetAllItems();
        }

        public List<ProductOption> GetProductsByName(string name)
        {
            return _repo.GetItemsByName(name);
        }

        public bool Create(ProductOption product)
        {
            return _repo.Save(product);
        }

        public bool Update(ProductOption product)
        {
            return _repo.Update(product);
        }

        public bool Delete(Guid id)
        {
            return _repo.Delete(id);
        }
    }
}
