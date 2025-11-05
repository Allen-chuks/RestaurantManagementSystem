using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Models;
using System.Linq;

public class MenuController : Controller
{
    private readonly ApplicationDbContext _context;

    public MenuController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var foodItems = _context.FoodItems.ToList();
        return View(foodItems);
    }
}
