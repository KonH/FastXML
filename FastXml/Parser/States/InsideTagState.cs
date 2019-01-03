using System.Collections.Generic;

namespace FastXml.Parser.States {
	class InsideTagState : State {
		public override void Parse(string str, int index, char ch, Stack<State> states, XmlDocument doc) {
			if ( ch == '<' ) {
				states.Pop();
				states.Push(new CloseTagNameState(index));
			} else if ( !char.IsWhiteSpace(ch) ) {
				throw new XmlFormatException("Unexpected non-whitespace character inside tag");
			}
		}
	}
}