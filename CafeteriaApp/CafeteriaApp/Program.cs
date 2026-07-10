using System;
using System.Collections.Generic;
using CafeteriaApp.Models;
using CafeteriaApp.Services;

namespace CafeteriaApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderManager manager = new OrderManager();
            int choice;

            do
            {
                Console.WriteLine("\n=== COMPANY CAFETERIA SYSTEM ===");
                Console.WriteLine("1. Show Menu");
                Console.WriteLine("2. Place Order");
                Console.WriteLine("3. View All Orders");
                Console.WriteLine("4. Search Order");
                Console.WriteLine("5. Cancel Order");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice)) continue;

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n--- CAFETERIA MENU ---");
                        foreach (var item in manager.ShowMenu())
                            Console.WriteLine(item);
                        break;

                    case 2:
                        Console.Write("Enter Employee Name: ");
                        string name = Console.ReadLine();

                        Console.WriteLine("\n--- CAFETERIA MENU ---");
                        foreach (var item in manager.ShowMenu())
                            Console.WriteLine(item);

                        List<int> selectedItems = new List<int>();
                        while (true)
                        {
                            Console.Write("Enter item ID to add (0 to finish): ");
                            if (!int.TryParse(Console.ReadLine(), out int id) || id < 0)
                            {
                                Console.WriteLine("Invalid input.");
                                continue;
                            }

                            if (id == 0) break;

                            selectedItems.Add(id);
                            Console.WriteLine("Item queued.");
                        }

                        if (manager.PlaceOrder(name, selectedItems))
                        {
                            Console.WriteLine("\nOrder placed successfully!");
                        }
                        else
                        {
                            Console.WriteLine("\nFailed to place order. Ensure valid items were selected.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("\n--- ALL ORDERS ---");
                        var allOrders = manager.GetOrders();
                        if (allOrders.Count == 0)
                        {
                            Console.WriteLine("No orders have been placed yet.");
                        }
                        else
                        {
                            foreach (var ord in allOrders)
                                Console.WriteLine(ord);
                        }
                        break;

                    case 4:
                        Console.Write("Enter Order ID to search: ");
                        if (int.TryParse(Console.ReadLine(), out int searchId))
                        {
                            var result = manager.SearchOrder(searchId);
                            if (result != null)
                                Console.WriteLine($"\n{result}");
                            else
                                Console.WriteLine("\nOrder not found.");
                        }
                        break;

                    case 5:
                        Console.Write("Enter Order ID to cancel: ");
                        if (int.TryParse(Console.ReadLine(), out int cancelId))
                        {
                            if (manager.CancelOrder(cancelId))
                                Console.WriteLine("\nOrder cancelled.");
                            else
                                Console.WriteLine("\nOrder not found.");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Goodbye!");
                        break;
                }
            } while (choice != 0);
        }
    }
}