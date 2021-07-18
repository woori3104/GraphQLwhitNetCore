using System;
using GraphQL;
using GraphQL.Types;
using GraphQlProject.Interfaces;
using GraphQlProject.Type;

namespace GraphQlProject.Query
{
    public class productQuery :ObjectGraphType
    {
        public productQuery(IProduct productService)
        {
            Field<ListGraphType<ProductType>>("products", resolve: context => { return productService.GetAllProducts(); });
            Field<ProductType>("products",arguments:
                new QueryArguments(new QueryArgument<IntGraphType> { Name = "id"}),

                resolve: context =>
                { return productService.GetProductById(context.GetArgument<int>("id"));
                });
        }
        
    }
}
