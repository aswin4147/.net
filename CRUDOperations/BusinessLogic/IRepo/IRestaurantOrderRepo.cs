using BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.IRepo
{
    public interface IRestaurantOrderRepo
    {
        Task<IEnumerable<RestaurantOrder>> GetActiveOrdersAsync();
        Task PlaceOrderAsync(RestaurantOrder order);
        Task<RestaurantOrder> GetOrderByIdAsync(int id);
    }
}