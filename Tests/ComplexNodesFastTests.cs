using System.Collections.Generic;
using FastXml;
using NUnit.Framework;

namespace Tests {
	public class ComplexNodesFastTests {
		
		[TestCase(Cases.ComplexNode)]
		public void ParseComplexNode_FastXml(string text) {
			var doc = XmlReader.FromText(text);
			Assert.AreEqual("root", doc.Root.Name);
			var child = doc.Root.Childs[0];
			Assert.AreEqual("child0", child.Name);
			Assert.AreEqual("value1", child.Attributes["attr1"]);
			var subChilds = child.Childs;
			Assert.AreEqual("subChild1", subChilds[0].Name);
			Assert.AreEqual("value2", subChilds[0].Attributes["attr2"]);
			Assert.AreEqual("value3", subChilds[0].Attributes["attr3"]);
			Assert.AreEqual("subChild2", subChilds[1].Name);
		}

		[Test]
		public void WriteComplexNode_FastXml() {
			var subChilds = new List<XmlNode> {new XmlNode("subChild1"), new XmlNode("subChild2") };
			subChilds[0].Attributes["attr2"] = "value2";
			subChilds[0].Attributes["attr3"] = "value3";
			var child = new XmlNode("child0", subChilds);
			child.Attributes["attr1"] = "value1";
			var root = new XmlNode("root", new List<XmlNode> { child });
			var doc = XmlDocument.FromRoot(root);
			Assert.AreEqual(Cases.ComplexNode, XmlWriter.ToText(doc));
		}
	}
}