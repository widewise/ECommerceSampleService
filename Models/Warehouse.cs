using System;

namespace ECommerceSampleService.Models
{
    public class Warehouse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Contacts Contacts { get; set; }
    }
}