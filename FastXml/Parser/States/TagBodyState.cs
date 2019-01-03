using System.Collections.Generic;

namespace FastXml.Parser.States {
	class TagBodyState : State {
		public override void Parse(string str, int index, char ch, Stack<State> states, XmlDocument doc) {
			if ( ch == '>' ) {
				states.Push(new InsideTagState());
			} else if ( ch == '/' ) {
				states.Pop();
				states.Push(new EmbeddedCloseTagState());
			} else if ( !char.IsWhiteSpace(ch) ) {
				throw new XmlFormatException("Unexpected non-whitespace character in tag");
			}
		}
	}
}