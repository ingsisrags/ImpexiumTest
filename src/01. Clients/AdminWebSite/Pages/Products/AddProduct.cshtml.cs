using System.Threading.Tasks;
using Interfaces.Store;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Entities;

namespace AdminWebSite.Pages.Products
{
    public class AddProductModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }
        
        public async Task<RedirectToPageResult> OnPost([FromServices] IProductService productService)
        {
            await productService.AddNewProduct(Product);
            
            return RedirectToPage("/Index");
        }
    }
}