using Benchmarks;

namespace NetFrameworkTestApp {
	class Program {
		static void Main(string[] args) {
			var b = new ComplexSampleParseBenchmark();
			FastXml.XmlDocument result = null;
			for (var i = 0; i < 1000; i++) {
				result = b.FastXml();
			}
		}
	}
}
