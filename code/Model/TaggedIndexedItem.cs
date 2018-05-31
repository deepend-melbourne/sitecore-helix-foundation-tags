using System;
using System.Collections.Generic;
using Sitecore.ContentSearch;
using Sitecore.Foundation.Indexing.Models;

namespace Sitecore.Foundation.Tags.Model
{
    public class TaggedIndexedItem : IndexedItem
    {
        [IndexField("tags_sm")]
        public IEnumerable<Guid> Tags { get; set; }
    }
}
