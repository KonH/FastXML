using System.Collections.Generic;

namespace FastXml.Parser.States {
	class Document : State {
		public override void Parse(string str, int index, char ch, Stack<State> states, XmlDocument doc) {
			if ( ch == '<' ) {
				states.Push(new TagSelector());
			} else if ( !char.IsWhiteSpace(ch) ) {
				throw new XmlFormatException("Unexpected non-whitespace character in document");
			}
		}
	}
}