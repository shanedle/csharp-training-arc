using System;
using System.Collections.Generic;

namespace InheritanceMiniProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<InventoryItemModel> inventory = new List<InventoryItemModel>();
            List<IRentalable> rentalables = new List<IRentalable>();    
            List<IPurchasable> purchasables = new List<IPurchasable>();

            var vehicle = new VehicleModel { DealerFee = 25, ProductName = "Lexus UX" };
            var book = new BookModel { ProductName = "One Piece", NumberOfPages = 999 };
            var excavator = new ExcavatorModel { ProductName = "Bulldozer", QuantityInStock = 10 };

            rentalables.Add(vehicle);
            rentalables.Add(excavator);

            purchasables.Add(book);
            purchasables.Add(vehicle);

            Console.Write("Do you want to rent or purchase something(rent/purchase)? ");
            string rentalDecision = Console.ReadLine();

            if (rentalDecision.ToLower() == "rent")
            {
                foreach (var item in rentalables)
                {
                    Console.WriteLine($"Item: { item.ProductName }");
                    Console.Write("Do you want to rent this item(yes/no)? ");
                    string wantToRent = Console.ReadLine();

                    if (wantToRent.ToLower() == "yes")
                    {
                        item.Rent();
                    }

                    Console.Write("Do you want to return this item(yes/no)? ");
                    string wantToReturn = Console.ReadLine();

                    if (wantToReturn.ToLower() == "yes")
                    {
                        item.ReturnRental();
                    }
                }
            } 
            else
            {
                foreach (var item in purchasables)
                {
                    Console.WriteLine($"Item: { item.ProductName }");
                    Console.Write("Do you want to purchase this item(yes/no)? ");
                    string wantToPurchase = Console.ReadLine();

                    if (wantToPurchase.ToLower() == "yes")
                    {
                        item.Purchase();
                    }
                }
            }

            Console.WriteLine("We are done.");

            Console.ReadLine();
        }
    }
   
}
