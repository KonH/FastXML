using System.Collections.Generic;

namespace FastXml.Parser.States {
	class SkipToEndTagState : State {
		public override void Parse(string str, int index, char ch, Stack<State> states, XmlDocument doc) {
			if ( ch == '>' ) {
				states.Pop();
			}
		}
	}
}