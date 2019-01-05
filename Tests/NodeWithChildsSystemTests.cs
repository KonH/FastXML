using System.Xml;
using NUnit.Framework;

namespace Tests {
	public class NodeWithChildsSystemTests {
		
		[TestCase(Cases.NodeWithChilds1)]
		public void ParseNodeWithChilds1_XmlDocument(string text) {
			var doc = new XmlDocument();
			doc.LoadXml(text);
			Assert.AreEqual(1,       doc.ChildNodes[0].ChildNodes.Count);
			Assert.AreEqual("child", doc.ChildNodes[0].ChildNodes[0].Name);
		}
		
		[TestCase(Cases.NodeWithChilds2)]
		public void ParseNodeWithChilds2_XmlDocument(string text) {
			var doc = new XmlDocument();
			doc.LoadXml(text);
			Assert.AreEqual(2,       doc.ChildNodes[0].ChildNodes.Count);
			Assert.AreEqual("child", doc.ChildNodes[0].ChildNodes[0].Name);
			Assert.AreEqual("child", doc.ChildNodes[0].ChildNodes[1].Name);
		}
		
		[TestCase(Cases.NodeWithChilds3)]
		public void ParseNodeWithChilds3_XmlDocument(string text) {
			var doc = new XmlDocument();
			doc.LoadXml(text);
			Assert.AreEqual(1,          doc.ChildNodes[0].ChildNodes[0].ChildNodes.Count);
			Assert.AreEqual("subChild", doc.ChildNodes[0].ChildNodes[0].ChildNodes[0].Name);
		}
	}
}