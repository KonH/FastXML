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
			var doc = XmlReader.FromText(text);
			Assert.NotNull(doc.Root);
			Assert.True(doc.Root.Name == "root");
		}
		
		[Test]
		public void WriteEmptyNode_FastXml() {
			var doc = XmlDocument.FromRoot(new XmlNode("root"));
			Assert.AreEqual("<root />", XmlWriter.ToText(doc));
		}
	}
}