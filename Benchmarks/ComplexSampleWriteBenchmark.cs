using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

using SystemXmlDocument = System.Xml.XmlDocument;
using SystemXmlElement = System.Xml.XmlElement;

using FastXmlDocument = FastXml.XmlDocument;
using XmlNode = FastXml.XmlNode;
using XmlWriter = FastXml.XmlWriter;

namespace Benchmarks {
	[MemoryDiagnoser]
	public class ComplexSampleWriteBenchmark {

		[Benchmark]
		public string SystemXml() {
			var doc       = new SystemXmlDocument();
			var subChilds = new List<SystemXmlElement> { doc.CreateElement("subChild1"), doc.CreateElement("subChild2") };
			var attr2     = doc.CreateAttribute("attr2");
			attr2.Value = "value2";
			subChilds[0].Attributes.Append(attr2);
			var attr3 = doc.CreateAttribute("attr3");
			attr3.Value = "value3";
			subChilds[0].Attributes.Append(attr3);
			var child = doc.CreateElement("child0");
			var attr1 = doc.CreateAttribute("attr1");
			attr1.Value = "value1";
			child.Attributes.Append(attr1);
			var root = doc.CreateElement("root");
			child.AppendChild(subChilds[0]);
			child.AppendChild(subChilds[1]);
			root.AppendChild(child);
			doc.AppendChild(root);
			return doc.InnerXml;
		}

		[Benchmark]
		public string FastXml() {
			var doc       = new FastXmlDocument();
			var subChilds = new List<XmlNode> {new XmlNode("subChild1"), new XmlNode("subChild2") };
			subChilds[0].Attributes["attr2"] = "value2";
			subChilds[0].Attributes["attr3"] = "value3";
			var child = new XmlNode("child0", subChilds);
			child.Attributes["attr1"] = "value1";
			var root = new XmlNode("root", new List<XmlNode> { child });
			doc.Nodes.Add(root);
			return new XmlWriter().ToText(doc);
		}
	}
}