using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using BenchmarkDotNet;
namespace JuniorPorfirio.CheckClauses.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<CheckClauses>();
        }


    }
    [MemoryDiagnoser]
    public class CheckClauses
    {
        [Benchmark]
        public void ValidateString()
        {
            for (int i = 0; i <= 100; i++) Check.Clauses("numero", i.ToString()).NullEmpty();
        }
        [Benchmark]
        public void ValidateInt()
        {
            for (int i = 0; i <= 100; i++) Check.Clauses("numero", i).Null();
        }
    }
}
