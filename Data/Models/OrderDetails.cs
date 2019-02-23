using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class OrderDetails
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Qty{ get; set; } 
        public decimal Price{ get; set; } 
        public decimal TotalPrice{ get; set; }

        public Products Products { get; set; }

    }
}
