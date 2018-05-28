using Sitecore.Foundation.DependencyInjection;
using System.Linq;
using Glass.Mapper.Sc;
using Sitecore.Data.Items;
using Sitecore.Foundation.Indexing.Search;
using Sitecore.Foundation.Tags.Model;
using Sitecore.ContentSearch.Linq.Utilities;

namespace Sitecore.Foundation.Tags.Search
{
    [Service]
    public class TagSearchService : SearchService<TagSearchResultItem, TagSearchRequest, ITag>
    {
        public TagSearchService(ISitecoreService sitecoreService) : base(sitecoreService)
        {
        }

        protected override IQueryable<TagSearchResultItem> ApplyPredicates(IQueryable<TagSearchResultItem> query, TagSearchRequest request)
        {
            if (request.TagNames != null && request.TagNames.Any())
            {
                query = ApplyTagNamePredicate(query, request.TagNames);
            }

            return query;
        }


        private IQueryable<TagSearchResultItem> ApplyTagNamePredicate(IQueryable<TagSearchResultItem> query, string[] tagNames)
        {
            var expression = PredicateBuilder.False<TagSearchResultItem>();

            foreach (var tagName in tagNames)
            {
                expression = expression.Or(i => i.Name == tagName);
            }

            return query.Where(expression);
        }

        protected override ITag GlassCast(Item item)
        {
            return SitecoreService.Cast<ITag>(item);
        }
    }
}
