using System.Xml;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests {
	public class ComplexNodesSystemTests {
		
		[TestCase(Cases.ComplexNode)]
		public void ParseComplexNode_XmlDocument(string text) {
			var doc = new XmlDocument();
			doc.LoadXml(text);
			var root = doc.ChildNodes[0];
			Assert.AreEqual("root", root.Name);
			var child = root.ChildNodes[0];
			Assert.AreEqual("child0",  child.Name);
			Assert.AreEqual("value1", child.Attributes["attr1"].Value);
			var subChilds = child.ChildNodes;
			Assert.AreEqual("subChild1", subChilds[0].Name);
			Assert.AreEqual("value2",    subChilds[0].Attributes["attr2"].Value);
			Assert.AreEqual("value3",    subChilds[0].Attributes["attr3"].Value);
			Assert.AreEqual("subChild2", subChilds[1].Name);
		}
		
		[Test]
		public void WriteComplexNode_XmlDocument() {
			var doc = new XmlDocument();
			var subChilds = new List<XmlElement> { doc.CreateElement("subChild1"), doc.CreateElement("subChild2") };
			var attr2 = doc.CreateAttribute("attr2");
			attr2.Value = "value2";
			subChilds[0].Attributes.Append(attr2);
			var attr3 = doc.CreateAttribute("attr3");
			attr3.Value = "value3";
			subChilds[0].Attributes.Append(attr3);
			var child = doc.CreateElement("child0");
			var attr1 = doc.CreateAttribute("attr1");
			attr1.Value = "value1";
			child.Attributes.Append(attr1);
			var root = doc.CreateElement("root");
			child.AppendChild(subChilds[0]);
			child.AppendChild(subChilds[1]);
			root.AppendChild(child);
			doc.AppendChild(root);
			Assert.AreEqual(Cases.ComplexNode, doc.InnerXml);
		}
	}
}