using System;
using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1
{
    public class AppSchema : Schema
    {
        public AppSchema(IDependencyResolver resolver) :
            base(resolver)
        {
            Query = resolver.Resolve<AppQuery>();
        }
    }
}