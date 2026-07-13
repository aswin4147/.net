using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FoodItem { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public int RestaurantOrderId { get; set; }
    }
}