using BenchmarkDotNet.Attributes;
using SystemXmlDocument = System.Xml.XmlDocument;
using SystemXmlElement = System.Xml.XmlElement;
using FastXmlDocument = FastXml.XmlDocument;
using FastXmlReader = FastXml.XmlReader;
using XmlNode = FastXml.XmlNode;
using XmlWriter = FastXml.XmlWriter;

namespace Benchmarks {
	[MemoryDiagnoser]
	public class DeepHierarchyWriteBenchmark {
		
		[Benchmark]
		public string SystemXml() {
			var doc = new SystemXmlDocument();
			var root = doc.CreateElement("root");
			var current = root;
			for ( var i = 0; i < 10; i++ ) {
				var newElement = doc.CreateElement("child");
				current.AppendChild(newElement);
				current = newElement;
			}
			doc.AppendChild(root);
			return doc.InnerXml;
		}

		[Benchmark]
		public string FastXml() {
			var root = new XmlNode("root");
			var current = root;
			for ( var i = 0; i < 10; i++ ) {
				var newElement = new XmlNode("child");
				current.Childs.Add(newElement);
				current = newElement;
			}
			var doc = FastXmlDocument.FromRoot(root);
			return XmlWriter.ToText(doc);
		}
	}
}