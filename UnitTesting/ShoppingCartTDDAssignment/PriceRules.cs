using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartTDDAssignmentLib
{
    public class InvalidItemException : Exception
    {
        public InvalidItemException() : base("Invalid Item")
        {
        }
    }
    public class PriceRules
    {
        private Dictionary<char, Item> items = new Dictionary<char, Item>();

        public void Add(char itemName, int price, SpecialOffer specialOffer = null)
        {
            items[itemName] = new Item { name = itemName, price = price, specialOffer = specialOffer };
        }

        public int CalculateTotal(string itemsList)
        {
            Dictionary<char, int> itemCount = new Dictionary<char, int>();
            int total = 0;

            foreach (char item in itemsList)
            {
                if (items.ContainsKey(item))
                {
                    if (!itemCount.ContainsKey(item))
                        itemCount[item] = 0;

                    itemCount[item]++;
                }
                else
                {
                    throw new InvalidItemException(); 
                }
            }

            foreach (var kvp in itemCount)
            {
                char itemName = kvp.Key;
                int count = kvp.Value;
                Item item = items[itemName];

                if (item.specialOffer != null)
                {
                    total += (count / item.specialOffer.quantity) * item.specialOffer.offerPrice + (count % item.specialOffer.quantity) * item.price;
                }
                else
                {
                    total += count * item.price;
                }
            }

            return total;
        }
    }
}
