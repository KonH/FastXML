using System.Collections.Generic;

namespace FastXml.Parser.States {
	class DocumentState : State {
		public override void Parse(string str, int index, char ch, Stack<State> states, XmlDocument doc) {
			if ( ch == '<' ) {
				states.Push(new OpenTagNameState(index + 1));
			} else if ( !char.IsWhiteSpace(ch) ) {
				throw new XmlFormatException("Unexpected non-whitespace character in document");
			}
		}
	}
}