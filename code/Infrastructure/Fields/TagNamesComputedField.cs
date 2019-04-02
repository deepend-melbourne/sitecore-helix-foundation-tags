using System;
using System.Linq;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Diagnostics;
using Sitecore.Foundation.SitecoreExtensions.Extensions;

namespace Sitecore.Foundation.Tags.Infrastructure.Fields
{
    public class TagNamesComputedField : IComputedIndexField
    {
        public string FieldName { get; set; }

        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            try
            {
                var indexItem = indexable as SitecoreIndexableItem;
                if (indexItem == null)
                {
                    return null;
                }

                var item = indexItem.Item;

                if (item.IsDerived(Templates.HasTag.ID))
                {
                    return item
                        .GetMultiListValueItems(Templates.HasTag.Fields.Tags)
                        .Select(tag => string.IsNullOrEmpty(tag.DisplayName) ? tag.Name : tag.DisplayName)
                        .Where(tag => !string.IsNullOrEmpty(tag))
                        .Select(tag => tag.ToLower())
                        .ToArray();
                }

                return null;
            }
            catch (Exception ex)
            {
                Log.Error($"{nameof(TagNamesComputedField)} failed: {ex.Message}", ex, typeof(TagNamesComputedField));
            }

            return null;
        }
    }
}
