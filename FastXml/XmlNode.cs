using System.Collections.Generic;

namespace FastXml {
	public class XmlNode {
		public string Name { get; }
		public List<XmlNode> Nodes { get; }
		
		public XmlNode(string name, List<XmlNode> nodes = null) {
			Name = name;
			Nodes = nodes ?? new List<XmlNode>();
		}
	}
}