using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Data;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Controllers
{
    public class FoodController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Food
        public async Task<IActionResult> Index()
        {
            var items = await _context.FoodItems.ToListAsync();
            return View(items);
        }
    }
}
