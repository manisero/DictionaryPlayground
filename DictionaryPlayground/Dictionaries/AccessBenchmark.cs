using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryPlayground.Dictionaries
{
    public class AccessBenchmark
    {
        [Params(100, 200, 400, 800)]
        public int ItemsCount { get; set; }

        private int _searchedItemId;

        private ICollection<Item> _items;
        private IDictionary<Item.StandardKey, Item> _itemsByStandard;
        private IDictionary<Item.GoodKey, Item> _itemsByGood;
        private IDictionary<Item.BadKey, Item> _itemsByBad;

        public void Setup()
        {
            _searchedItemId = ItemsCount - 10;
            _items = Shared.GenerateItems(ItemsCount);
        }

        [GlobalSetup(Target = nameof(JustInt))]
        public void SetupJustInt()
        {
            Setup();
        }

        [Benchmark]
        public Item JustInt()
        {
            return _items.Single(x => x.Id == _searchedItemId);
        }

        [GlobalSetup(Target = nameof(Standard))]
        public void SetupStandard()
        {
            Setup();
            _itemsByStandard = _items.ToDictionary(x => x.GetStandardKey());
        }

        [Benchmark(Baseline = true)]
        public Item Standard()
        {
            return _itemsByStandard[new Item.StandardKey { Id = _searchedItemId }];
        }

        [GlobalSetup(Target = nameof(Good))]
        public void SetupGood()
        {
            Setup();
            _itemsByGood = _items.ToDictionary(x => x.GetGoodKey());
        }

        [Benchmark]
        public Item Good()
        {
            return _itemsByGood[new Item.GoodKey { Id = _searchedItemId }];
        }

        [GlobalSetup(Target = nameof(Bad))]
        public void SetupBad()
        {
            Setup();
            _itemsByBad = _items.ToDictionary(x => x.GetBadKey());
        }

        [Benchmark]
        public Item Bad()
        {
            return _itemsByBad[new Item.BadKey { Id = _searchedItemId }];
        }
    }
}
