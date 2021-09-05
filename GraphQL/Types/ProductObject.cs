using ECommerceSampleService.Models;
using GraphQL.Types;

namespace ECommerceSampleService.GraphQL.Types
{
    public sealed class ProductObject : ObjectGraphType<Product>
    {
        public ProductObject()
        {
            Name = nameof(Product);
            Description = "A product in th collection";

            Field(p => p.Id).Description("Identifier of the product");
            Field(p => p.Name).Description("Name of the product");
            Field(p => p.Description).Description("Description of the product");
            //Field(p => p.ProductType).Description("Type of the product");
            Field(
                name: "ProductType",
                description: "Type of the product",
                type: typeof(ProductTypeEnum),
                resolve: p => p.Source.ProductType);
        }
    }
}