using FastXml.Parser;

namespace FastXml {
	public static class XmlReader {
		public static XmlDocument FromText(string xml) {
			return XmlParser.Parse(xml);
		}
	}
}