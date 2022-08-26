using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CartProject.Data.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public CategoriesViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync() => View(await _context.Category.ToListAsync());
    }
}
