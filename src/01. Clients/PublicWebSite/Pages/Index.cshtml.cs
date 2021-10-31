using Interfaces.Store;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PublicWebSite.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Product> Products { get; set; }
        
        public async Task OnGet([FromServices] IProductService productService)
        {
            Products =  await productService.GetAllProduct();
        }
    }
}
