using GraphQL.Types;

namespace WebApplication1
{
    public class EntryType : ObjectGraphType<Entry>
    {
        public EntryType()
        {
            Field(x => x.Id)
                .Description("The id property");

            Field(x => x.Name)
                .Description("The name property");

            Field(x => x.Namespace)
                .Description("The namespace property");

            Field(x => x.Locale)
                .Description("The locale property");
        }
    }
}