using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartTDDAssignmentLib
{
    public class Item
    {
        public char name { get; set; }
        public int price { get; set; }
        public SpecialOffer specialOffer { get; set; }
    }
}
