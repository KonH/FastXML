using System.Collections.Generic;
using FastXml.Parser.States;

namespace FastXml.Parser {
	public class XmlParser {				
		public XmlDocument Parse(string xml) {
			var doc = new XmlDocument();
			var states = new Stack<State>();
			states.Push(new DocumentState());
			for ( var i = 0; i < xml.Length; i++ ) {
				var state = states.Peek();
				state.Parse(xml, i, xml[i], states, doc);
			}
			if ( states.Peek().GetType() == typeof(DocumentState) ) {
				return doc;
			} else {
				throw new XmlFormatException("Invalid Xml document");
			}
		}
	}
}