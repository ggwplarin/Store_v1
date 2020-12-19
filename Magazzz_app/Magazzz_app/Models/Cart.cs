using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magazzz_app.Models
{
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<Product>();
        }
        public List<Product> CartLines { get; set; }
        public int FinalPrice
        {
            get
            {
                int sum = 0;
                foreach (Product product in CartLines)
                {
                    sum += product.product_price;
                }
                return sum;
            }
        }

    }
}
