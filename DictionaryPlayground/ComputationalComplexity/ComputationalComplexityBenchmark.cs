using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace DictionaryPlayground.ComputationalComplexity
{
    public class ComputationalComplexityBenchmark
    {
        public class Item
        {
            public int Id { get; set; }
            public int? ParentId { get; set; }
            public Item Parent { get; set; }
        }

        [Params(100, 200, 400, 800)]
        public int ItemsCount { get; set; }

        private ICollection<Item> _items;

        [GlobalSetup]
        public void Setup()
        {
            _items = GenerateItems(ItemsCount);
        }

        [Benchmark]
        public ICollection<Item> SquareComplexity()
        {
            foreach (var item in _items)
            {
                if (item.ParentId == null)
                {
                    continue;
                }

                foreach (var potentialParent in _items)
                {
                    if (potentialParent.Id == item.ParentId)
                    {
                        item.Parent = potentialParent;
                        break;
                    }
                }
            }

            return _items;
        }

        [Benchmark(Baseline = true)]
        public ICollection<Item> LinearComplexity()
        {
            var dict = new Dictionary<int, Item>(ItemsCount);

            foreach (var item in _items)
            {
                dict.Add(item.Id, item);
            }

            foreach (var item in _items)
            {
                if (item.ParentId == null)
                {
                    continue;
                }

                item.Parent = dict[item.ParentId.Value];
            }

            return _items;
        }

        private ICollection<Item> GenerateItems(int count)
        {
            var result = new List<Item>(count)
            {
                new Item
                {
                    Id = 1,
                    ParentId = null
                }
            };

            for (var id = 2; id <= count; id++)
            {
                result.Add(new Item
                {
                    Id = id,
                    ParentId = id - 1
                });
            }

            return result;
        }
    }
}
