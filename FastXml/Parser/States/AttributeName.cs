using System.Collections.Generic;

namespace FastXml.Parser.States {
	class AttributeName : State {
		public string Name { get; private set; }
		
		int _startIndex;
			
		public AttributeName(int startIndex) {
			_startIndex = startIndex;
		}
			
		public override void Parse(string str, int index, char ch, Stack<State> states, XmlDocument doc) {
			if ( char.IsWhiteSpace(ch) ) {
				SetName(str, index);
				states.Push(new AttributeEquals());
			} else if ( ch == '=' ) {
				SetName(str, index);
				states.Push(new AttributeStartingQuote());
			}  else if ( !IsValidNamePart(ch, _startIndex, index) ) {
				throw new XmlFormatException(string.Format("Unexpected character in attribute name: '{0}'", ch));
			}
		}

		void SetName(string str, int index) {
			Name = str.Substring(_startIndex, index - _startIndex);
		}
	}
}