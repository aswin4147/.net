using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessLogic.Models
{
    public class RestaurantOrder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TableNumber { get; set; }

        [Required]
        public string ServerName { get; set; }

        public string Status { get; set; } = "Sent to Kitchen";

        public decimal TotalPrice { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public void CalculateTotal()
        {
            TotalPrice = OrderItems.Sum(item => item.Price * item.Quantity);
        }
    }
}