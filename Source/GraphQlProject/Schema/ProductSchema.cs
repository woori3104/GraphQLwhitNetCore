using System;
using GraphQlProject.Mutation;
using GraphQlProject.Query;

namespace GraphQlProject.Schema
{
    public class ProductSchema : GraphQL.Types.Schema
    { 
        public ProductSchema(ProductQuery propuctQuery, ProductMutation productMutation)
        {
            Query = propuctQuery;
            Mutation = productMutation;
        }
    }
}
