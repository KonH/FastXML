using FastXmlReader = FastXml.XmlReader;
using FastXmlDocument = FastXml.XmlDocument;

namespace Benchmarks {
	public class ComplexSampleParseBenchmark {
		const string _input = "<root><child0 attr1=\"value1\"><subChild1 attr2=\"value2\" attr3=\"value3\" /><subChild2 /></child0></root>";

		public FastXmlDocument FastXml() {
			return FastXmlReader.FromText(_input);
		}
	}
}