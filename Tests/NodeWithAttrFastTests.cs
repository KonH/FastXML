using System.Collections.Generic;
using FastXml;
using NUnit.Framework;

namespace Tests {
	public class NodeWithAttrFastTests {
		
		[TestCase(Cases.NodeWithAttr1)]
		public void ParseNodeWithAttr1_FastXml(string text) {
			var doc = XmlReader.FromText(text);
			Assert.AreEqual(1, doc.Root.Attributes.Count);
			Assert.AreEqual("value", doc.Root.Attributes["attribute"]);
		}
		
		[TestCase(Cases.NodeWithAttr2)]
		public void ParseNodeWithAttr2_FastXml(string text) {
			var doc = XmlReader.FromText(text);
			Assert.AreEqual(1, doc.Root.Attributes.Count);
			Assert.AreEqual("", doc.Root.Attributes["attribute"]);
		}
		
		[Test]
		public void WriteEmptyNode_FastXml() {
			var root = new XmlNode("root");
			root.Attributes["attribute"] = "value";
			var doc = XmlDocument.FromRoot(root);
			Assert.AreEqual("<root attribute=\"value\" />", XmlWriter.ToText(doc));
		}
	}
}