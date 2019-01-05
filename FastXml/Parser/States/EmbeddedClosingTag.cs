using System.Collections.Generic;

namespace FastXml.Parser.States {
	class EmbeddedClosingTag : State {			
		public override void Parse(string str, int index, char ch, Stack<State> states, XmlDocument doc) {
			if ( ch == '>' ) {
				UnrollToOpeningTag(string.Empty, states);
			} else if ( !char.IsLetterOrDigit(ch) ) {
				throw new XmlFormatException("Unexpected character in tag");
			}
		}
	}
}