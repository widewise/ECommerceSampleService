using System;

namespace ECommerceSampleService.Models
{
    public class ProductAvailability
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public Warehouse Warehouse { get; set; }
        public decimal Cost { get; set; }
        public int Count { get; set; }
    }
}