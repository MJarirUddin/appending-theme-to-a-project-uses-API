using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using APIs;
using System.Linq;

namespace ProductsWebApp
{
    public class IndexModel : PageModel
    {
        private readonly IProductsClient _client;

        public IndexModel(IProductsClient client)
        {
            _client = client;
        }

        public IList<Products> Products { get;set; }

        public async Task OnGetAsync()
        {
            Products = (await _client.GetProductItemsAsync()).ToList();
        }
    }
}
