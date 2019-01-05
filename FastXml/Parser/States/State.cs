using System.Collections.Generic;

namespace FastXml.Parser.States {
	public abstract class State {
		public abstract void Parse(string str, int index, char ch, Stack<State> states, XmlDocument doc);

		protected bool IsValidNamePart(char ch, int startIndex, int index) {
			if ( startIndex == index ) {
				return char.IsLetter(ch);
			}
			return char.IsLetterOrDigit(ch) || (ch == '_') || (ch == ':');
		}
		
		protected void UnrollToOpeningTag(string matchingClosingName, Stack<State> states) {
			while ( true ) {
				if ( states.Count == 0 ) {
					throw new XmlFormatException("Can't find matching opening tag");
				}
				var state = states.Pop();
				var openingState = state as OpeningTag;
				if ( openingState != null ) {
					if ( !string.IsNullOrEmpty(matchingClosingName) ) {
						if ( matchingClosingName != openingState.Node.Name ) {
							throw new XmlFormatException(
								string.Format("Invalid closing tag: '{0}', but '{1}' is expected", matchingClosingName, openingState.Node.Name)
							);
						}
					}
					return;
				}
			}
		}
		
		protected XmlNode GetLastNode(Stack<State> states) {
			foreach ( var state in states ) {
				var openingTag = state as OpeningTag;
				if ( (openingTag != null) && (openingTag != this) ) {
					return openingTag.Node;
				}
			}
			return null;
		}
	}
}