using CafeteriaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaApp.Services
{
    public class OrderManager
    {
        private Dictionary<int, MenuItem> menu = new Dictionary<int, MenuItem>();
        private List<Order> orders = new List<Order>();
        private int nextOrderId = 1;

        public OrderManager()
        {
            // Seed Menu Items
            menu.Add(1, new MenuItem(1, "Coffee", 2.5));
            menu.Add(2, new MenuItem(2, "Sandwich", 4.0));
            menu.Add(3, new MenuItem(3, "Pasta", 6.0));
            menu.Add(4, new MenuItem(4, "Juice", 3.0));
            menu.Add(5, new MenuItem(5, "Salad", 3.5));
        }

        public List<MenuItem> ShowMenu()
        {
            return menu.Values.ToList();
        }

        public bool PlaceOrder(string name, List<int> itemIds)
        {
            if (itemIds == null || itemIds.Count == 0)
            {
                return false;
            }

            Order newOrder = new Order(nextOrderId, name);

            foreach (int id in itemIds)
            {
                if (menu.ContainsKey(id))
                {
                    newOrder.Items.Add(menu[id]);
                }
            }

            if (newOrder.Items.Count > 0)
            {
                newOrder.CalculateTotal();
                orders.Add(newOrder);
                nextOrderId++;
                return true;
            }

            return false;
        }

        public Order SearchOrder(int id)
        {
            return orders.FirstOrDefault(o => o.OrderId == id);
        }

        public bool CancelOrder(int id)
        {
            Order orderToCancel = SearchOrder(id);

            if (orderToCancel != null)
            {
                orders.Remove(orderToCancel);
                return true;
            }

            return false;
        }

        public List<Order> GetOrders()
        {
            return orders;
        }
    }
}