using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Foundation.Models.Models.Interfaces;

namespace Sitecore.Foundation.Tags.Model
{
    [SitecoreType(AutoMap = true, TemplateId = Templates.Tag.ID_String)]
    public interface ITag : IBaseItem
    {
    }
}
