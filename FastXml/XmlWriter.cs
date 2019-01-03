using System.Text;

namespace FastXml {
	public class XmlWriter {
		StringBuilder _sb = new StringBuilder();
		
		public string ToText(XmlDocument xmlDoc) {
			_sb.Clear();
			foreach ( var node in xmlDoc.Nodes ) {
				_sb.AppendFormat("<{0} />", node.Name);
			}
			return _sb.ToString();
		}
	}
}