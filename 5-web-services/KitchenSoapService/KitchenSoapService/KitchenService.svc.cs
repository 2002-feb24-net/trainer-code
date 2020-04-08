using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KitchenSoapService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "KitchenService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select KitchenService.svc or KitchenService.svc.cs at the Solution Explorer and start debugging.
    public class KitchenService : IKitchenService
    {
        public static List<FridgeItem> FoodInFridge = new List<FridgeItem>
        {
            new FridgeItem { Id = 1, Name = "coffee", Expiration = new DateTime(2020, 12, 12) },
            new FridgeItem { Id = 2, Name = "mushrooms", Expiration = new DateTime(2020, 12, 12) },
            new FridgeItem { Id = 3, Name = "mold", Expiration = new DateTime(2018, 12, 12) }, // expired
            new FridgeItem { Id = 4, Name = "milk", Expiration = new DateTime(2019, 10, 1) } // expired
        };

        public List<FridgeItem> OpenFridge()
        {
            return FoodInFridge;
        }

        public void PutInFridge(FridgeItem item)
        {
            item.Id = FoodInFridge.Max(i => i.Id) + 1;

            FoodInFridge.Add(item);
        }

        public bool CleanFridge()
        {
            var removed = FoodInFridge.RemoveAll(i => i.Expiration < DateTime.Now);
            // if any removed, return true
            return removed > 0;
        }

        public FridgeItem TakeOutLeftovers()
        {
            var result = FoodInFridge.FirstOrDefault(i => i.Name == "leftovers");
            if (result == null)
            {
                throw new FaultException("no leftovers found 😢");
            }
            return result;
        }
    }
}
