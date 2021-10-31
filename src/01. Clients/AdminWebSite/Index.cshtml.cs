using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Store;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Entities;

namespace AdminWebSite
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        public IEnumerable<Product> Products { get; set; }

        public async Task OnGet([FromServices] IProductService productService)
        {
            Products = await productService.GetAllProduct();
        }
    }
}
