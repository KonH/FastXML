using System.Xml;
using NUnit.Framework;

namespace Tests {
	public class EmptyNodeSystemTests {		
		
		[TestCase(Cases.SingleNode1),    TestCase(Cases.SingleNode2)]
		[TestCase(Cases.OpenCloseNode1), TestCase(Cases.OpenCloseNode2)]
		[TestCase(Cases.NodeWithHeader), TestCase(Cases.NodeWithComment)]
		public void ParseEmptyNode_XmlDocument(string text) {
			var doc = new XmlDocument();
			doc.LoadXml(text);
			var found = false;
			foreach ( XmlNode node in doc.ChildNodes ) {
				found = (node.NodeType == XmlNodeType.Element) && (node.Name == "root");
			}
			Assert.True(found);
		}
		
		[Test]
		public void WriteEmptyNode_XmlDocument() {
			var doc = new XmlDocument();
			doc.AppendChild(doc.CreateElement("root"));
			Assert.AreEqual("<root />", doc.InnerXml);
		}
	}
}