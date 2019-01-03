using System.Collections.Generic;

namespace FastXml.Parser.States {
	class EmbeddedCloseTagState : State {			
		public override void Parse(string str, int index, char ch, Stack<State> states, XmlDocument doc) {
			if ( ch == '>' ) {
				CreateNodeFromStates(string.Empty, states, doc);
			} else if ( !char.IsLetterOrDigit(ch) ) {
				throw new XmlFormatException("Unexpected character in tag");
			}
		}
	}
}