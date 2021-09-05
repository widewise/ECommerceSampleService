using System;

namespace ECommerceSampleService.Models
{
    public class Contacts
    {
        public Guid Id { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}