using System.Collections.Generic;

namespace FastXml {
	public class XmlNode {
		public string Name { get; }
		public List<XmlNode> Nodes { get; }
		public Dictionary<string, string> Attributes { get; }
		
		public XmlNode(string name, List<XmlNode> nodes = null) {
			Name = name;
			Nodes = nodes ?? new List<XmlNode>();
			Attributes = new Dictionary<string, string>();
		}
	}
}