using FastXml;
using NUnit.Framework;

namespace Tests {
	public class NodeWithChildsFastTests {
		
		[TestCase(Cases.NodeWithChilds1)]
		public void ParseNodeWithChilds1_FastXml(string text) {
			var doc = XmlReader.FromText(text);
			Assert.AreEqual(1,       doc.Nodes[0].Nodes.Count);
			Assert.AreEqual("child", doc.Nodes[0].Nodes[0].Name);
		}
		
		[TestCase(Cases.NodeWithChilds2)]
		public void ParseNodeWithChilds2_FastXml(string text) {
			var doc = XmlReader.FromText(text);
			Assert.AreEqual(2,       doc.Nodes[0].Nodes.Count);
			Assert.AreEqual("child", doc.Nodes[0].Nodes[0].Name);
			Assert.AreEqual("child", doc.Nodes[0].Nodes[1].Name);
		}
		
		[TestCase(Cases.NodeWithChilds3)]
		public void ParseNodeWithChilds3_FastXml(string text) {
			var doc = XmlReader.FromText(text);
			Assert.AreEqual(1,          doc.Nodes[0].Nodes[0].Nodes.Count);
			Assert.AreEqual("subChild", doc.Nodes[0].Nodes[0].Nodes[0].Name);
		}

		[Test]
		public void WriteNodeWithChilds1_FastXml() {
			var doc = new XmlDocument();
			var root = new XmlNode("root");
			root.Nodes.Add(new XmlNode("child"));
			doc.Nodes.Add(root);
			Assert.AreEqual("<root><child /></root>", new XmlWriter().ToText(doc));
		}
		
		[Test]
		public void WriteNodeWithChilds2_FastXml() {
			var doc  = new XmlDocument();
			var root = new XmlNode("root");
			var child = new XmlNode("child");
			child.Nodes.Add(new XmlNode("subChild"));
			root.Nodes.Add(child);
			doc.Nodes.Add(root);
			Assert.AreEqual("<root><child><subChild /></child></root>", new XmlWriter().ToText(doc));
		}
	}
}