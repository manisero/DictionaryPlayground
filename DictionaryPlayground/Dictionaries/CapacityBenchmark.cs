using BenchmarkDotNet.Attributes;
using DictionaryPlayground.Shared;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryPlayground.Dictionaries
{
    public class CapacityBenchmark
    {
        [Params(100, 1000, 10000, 100000)]
        public int ItemsCount { get; set; }

        private ICollection<Item> _items;

        [GlobalSetup]
        public void Setup()
        {
            _items = Shared.GenerateItems(ItemsCount);
        }

        [Benchmark]
        public IDictionary<int, Item> Default()
        {
            return _items.ToDictionary(x => x.Id);
        }

        [Benchmark(Baseline = true)]
        public IDictionary<int, Item> SpecifiedCapacity()
        {
            return _items.ToDictWithCapacity(x => x.Id, _items.Count);
        }
    }
}
