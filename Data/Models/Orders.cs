using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Orders : IDEntity
    {
        public DateTime OrderDate { get; set; }
        public OrderDetails OrderDetails { get; set; }

    }
}
