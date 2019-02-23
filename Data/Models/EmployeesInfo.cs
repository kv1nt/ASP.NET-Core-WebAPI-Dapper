using System;

namespace Data.Models
{
    public class EmployeesInfo : IDEntity
    {
        public string MaritalStatus { get; set; }
        public string Address { get; set; }
        public DateTime BuirthDate { get; set; }
        public char[] Phone { get; set; }
    }
}