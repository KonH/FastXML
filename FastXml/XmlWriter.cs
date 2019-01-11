using System.Text;

namespace FastXml {
	public static class XmlWriter {
		public static string ToText(XmlDocument xmlDoc, StringBuilder sb = null) {
			if ( sb == null ) {
				sb = new StringBuilder();
			} else {
				sb.Clear();
			}
			AppendNode(sb, xmlDoc.Root);
			return sb.ToString();
		}

		static void AppendNode(StringBuilder sb, XmlNode node) {
			sb.Append("<").Append(node.Name);
			if ( node.Childs.Count > 0 ) {
				AddAttributes(sb, node);
				sb.Append(">");
				foreach ( var child in node.Childs ) {
					AppendNode(sb, child);
				}
				sb.Append("</").Append(node.Name).Append(">");
			} else {
				AddAttributes(sb, node);
				sb.Append(" />");
			}
		}

		static void AddAttributes(StringBuilder sb, XmlNode node) {
			foreach ( var attr in node.Attributes ) {
				sb.Append(" ");
				sb.Append(attr.Key);
				sb.Append("=");
				sb.Append("\"").Append(attr.Value).Append("\"");
			}
		}
	}
}