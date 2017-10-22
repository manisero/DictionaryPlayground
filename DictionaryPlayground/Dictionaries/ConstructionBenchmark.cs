using BenchmarkDotNet.Attributes;
using DictionaryPlayground.Shared;
using System.Collections.Generic;

namespace DictionaryPlayground.Dictionaries
{
    public class ConstructionBenchmark
    {
        [Params(100, 200, 400, 800)]
        public int ItemsCount { get; set; }

        private ICollection<Item> _items;

        [GlobalSetup]
        public void Setup()
        {
            _items = Shared.GenerateItems(ItemsCount);
        }

        [Benchmark(Baseline = true)]
        public IDictionary<int, Item> JustInt()
        {
            return _items.ToDictWithCapacity(x => x.Id, _items.Count);
        }

        [Benchmark]
        public IDictionary<Item.StandardKey, Item> Standard()
        {
            return _items.ToDictWithCapacity(x => x.GetStandardKey(), _items.Count);
        }

        [Benchmark]
        public IDictionary<Item.GoodKey, Item> Good()
        {
            return _items.ToDictWithCapacity(x => x.GetGoodKey(), _items.Count);
        }

        [Benchmark]
        public IDictionary<Item.BadKey, Item> Bad()
        {
            return _items.ToDictWithCapacity(x => x.GetBadKey(), _items.Count);
        }
    }
}
