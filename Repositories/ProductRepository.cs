using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneProduct(Product product) => Create(product);

        public void DeleteOneProduct(Product product) => Remove(product);
       
        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);

        public Product? GetOnProduct(int id, bool trackChange)
        {
            return FindByCondition(p=>p.ProductId.Equals(id),trackChange);
        }

        public void UpdateOneProduct(Product entity) => Update(entity);
        //interface
        // public Product? GetProduct(int id, bool trackChanges)
        // {
        // }

    }
}