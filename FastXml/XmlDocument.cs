namespace FastXml {
	public class XmlDocument {
		public XmlNode Root { get; }

		XmlDocument(XmlNode root) {
			Root = root;
		}

		public static XmlDocument FromRoot(XmlNode root) {
			return new XmlDocument(root);
		}
	}
}