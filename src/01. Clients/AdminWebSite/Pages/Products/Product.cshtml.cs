using System.Threading.Tasks;
using Interfaces.Store;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Entities;

namespace AdminWebSite.Pages.Products
{
    public class ProductModel : PageModel
    {
        private readonly IProductService _productService;

        public ProductModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Product Product { get; set; }
        
        public async Task OnGet(int id)
        {
            Product = await _productService.GetProductById(id);
        }

        public async Task OnPostUpdate(int id)
        {
            await _productService.UpdateProduct(id, Product);
            Product = await _productService.GetProductById(id);
        }

        public async Task<RedirectToPageResult> OnPostDelete(int id)
        {
            await _productService.DeleteProductAsync(id);

            return RedirectToPage("/Index");
        }
    }
}