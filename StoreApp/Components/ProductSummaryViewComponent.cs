using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public ProductSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }





        //repositorylerdn serviceleri kullanmak daha avantajlı 

        /*
        // private readonly RepositoryContext _context;

        // public ProductSummary(RepositoryContext context)
        // {
        //     _context = context;
        // }
        */
        
        
        
        
        public string Invoke()
        {
            //Service
            return _manager.ProductService.GetAllProducts(false).Count().ToString();
            //Repository kullanmında yazılmıştır
            //_context.Products.Count().ToString();
        }
    }
}