using System;

namespace OrdersManagement.Model
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
       
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
        
        public string CityAddress { get; set; }
       
        public string PhoneNumber { get; set; }
    }
}
