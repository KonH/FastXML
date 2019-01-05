using System.Text;

namespace FastXml {
	public class XmlWriter {
		StringBuilder _sb = new StringBuilder();
		
		public string ToText(XmlDocument xmlDoc) {
			_sb.Clear();
			foreach ( var node in xmlDoc.Nodes ) {
				AppendNode(node);
			}
			return _sb.ToString();
		}

		void AppendNode(XmlNode node) {
			_sb.Append("<").Append(node.Name);
			if ( node.Nodes.Count > 0 ) {
				AddAttributes(node);
				_sb.Append(">");
				foreach ( var child in node.Nodes ) {
					AppendNode(child);
				}
				_sb.Append("</").Append(node.Name).Append(">");
			} else {
				AddAttributes(node);
				_sb.Append(" />");
			}
		}

		void AddAttributes(XmlNode node) {
			foreach ( var attr in node.Attributes ) {
				_sb.Append(" ");
				_sb.Append(attr.Key);
				_sb.Append("=");
				_sb.Append("\"").Append(attr.Value).Append("\"");
			}
		}
	}
}