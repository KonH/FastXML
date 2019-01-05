using BenchmarkDotNet.Running;

namespace Benchmarks {
	class Program {
		static void Main(string[] args) {
			BenchmarkRunner.Run<ComplexSampleParseBenchmark>();
			BenchmarkRunner.Run<ComplexSampleWriteBenchmark>();
		}
	}
}