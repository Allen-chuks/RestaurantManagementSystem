using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.Models
{
    public class FoodItem
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ImagePath { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Category { get; set; }

        public bool IsAvailable { get; set; } = true;  // Add this line
    }
}
