using System.Xml;
using NUnit.Framework;

namespace Tests {
	public class NodeWithAttrSystemTests {		
		
		[TestCase(Cases.NodeWithAttr1)]
		public void ParseNodeWithAttr1_XmlDocument(string text) {
			var doc = new XmlDocument();
			doc.LoadXml(text);
			Assert.AreEqual(1, doc.ChildNodes[0].Attributes.Count);
			Assert.AreEqual("value", doc.ChildNodes[0].Attributes[0].Value);
		}
		
		[TestCase(Cases.NodeWithAttr2)]
		public void ParseNodeWithAttr2_XmlDocument(string text) {
			var doc = new XmlDocument();
			doc.LoadXml(text);
			Assert.AreEqual(1, doc.ChildNodes[0].Attributes.Count);
			Assert.AreEqual("", doc.ChildNodes[0].Attributes[0].Value);
		}
		
		[Test]
		public void WriteEmptyNode_XmlDocument() {
			var doc = new XmlDocument();
			var elem = doc.CreateElement("root");
			var attr = doc.CreateAttribute("attribute");
			attr.Value = "value";
			elem.Attributes.Append(attr);
			doc.AppendChild(elem);
			Assert.AreEqual("<root attribute=\"value\" />", doc.InnerXml);
		}
	}
}