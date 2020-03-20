using System.Linq;
using Glass.Mapper.Sc;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.Foundation.DependencyInjection;
using Sitecore.Foundation.Indexing.Services;
using Sitecore.Foundation.Tags.Model;

namespace Sitecore.Foundation.Tags.Search
{
    [Service]
    public class TagSearchService : SearchService<TagSearchResultItem, TagSearchRequest, ITag>
    {
        public TagSearchService(ISitecoreService sitecoreService)
            : base(sitecoreService)
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

        protected override IQueryable<TagSearchResultItem> ApplyFacets(IQueryable<TagSearchResultItem> query, TagSearchRequest request)
        {
            return query;
        }

        private IQueryable<TagSearchResultItem> ApplyTagNamePredicate(IQueryable<TagSearchResultItem> query, string[] tagNames)
        {
            var expression = PredicateBuilder.False<TagSearchResultItem>();

            var normalisedTags = (tagNames ?? Enumerable.Empty<string>())
                .Select(tag => tag?.ToLower() ?? string.Empty)
                .Where(tag => !string.IsNullOrEmpty(tag))
                .ToList();

            if (normalisedTags.Any())
            {
                foreach (var tagName in tagNames)
                {
                    expression = expression.Or(i => i.Name == tagName);
                }
            }

            return query.Where(expression);
        }
    }
}
