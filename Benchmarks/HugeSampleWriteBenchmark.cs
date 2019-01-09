using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

using SystemXmlDocument = System.Xml.XmlDocument;
using SystemXmlElement = System.Xml.XmlElement;

using FastXmlDocument = FastXml.XmlDocument;
using XmlNode = FastXml.XmlNode;
using XmlWriter = FastXml.XmlWriter;

namespace Benchmarks {
	[MemoryDiagnoser]
	public class HugeSampleWriteBenchmark {
		[Params(1, 4)]
		public int Depth;
		[Params(1)]
		public int Childs;
		[Params(0, 1)]
		public int Attributes;

		Dictionary<string, string> _attrValues = new Dictionary<string, string>();

		[GlobalSetup]
		public void Setup() {
			for ( var i = 0; i < Attributes; i++ ) {
				_attrValues.Add("attribute_" + i, "value" + i);
			}
		}
		
		[Benchmark]
		public string SystemXml() {
			var doc = new SystemXmlDocument();
			var element = doc.CreateElement("root");
			SystemAddElements(doc, element, 0);
			doc.AppendChild(element);
			return doc.InnerXml;
		}

		void SystemAddElements(SystemXmlDocument doc, SystemXmlElement element, int depth) {
			for ( var c = 0; c < Childs; c++ ) {
				var newElement = doc.CreateElement("child");
				foreach ( var attr in _attrValues ) {
					var newAttribute = doc.CreateAttribute(attr.Key);
					newAttribute.Value = attr.Value;
					newElement.Attributes.Append(newAttribute);
				}
				if ( depth < Depth ) {
					SystemAddElements(doc, newElement, depth + 1);
				}
				element.AppendChild(newElement);
			}
		}

		[Benchmark]
		public string FastXml() {
			var doc = new FastXmlDocument();
			var element = new XmlNode("root");
			FastAddElements(element, 0);
			doc.Nodes.Add(element);
			return new XmlWriter().ToText(doc);
		}
		
		void FastAddElements(XmlNode element, int depth) {
			for ( var c = 0; c < Childs; c++ ) {
				var newElement = new XmlNode("child");
				foreach ( var attr in _attrValues ) {
					newElement.Attributes[attr.Key] = attr.Value;
				}
				if ( depth < Depth ) {
					FastAddElements(newElement, depth + 1);
				}
				element.Nodes.Add(newElement);
			}
		}
	}
}