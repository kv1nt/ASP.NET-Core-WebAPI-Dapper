using System;

namespace Data.Models
{
    public class Customers : IDEntity
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public string Address{ get; set; }
        public string City{ get; set; }
        public string Phone{ get; set; }
        public DateTime DateInSystem{ get; set; }

        public Orders Orders { get; set; }
    }
}