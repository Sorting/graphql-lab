using System.Collections.Generic;
using GraphQL.Instrumentation;
using GraphQL.Resolvers;
using GraphQL.Types;

namespace WebApplication1
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery()
        {
            Field<ListGraphType<EntryType>>(
                "entries",
                resolve: context => new List<Entry>
                {
                    new Entry()
                    {
                        Id = "thisIsVolvoCars",
                        Name = "This is Volvo Cars",
                        Namespace = "myApplication:pages.about",
                        Locale = (string)context.Arguments["locale"]
                    }
                }, arguments: new QueryArguments(new []
                {
                    new QueryArgument(new StringGraphType())
                    {
                        Name = "locale",
                        DefaultValue = "en",
                        ResolvedType = new StringGraphType()
                    }, 
                }));

            var nestedObjectType = new ObjectGraphType() {Name = "NestedObjectType"};

            nestedObjectType.Field<IntGraphType>()
                .Name("age")
                .Returns<int>()
                .Resolve(ctx => (int)ctx.Arguments["test"]);
            nestedObjectType.Field<StringGraphType>()
                .Name("locale")
                .Returns<string>()
                .Resolve(ctx => (string) ctx.Arguments["locale"]);

            var rootObjectType = new ObjectGraphType() {Name = "Root"};
            
            rootObjectType.AddField(new FieldType()
            {
                ResolvedType = nestedObjectType,
                Name = "nestedObject"
            });

            AddField(new FieldType()
            {
                ResolvedType = rootObjectType,                
                Arguments = new QueryArguments(
                    new List<QueryArgument> {
                        new QueryArgument(new IntGraphType())
                        {
                            DefaultValue =  10,
                            Name = "test",
                            ResolvedType = new IntGraphType()
                        },
                        new QueryArgument(new StringGraphType())
                        {
                            DefaultValue =  "en",
                            Name = "locale",
                            ResolvedType = new StringGraphType()                            
                        }}),
                Name = "Root"
            });
        }
    }
}