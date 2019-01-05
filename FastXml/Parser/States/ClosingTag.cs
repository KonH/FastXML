using System.Collections.Generic;

namespace FastXml.Parser.States {
	class ClosingTag : State {
		int _startIndex;
			
		public ClosingTag(int startIndex) {
			_startIndex = startIndex;
		}

		public override void Parse(string str, int index, char ch, Stack<State> states, XmlDocument doc) {
			if ( ch == '>' ) {
				var closingName = str.Substring(_startIndex, index - _startIndex);
				UnrollToOpeningTag(closingName, states);
			} else if ( !char.IsLetterOrDigit(ch) ) {
				throw new XmlFormatException(string.Format("Unexpected character in closing tag: '{0}'", ch));
			}
		}
	}
}