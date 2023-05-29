using System;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class CheckoutService
    {
        private readonly List<Item> items;



        public CheckoutService()
        {
            items = new List<Item>
            {
            new Item { SKU = 'A', Price = 50, Offer = new SpecialOffer { Quantity = 3, OfferPrice = 130 } },
            new Item { SKU = 'B', Price = 30, Offer = new SpecialOffer { Quantity = 2, OfferPrice = 45 } },
            new Item { SKU = 'C', Price = 20 },
            new Item { SKU = 'D', Price = 15 }
        };
        }



        public decimal CalculateTotalPrice(string skus)
        {
            var itemCounts = GetItemCounts(skus);



            decimal totalPrice = itemCounts.Sum(item => CalculateItemPrice(item.Key, item.Value));



            return totalPrice;
        }



        private Dictionary<char, int> GetItemCounts(string skus)
        {
            return skus.GroupBy(sku => sku)
                       .ToDictionary(group => group.Key, group => group.Count());
        }



        private decimal CalculateItemPrice(char sku, int quantity)
        {
            var selectedItem = items.FirstOrDefault(item => item.SKU == sku);
            if (selectedItem == null)
                return 0;



            if (selectedItem.Offer != null)
            {
                int offerQuantity = selectedItem.Offer.Quantity;
                int regularPriceQuantity = quantity % offerQuantity;
                int offerPriceQuantity = quantity / offerQuantity;



                return (offerPriceQuantity * selectedItem.Offer.OfferPrice) +
                       (regularPriceQuantity * selectedItem.Price);
            }



            return quantity * selectedItem.Price;
        }
    }



}
