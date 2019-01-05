using System.Collections.Generic;

namespace FastXml.Parser.States {
	class AttributeEquals : State {
		public override void Parse(string str, int index, char ch, Stack<State> states, XmlDocument doc) {
			if ( ch == '=' ) {
				states.Pop();
				states.Push(new AttributeStartingQuote());
			} else if ( !char.IsWhiteSpace(ch) ) {
				throw new XmlFormatException(
					string.Format("Unexpected non-whitespace character in attribute declaration: '{0}'", ch)
				);
			}
		}
	}
}