using CartProject.Data;
using CartProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CartProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }
        public async Task<IActionResult> Index(int p = 1)
        {
            int pageSize = 3;
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Products.Count() / pageSize);
            return View(await _context.Products.OrderByDescending(p => p.Id).Include(p=> p.Category)
                                                .Skip((p - 1) * pageSize)
                                                .Take(pageSize).ToListAsync());


        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Category, "Id", "Name");


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (Products products)
        {
            ViewBag.Categories = new SelectList(_context.Category, "Id", "Name", products.CategoryId);

            if (ModelState.IsValid)
            {
                products.Slug = products.Name.ToLower().Replace(" ", "-");

                var slug = await _context.Products.FirstOrDefaultAsync(p => p.Slug == products.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The product already exists");
                    return View(products);
                }

               
                if (products.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(_webHost.WebRootPath, "images");
                    string ImageName = Guid.NewGuid().ToString()+"_"+ products.ImageUpload.FileName;

                    string filePath = Path.Combine(uploadsDir, ImageName);
                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await products.ImageUpload.CopyToAsync(fs);
                    fs.Close();

                    products.Image = ImageName;
                }
                _context.Add(products);
                await _context.SaveChangesAsync();

                TempData["Success"] = "The product has been created!";

                return RedirectToAction("index");
            }
            return View (products); 
        }
    }
}
