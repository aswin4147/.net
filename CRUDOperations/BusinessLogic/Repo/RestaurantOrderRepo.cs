using BusinessLogic.IRepo;
using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Repo
{
    public class RestaurantOrderRepo : IRestaurantOrderRepo
    {
        private readonly AppDb _db;

        public RestaurantOrderRepo(AppDb db)
        {
            _db = db;
        }

        public async Task<IEnumerable<RestaurantOrder>> GetActiveOrdersAsync()
        {
            return await _db.RestaurantOrders
                            .Include(o => o.OrderItems)
                            .ToListAsync();
        }

        public async Task PlaceOrderAsync(RestaurantOrder order)
        {
            _db.RestaurantOrders.Add(order);
            await _db.SaveChangesAsync();
        }

        public async Task<RestaurantOrder> GetOrderByIdAsync(int id)
        {
            return await _db.RestaurantOrders
                            .Include(o => o.OrderItems)
                            .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}