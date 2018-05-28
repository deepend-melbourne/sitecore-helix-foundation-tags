using Sitecore.Foundation.Indexing.Search;

namespace Sitecore.Foundation.Tags.Search
{
    public class TagSearchRequest : SearchRequest
    {
        public TagSearchRequest()
        {
            TemplateIds = new[]
            {
                Templates.Tag.ID
            };
        }

        public string[] TagNames { get; set; }
    }
}
