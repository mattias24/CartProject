using Microsoft.AspNetCore.Mvc;
using CartProject.Data;
using CartProject.Models;
using CartProject.Models.ViewModels;

namespace CartProject.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartViewModel cartViewModel = new()
            {
                CartItems = cart,
                GranTotal = cart.Sum(x=> x.Quantity * x.Price)
            };
            return View(cartViewModel);
        }


        public async Task<IActionResult> Add(long id)
        {
            Products products = await _context.Products.FindAsync(id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItem(products));
            }

            else 
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);

            TempData["Success"] = "The product has been added!";

            return Redirect(Request.Headers["Referer"].ToString());
        }

    }
}
