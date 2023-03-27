using System;
using WebApplication2.Models;

namespace WebApplication2.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Email? Email { get; set; }
    }
}
