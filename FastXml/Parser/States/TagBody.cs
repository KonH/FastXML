using System.Collections.Generic;

namespace FastXml.Parser.States {
	class TagBody : State {
		public override void Parse(string str, int index, char ch, Stack<State> states, XmlDocument doc) {
			if ( ch == '>' ) {
				states.Push(new InsideTag());
			} else if ( ch == '/' ) {
				states.Pop();
				states.Push(new EmbeddedClosingTag());
			} else if ( !char.IsWhiteSpace(ch) ) {
				throw new XmlFormatException("Unexpected non-whitespace character in tag");
			}
		}
	}
}