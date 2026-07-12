using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FoodItem { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int RestaurantOrderId { get; set; }
    }
}