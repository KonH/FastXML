using System.Collections.Generic;

namespace FastXml.Parser.States {
	public class TagSelector : State {		
		public override void Parse(string str, int index, char ch, Stack<State> states, XmlDocument doc) {
			if ( ch == '!' ) {
				states.Pop();
				states.Push(new Comment(index));
			} else if ( ch == '?' ) {
				states.Pop();
				states.Push(new SkipToClosingTag());
			} else if ( ch == '/' ) {
				states.Pop();
				states.Push(new ClosingTag(index + 1));
			} else if ( char.IsLetter(ch) ) {
				states.Pop();
				states.Push(new OpeningTag(index));
			} else {
				throw new XmlFormatException(string.Format("Unexpected character after '<': '{0}'", ch));
			}
		}
	}
}