using ECommerceSampleService.Models;
using GraphQL.Types;

namespace ECommerceSampleService.GraphQL
{
    public sealed class ProductInputObject : InputObjectGraphType<Product>
    {
        public ProductInputObject()
        {
            Name = "ReviewInput";
            Description = "A review of the movie";

            Field(product => product.Name).Description("Name of the product");
            Field(product => product.Description).Description("Description of the product");
        }
    }
}