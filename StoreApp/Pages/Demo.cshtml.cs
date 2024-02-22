using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApp.Pages
{
    class DemoModel : PageModel
    {
        public String? FullName => HttpContext?.Session?.GetString("name") ?? "";
       
        public void OnGet()
        {

        }
        public void OnPost([FromForm] string name)
        {
            //FullName = name;
            //session'da tutabildiğimiz veri tipleri (byte[], int, string)
            HttpContext.Session.SetString("name",name);
            
        }
    }
}
