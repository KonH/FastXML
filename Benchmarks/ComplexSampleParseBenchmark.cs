using BenchmarkDotNet.Attributes;

using SystemXmlDocument = System.Xml.XmlDocument;

using FastXmlReader = FastXml.XmlReader;
using FastXmlDocument = FastXml.XmlDocument;

namespace Benchmarks {
	[MemoryDiagnoser]
	public class ComplexSampleParseBenchmark {
		const string _input = "<root><child0 attr1=\"value1\"><subChild1 attr2=\"value2\" attr3=\"value3\" /><subChild2 /></child0></root>";

		[Benchmark]
		public SystemXmlDocument SystemXml() {
			var doc = new SystemXmlDocument();
			doc.LoadXml(_input);
			return doc;
		}

		[Benchmark]
		public FastXmlDocument FastXml() {
			return new FastXmlReader().FromText(_input);
		}
	}
}