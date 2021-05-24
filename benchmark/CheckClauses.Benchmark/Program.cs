using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using BenchmarkDotNet;
using Ardalis.GuardClauses;

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
        public void StringCheckClauses()
        {
            for (int i = 0; i <= 100; i++) Check.Clauses("numero", i.ToString()).IsNullOrEmpty();
        }
        [Benchmark]
        public void StringGuardClauses()
        {
            for (int i = 0; i <= 100; i++) Guard.Against.NullOrEmpty(i.ToString(), "numero");
        }
    }
}
