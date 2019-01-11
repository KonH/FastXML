using BenchmarkDotNet.Attributes;
using TObject.Shared;
using SystemXmlDocument = System.Xml.XmlDocument;
using FastXmlDocument = FastXml.XmlDocument;
using FastXmlReader = FastXml.XmlReader;

namespace Benchmarks {
	[MemoryDiagnoser]
	public class DeepHierarchyParseBenchmark {
		const string _input = "<root><c0><c1><c2><c3><c4><c5><c6><c7><c8><c9><c10/></c9></c8></c7></c6></c5></c4></c3></c2></c1></c0></root>";
		
		[Benchmark]
		public SystemXmlDocument SystemXml() {
			var doc = new SystemXmlDocument();
			doc.LoadXml(_input);
			return doc;
		}

		[Benchmark]
		public FastXmlDocument FastXml() {
			return FastXmlReader.FromText(_input);
		}

		[Benchmark]
		public object NanoXml() {
			var doc = new NanoXMLDocument(_input);
			return doc;
		}
	}
}