using System.Collections.Generic;
using ECommerceSampleService.GraphQL.Types;
using ECommerceSampleService.Models;
using ECommerceSampleService.Repositories;
using GraphQL;
using GraphQL.Types;

namespace ECommerceSampleService.GraphQL
{
    public class QueryObject : ObjectGraphType<object>
    {
        public QueryObject(IProductRepository repository)
        {
            Name = "Queries";
            Description = "The base query for all the entities in our object graph.";

            FieldAsync<ProductObject, Product>(
                "product",
                "Gets a product byt its unique identifier.",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "id",
                        Description = "The unique GUID of the product."
                    }),
                context => repository.GetByIdAsync(context.GetArgument("id", 1))
            );

            FieldAsync<ListGraphType<ProductObject>, IEnumerable<Product>>(
                "products",
                "Gets product list by type.",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductTypeEnum>>
                    {
                        Name = "productType",
                        Description = "Type of the product."
                    }),
                context => repository.GetByTypeAsync(context.GetArgument("productType", ProductType.MotherBoards))
            );
        }
    }
}