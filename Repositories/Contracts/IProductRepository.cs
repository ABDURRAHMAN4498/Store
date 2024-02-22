using Entities.Models;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRrepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackChanges); 

        Product? GetOnProduct(int id,bool trackChange);
        void CreateOneProduct(Product product);
        void DeleteOneProduct(Product product);
        void UpdateOneProduct(Product entity);
    }
}