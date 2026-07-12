using BusinessLogic.IRepo;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CRUDOperations.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantOrderRepo _repo;

        public RestaurantController(IRestaurantOrderRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> KitchenDisplay()
        {
            var data = await _repo.GetActiveOrdersAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult TakeOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TakeOrder(RestaurantOrder order)
        {
            if (order.OrderItems != null)
            {
                foreach (var item in order.OrderItems)
                {
                    switch (item.FoodItem)
                    {
                        case "Cheeseburger":
                            item.Price = 10.00m;
                            break;
                        case "Pepperoni Pizza":
                            item.Price = 15.00m;
                            break;
                        case "Caesar Salad":
                            item.Price = 8.00m;
                            break;
                        default:
                            item.Price = 0.00m;
                            break;
                    }
                }
                order.CalculateTotal();
            }

            await _repo.PlaceOrderAsync(order);
            return RedirectToAction("KitchenDisplay");
        }

        [HttpGet]
        public async Task<IActionResult> SearchOrder(int? searchId)
        {
            if (searchId == null) return View();

            var order = await _repo.GetOrderByIdAsync(searchId.Value);
            return View(order);
        }
    }
}