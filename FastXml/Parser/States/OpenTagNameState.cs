using System.Collections.Generic;

namespace FastXml.Parser.States {
	class OpenTagNameState : State {			
		int _startIndex;
			
		public string Name { get; private set; }
			
		public OpenTagNameState(int startIndex) {
			_startIndex = startIndex;
		}
			
		public override void Parse(string str, int index, char ch, Stack<State> states, XmlDocument doc) {
			if ( (ch == '!') || (ch == '?') ) {
				states.Pop();
				states.Push(new SkipToEndTagState());
			} else if ( ch == '/' ) {
				SetName(str, index);
				states.Push(new EmbeddedCloseTagState());
			} else if ( ch == '>') {
				SetName(str, index);
				states.Push(new InsideTagState());
			} else if ( char.IsWhiteSpace(ch) ) {
				SetName(str, index);
				states.Push(new TagBodyState());
			} else if ( !char.IsLetterOrDigit(ch) ) {
				throw new XmlFormatException("Unexpected character in tag");
			}
		}

		void SetName(string str, int index) {
			Name = str.Substring(_startIndex, index - _startIndex);
		}
	}
}