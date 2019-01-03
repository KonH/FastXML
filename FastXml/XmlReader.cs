using FastXml.Parser;

namespace FastXml {
	public class XmlReader {
		public XmlDocument FromText(string xml) {
			var parser = new XmlParser();
			var doc = parser.Parse(xml);
			return doc;
		}
	}
}