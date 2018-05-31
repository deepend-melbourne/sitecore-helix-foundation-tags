using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Foundation.Models.Models.Interfaces;

namespace Sitecore.Foundation.Tags.Model
{
    [SitecoreType(AutoMap = true, TemplateId = Templates.HasTag.ID_String)]
    public interface IHasTags : IBaseItem
    {
        [SitecoreField(FieldId = Templates.HasTag.Fields.Tags_String)]
        IEnumerable<ITag> Tags { get; set; }
    }
}
