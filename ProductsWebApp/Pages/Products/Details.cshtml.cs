using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using APIs;

namespace ProductsWebApp
{
    public class DetailsModel : PageModel
    {
        private readonly IProductsClient _client;

        public DetailsModel(IProductsClient client)
        {
            _client = client;
        }

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
    }
}
