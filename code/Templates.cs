using Sitecore.Data;

namespace Sitecore.Foundation.Tags
{
    public static class Templates
    {
        public struct Tag
        {
            public const string ID_String = "{D745865E-6251-466A-88E2-59A8E5FABCE5}";
            public static readonly ID ID = new ID(ID_String);
        }

        public struct HasTag
        {
            public const string ID_String = "{D5F1A828-895A-4CE0-93AE-125B0DD87252}";
            public static readonly ID ID = new ID(ID_String);

            public struct Fields
            {
                public const string Tags_String = "{C1549984-CDD0-4679-9ECB-8A355D880960}";
                public static readonly ID Tags = new ID(Tags_String);
            }
        }
    }
}
