using BenchmarkDotNet.Running;
using System;

namespace DictionaryPlayground
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ComputationalComplexity.ComputationalComplexityBenchmark>();
            BenchmarkRunner.Run<Dictionaries.CapacityBenchmark>();
            BenchmarkRunner.Run<Dictionaries.ConstructionBenchmark>();
            BenchmarkRunner.Run<Dictionaries.AccessBenchmark>();
            new Structs.HashCodeDemo().Run();
            
            Console.ReadKey();
        }
    }
}
