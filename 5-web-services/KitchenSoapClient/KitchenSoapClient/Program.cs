using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenSoapClient.KitchenService;

namespace KitchenSoapClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // adding the service reference in visual studio
            // generated a client class as well as a class for the data
            // we are sending on some of the operations (FridgeItem)
            using (var client = new KitchenServiceClient())
            {
                var newItem = new FridgeItem
                {
                    Name = "fried plantains",
                    ExpirationDate = new DateTime(2020, 5, 1)
                };

                client.PutInFridge(newItem);

                var items = await client.LookInsideFridgeAsync();

                Console.WriteLine($"{items.Length} items:");
                foreach (FridgeItem item in items)
                {
                    Console.WriteLine($"{item.Name}, expires {item.ExpirationDate}");
                }

                Console.ReadLine(); // pause before exiting
            }
        }
    }
}
