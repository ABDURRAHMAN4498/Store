using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
            
        }

        /*
        ///////////////////////////////////////////////
        //Çok önemli bir bölüm

        private readonly RepositoryContext _context;

        public ProductController(RepositoryContext context)
        {
            _context = context;
        }
        /////////////////////////////////////////////////
        */

        public IActionResult Index()
        {
            // var context = new RepositoryContext(
            //     new DbContextOptionsBuilder<RepositoryContext>()
            //     .UseSqlite("Data Source = C:\\Users\\asus\\Desktop\\vscodefile\\Asp.net\\ASP.NET-(ZAFER CÖMERT)\\Store\\StoreApp\\Data\\ProductDb.db").Options
            // );

            var model = _manager.ProductService.GetAllProducts(false);
            return View(model);
        }

        public IActionResult Get([FromRoute(Name ="id")]int id)
        {
            // Product product = _context.Products.First(p => p.ProductId.Equals(id));
            // return View(product);

            var model = _manager.ProductService.GetOneProduct(id,false);
            return View(model);
        }
    }
}