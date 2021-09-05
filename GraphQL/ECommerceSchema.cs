using System;
using GraphQL.Types;

namespace ECommerceSampleService.GraphQL
{
    public class ECommerceSchema : Schema
    {
        public ECommerceSchema(QueryObject query, MutationObject mutation, IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            Query = query;
            Mutation = mutation;
        }
    }
}