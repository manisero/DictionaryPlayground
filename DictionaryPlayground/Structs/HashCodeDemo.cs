using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryPlayground.Structs
{
    public struct TwoFields
    {
        public int Field1 { get; }
        public int Field2 { get; }

        public TwoFields(int field1, int field2)
        {
            Field1 = field1;
            Field2 = field2;
        }

        public override string ToString()
        {
            return $"({Field1}, {Field2})";
        }
    }

    public class HashCodeDemo
    {
        public void Run()
        {
            var items = new List<TwoFields>
            {
                new TwoFields(1, 1),
                new TwoFields(100, 100),
                new TwoFields(537, 537),
                new TwoFields(537, 1),
                new TwoFields(1, 537),
                new TwoFields(100, 537),
                new TwoFields(537, 100),
                new TwoFields(100, 101),
                new TwoFields(100, 102),
                new TwoFields(100, 103),
                new TwoFields(101, 102),
                new TwoFields(102, 103)
            };

            var groups = items.GroupBy(x => x.GetHashCode());

            foreach (var group in groups)
            {
                var groupMembers = String.Join(", ", group);
                Console.WriteLine($"Hash: {group.Key}. Items: {groupMembers}.");
            }
        }
    }
}
