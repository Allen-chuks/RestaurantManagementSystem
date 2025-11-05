using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var services = scope.ServiceProvider;

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var context = services.GetRequiredService<ApplicationDbContext>();

            // Ensure DB created (already done via Migrate above, but safe)
            await context.Database.EnsureCreatedAsync();

            // Seed admin user
            string adminEmail = "admin@restaurant.local";
            var admin = await userManager.FindByEmailAsync(adminEmail);
            if (admin == null)
            {
                admin = new ApplicationUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
                await userManager.CreateAsync(admin, "Admin@123"); // change password in production
            }

            // Seed sample food items if none exist
            if (!await context.FoodItems.AnyAsync())
            {
                var items = new[]
                {
                    new FoodItem { Name = "Margherita Pizza", Description = "Classic cheese & tomato.", Price = 8.50m, Category = "Main" },
                    new FoodItem { Name = "Caesar Salad", Description = "Romaine, parmesan, croutons", Price = 5.50m, Category = "Appetizer" },
                    new FoodItem { Name = "Tiramisu", Description = "Coffee-flavored Italian dessert", Price = 4.00m, Category = "Dessert" },
                };
                context.FoodItems.AddRange(items);
                await context.SaveChangesAsync();
            }
        }
    }
}
