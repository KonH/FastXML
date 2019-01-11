using BenchmarkDotNet.Running;

namespace Benchmarks {
	class Program {
		static void Main(string[] args) {
			BenchmarkRunner.Run<ComplexSampleParseBenchmark>();
			BenchmarkRunner.Run<ComplexSampleWriteBenchmark>();
			BenchmarkRunner.Run<ManyAttributesParseBenchmark>();
			BenchmarkRunner.Run<ManyAttributesWriteBenchmark>();
			BenchmarkRunner.Run<DeepHierarchyParseBenchmark>();
			BenchmarkRunner.Run<DeepHierarchyWriteBenchmark>();
		}
	}
}