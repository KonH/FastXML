using System.Collections.Generic;
using System.Linq;
using FastXml.Parser.States;

namespace FastXml.Parser {
	public class XmlParser {				
		public XmlDocument Parse(string xml) {
			var doc = new XmlDocument();
			var states = new Stack<State>();
			states.Push(new Document());
			for ( var i = 0; i < xml.Length; i++ ) {
				var state = states.Peek();
				state.Parse(xml, i, xml[i], states, doc);
				System.Console.WriteLine(
					"'{0}' => {1}", 
					xml[i], string.Join("; ", states.Select(s => s.GetType().Name).Reverse())
				);
			}
			if ( states.Peek().GetType() == typeof(Document) ) {
				return doc;
			} else {
				throw new XmlFormatException("Invalid Xml document");
			}
		}
	}
}