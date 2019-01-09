using BenchmarkDotNet.Attributes;

using SystemXmlDocument = System.Xml.XmlDocument;

using FastXmlReader = FastXml.XmlReader;
using FastXmlDocument = FastXml.XmlDocument;

namespace Benchmarks {
	[MemoryDiagnoser]
	public class HugeSampleParseBenchmark {
		[Params(1)]
		public int Depth;
		[Params(1)]
		public int Childs;
		[Params(0)]
		public int Attributes;

		string _inputXml;

		[GlobalSetup]
		public void Setup() {
			_inputXml = new HugeSampleWriteBenchmark { Depth = Depth, Childs = Childs, Attributes = Attributes }.SystemXml();
		}
		
		[Benchmark]
		public SystemXmlDocument SystemXml() {
			var doc = new SystemXmlDocument();
			doc.LoadXml(_inputXml);
			return doc;
		}

		[Benchmark]
		public FastXmlDocument FastXml() {
			return new FastXmlReader().FromText(_inputXml);
		}
	}
}