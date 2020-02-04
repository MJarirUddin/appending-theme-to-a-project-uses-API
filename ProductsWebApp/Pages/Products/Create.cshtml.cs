using System.Threading.Tasks;
using APIs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProductsWebApp
{
    public class CreateModel : PageModel
    {
        private readonly IProductsClient _client;

        public CreateModel(IProductsClient client)
        {
            _client = client;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Products Products { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _client.PostProductsAsync(Products);

            return RedirectToPage("./Index");
        }
    }
}
