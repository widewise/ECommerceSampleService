using ECommerceSampleService.GraphQL.Types;
using ECommerceSampleService.Models;
using ECommerceSampleService.Repositories;
using GraphQL;
using GraphQL.Types;

namespace ECommerceSampleService.GraphQL
{
    public class MutationObject : ObjectGraphType<object>
    {
        public MutationObject(IProductRepository repository)
        {
            Name = "Mutations";
            Description = "The base mutation for all the entities in our object graph.";
            FieldAsync<ProductObject, Product>(
                "addProduct",
                "Add product to a movie.",
                new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>>
                {
                    Name = "name",
                    Description = "Name of product."
                },
                new QueryArgument<NonNullGraphType<StringGraphType>>
                {
                    Name = "description",
                    Description = "Description of product."
                },
                new QueryArgument<NonNullGraphType<ProductTypeEnum>>
                {
                    Name = "productType",
                    Description = "Type of product."
                }),
                context =>
                {
                    var name = context.GetArgument<string>("name");
                    var description = context.GetArgument<string>("description");
                    var productType = context.GetArgument<ProductType>("productType");

                    return repository.AddAsync(name, description, productType);
                }
            );
        }
    }
}