using FastXml;
using NUnit.Framework;

namespace Tests {
	public class NodeWithChildsFastTests {
		
		[TestCase(Cases.NodeWithChilds1)]
		public void ParseNodeWithChilds1_FastXml(string text) {
			var doc = XmlReader.FromText(text);
			Assert.AreEqual(1, doc.Root.Childs.Count);
			Assert.AreEqual("child", doc.Root.Childs[0].Name);
		}
		
		[TestCase(Cases.NodeWithChilds2)]
		public void ParseNodeWithChilds2_FastXml(string text) {
			var doc = XmlReader.FromText(text);
			Assert.AreEqual(2,       doc.Root.Childs.Count);
			Assert.AreEqual("child", doc.Root.Childs[0].Name);
			Assert.AreEqual("child", doc.Root.Childs[1].Name);
		}
		
		[TestCase(Cases.NodeWithChilds3)]
		public void ParseNodeWithChilds3_FastXml(string text) {
			var doc = XmlReader.FromText(text);
			Assert.AreEqual(1,          doc.Root.Childs[0].Childs.Count);
			Assert.AreEqual("subChild", doc.Root.Childs[0].Childs[0].Name);
		}

		[Test]
		public void WriteNodeWithChilds1_FastXml() {
			var root = new XmlNode("root");
			root.Childs.Add(new XmlNode("child"));
			var doc = XmlDocument.FromRoot(root);
			Assert.AreEqual("<root><child /></root>", XmlWriter.ToText(doc));
		}
		
		[Test]
		public void WriteNodeWithChilds2_FastXml() {
			var root = new XmlNode("root");
			var child = new XmlNode("child");
			child.Childs.Add(new XmlNode("subChild"));
			root.Childs.Add(child);
			var doc = XmlDocument.FromRoot(root);
			Assert.AreEqual("<root><child><subChild /></child></root>", XmlWriter.ToText(doc));
		}
	}
}