using System.Collections.Generic;
using FastXml;
using NUnit.Framework;

namespace Tests {
	public class EmptyNodeFastTests {
		
		[TestCase(Cases.SingleNode1), TestCase(Cases.SingleNode2)]
		[TestCase(Cases.OpenCloseNode1), TestCase(Cases.OpenCloseNode2)]
		[TestCase(Cases.NodeWithHeader)]
		[TestCase(Cases.NodeWithComment1), TestCase(Cases.NodeWithComment2)]
		public void ParseEmptyNode_FastXml(string text) {
			var doc = new XmlReader().FromText(text);
			Assert.AreEqual(1, doc.Nodes.Count);
			Assert.True(doc.Nodes[0].Name == "root");
		}
		
		[Test]
		public void WriteEmptyNode_FastXml() {
			var doc = new XmlDocument();
			doc.Nodes.Add(new XmlNode("root"));
			Assert.AreEqual("<root />", new XmlWriter().ToText(doc));
		}
	}
}