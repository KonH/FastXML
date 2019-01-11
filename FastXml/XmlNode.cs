using System.Collections.Generic;

namespace FastXml {
	public class XmlNode {
		public string Name { get; }
		public List<XmlNode> Childs { get; }
		public Dictionary<string, string> Attributes { get; }
		
		public XmlNode(string name, List<XmlNode> nodes = null) {
			Name = name;
			Childs = nodes ?? new List<XmlNode>();
			Attributes = new Dictionary<string, string>();
		}
	}
}