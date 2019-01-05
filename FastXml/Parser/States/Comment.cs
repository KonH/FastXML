using System.Collections.Generic;

namespace FastXml.Parser.States {
	class Comment : State {
		int _startIndex = 0;
		int _dashes = 0;

		public Comment(int startIndex) {
			_startIndex = startIndex;
		}
		
		public override void Parse(string str, int index, char ch, Stack<State> states, XmlDocument doc) {
			if ( index < (_startIndex + 2) ) {
				return;
			}
			if ( _dashes == 2 ) {
				if ( ch == '>' ) {
					states.Pop();
				} else {
					throw new XmlFormatException(string.Format("Unexpected character inside comment: '{0}' instead of '>'", ch));
				}
			} else if ( ch == '-' ) {
				_dashes++;
			} else {
				_dashes = 0;
			}
		}
	}
}