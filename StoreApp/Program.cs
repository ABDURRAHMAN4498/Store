using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//"connctionString" bağlantısını okuma 

//initialising my DbContext inside the DI contianer
//DbContext'imi DI kapsayıcısının içinde başlatıyorum
builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlConnection"),
    b => b.MigrationsAssembly("StoreApp"));
});
//önbellek sağlıyor sunucu tarafından bilgilerin tutuyor
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "StorAppSession";
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});

builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<Cart>(c=>SessionCart.GetCart(c));

builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

//wwwroot klasöründeki static dosyaları kullanmayı sağlıyor
app.UseStaticFiles();

app.UseSession();
app.UseHttpsRedirection();
//uygulamanın yönledirme işleminin yapmasını sağlıyor
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
      );

    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
});




app.Run();
