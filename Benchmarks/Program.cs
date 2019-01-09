using BenchmarkDotNet.Running;

namespace Benchmarks {
	class Program {
		static void Main(string[] args) {
			BenchmarkRunner.Run<ComplexSampleParseBenchmark>();
			BenchmarkRunner.Run<ComplexSampleWriteBenchmark>();
			BenchmarkRunner.Run<HugeSampleParseBenchmark>();
			BenchmarkRunner.Run<HugeSampleWriteBenchmark>();
		}
	}
}