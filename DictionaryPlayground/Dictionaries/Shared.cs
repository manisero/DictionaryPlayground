using System.Collections.Generic;

namespace DictionaryPlayground.Dictionaries
{
    public class Item
    {
        public int Id { get; set; }

        public struct StandardKey
        {
            public int Id { get; set; }
        }

        public struct GoodKey
        {
            public int Id { get; set; }

            public override int GetHashCode() => Id;
        }

        public struct BadKey
        {
            public int Id { get; set; }

            public override int GetHashCode() => 0;
        }

        public StandardKey GetStandardKey() => new StandardKey { Id = Id };
        public GoodKey GetGoodKey() => new GoodKey { Id = Id };
        public BadKey GetBadKey() => new BadKey { Id = Id };
    }

    public static class Shared
    {
        public static ICollection<Item> GenerateItems(int count)
        {
            var result = new List<Item>(count); ;

            for (var id = 1; id <= count; id++)
            {
                result.Add(new Item
                {
                    Id = id
                });
            }

            return result;
        }
    }
}
