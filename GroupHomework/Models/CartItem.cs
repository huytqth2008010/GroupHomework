using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupHomework.Models
{
    class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageProduct { get; set; }

        public int Price { get; set; }
        public int Qty { get; set; }

     
    }
}
