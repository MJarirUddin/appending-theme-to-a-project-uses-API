using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using APIs;


namespace ProductsWebApp
{
    public class EditModel : PageModel
    {
        private readonly IProductsClient _client;

        public EditModel(IProductsClient client)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _client.PutProductsAsync(Products.Id, Products);

            return RedirectToPage("./Index");
        }

    }
}
