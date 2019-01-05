using System.Collections.Generic;
using FastXml;
using NUnit.Framework;

namespace Tests {
	public class NodeWithAttrFastTests {
		
		[TestCase(Cases.NodeWithAttr1)]
		public void ParseNodeWithAttr1_FastXml(string text) {
			var doc = new XmlReader().FromText(text);
			Assert.AreEqual(1, doc.Nodes[0].Attributes.Count);
			Assert.AreEqual("value", doc.Nodes[0].Attributes["attribute"]);
		}
		
		[TestCase(Cases.NodeWithAttr2)]
		public void ParseNodeWithAttr2_FastXml(string text) {
			var doc = new XmlReader().FromText(text);
			Assert.AreEqual(1, doc.Nodes[0].Attributes.Count);
			Assert.AreEqual("", doc.Nodes[0].Attributes["attribute"]);
		}
		
		[Test]
		public void WriteEmptyNode_FastXml() {
			var doc  = new XmlDocument();
			var node = new XmlNode("root");
			node.Attributes["attribute"] = "value";
			doc.Nodes.Add(node);
			Assert.AreEqual("<root attribute=\"value\" />", new XmlWriter().ToText(doc));
		}
	}
}