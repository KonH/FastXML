using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using FastXml;
using SystemXmlDocument = System.Xml.XmlDocument;
using SystemXmlElement = System.Xml.XmlElement;
using FastXmlDocument = FastXml.XmlDocument;
using FastXmlReader = FastXml.XmlReader;

namespace Benchmarks {
	[MemoryDiagnoser]
	public class ManyAttributesWriteBenchmark {
		static Dictionary<string, string> _attributes = new Dictionary<string, string> {
			{ "attr_0", "value_0" },
			{ "attr_1", "value_1" },
			{ "attr_2", "value_2" },
			{ "attr_3", "value_3" },
			{ "attr_4", "value_4" },
		};

		[Benchmark]
		public string SystemXml() {
			var doc       = new SystemXmlDocument();
			var element = doc.CreateElement("element");
			foreach ( var pair in _attributes ) {
				var attr = doc.CreateAttribute(pair.Key);
				attr.Value = pair.Value;
				element.Attributes.Append(attr);
			}
			var root = doc.CreateElement("root");
			foreach ( var pair in _attributes ) {
				var attr = doc.CreateAttribute(pair.Key);
				attr.Value = pair.Value;
				root.Attributes.Append(attr);
			}
			root.AppendChild(element);
			doc.AppendChild(root);
			return doc.InnerXml;
		}

		[Benchmark]
		public string FastXml() {
			var element = new XmlNode("element");
			foreach ( var pair in _attributes ) {
				element.Attributes[pair.Key] = pair.Value;
			}
			var root = new XmlNode("root");
			foreach ( var pair in _attributes ) {
				root.Attributes[pair.Key] = pair.Value;
			}
			root.Childs.Add(element);
			var doc  = FastXmlDocument.FromRoot(root);
			return XmlWriter.ToText(doc);
		}
	}
}