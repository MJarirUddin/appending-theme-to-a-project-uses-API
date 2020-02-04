using System.Collections.Generic;
using System.Threading.Tasks;
using APIs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProductsWebApp
{
    public class DeleteModel : PageModel
    {
        private readonly IProductsClient _client;

        public DeleteModel(IProductsClient client)
        {
            _client = client;
        }

        [BindProperty]
        public Products Products { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Products = await _client.GetProductsAsync(id.Value);

            if (Products == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _client.DeleteProductsAsync(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
