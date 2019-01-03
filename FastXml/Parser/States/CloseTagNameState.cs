using System.Collections.Generic;

namespace FastXml.Parser.States {
	class CloseTagNameState : State {
		int _startIndex;
			
		public CloseTagNameState(int startIndex) {
			_startIndex = startIndex;
		}
			
		public override void Parse(string str, int index, char ch, Stack<State> states, XmlDocument doc) {
			// </tag>
			if ( index == (_startIndex + 1) ) {
				if ( ch == '/' ) {
					return;
				}
				throw new XmlFormatException(string.Format("Unexpected character in closing tag, expect '/' instead of '{0}'", ch));
			}
			if ( ch == '>' ) {
				var nameStartIndex = _startIndex + 2; // </
				var closingName    = str.Substring(nameStartIndex, index - nameStartIndex);
				CreateNodeFromStates(closingName, states, doc);
			} else if ( !char.IsLetterOrDigit(ch) ) {
				throw new XmlFormatException(string.Format("Unexpected character in closing tag: '{0}'", ch));
			}
		}
	}
}