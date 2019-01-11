using BenchmarkDotNet.Attributes;
using TObject.Shared;
using SystemXmlDocument = System.Xml.XmlDocument;
using FastXmlDocument = FastXml.XmlDocument;
using FastXmlReader = FastXml.XmlReader;

namespace Benchmarks {
	[MemoryDiagnoser]
	public class ManyAttributesParseBenchmark {
		const string _input = 
			"<root attr_0=\"value_0\" attr_1=\"value_1\" attr_2=\"value_2\" attr_3=\"value_3\" attr_4=\"value_4\">" +
			"<element attr_0=\"value_0\" attr_1=\"value_1\" attr_2=\"value_2\" attr_3=\"value_3\" attr_4=\"value_4\" />" +
			"</root>";
		
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