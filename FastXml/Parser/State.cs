using System.Collections.Generic;

namespace FastXml.Parser {
	public enum StateType {
		AttributeEquals,
		AttributeName,
		AttributeStartingQuote,
		AttributeValue,
		ClosingTag,
		Comment,
		Document,
		EmbeddedClosingTag,
		InsideTag,
		OpeningTag,
		SkipToClosingTag,
		TagBody,
		TagSelector
	}
	
	public struct State {
		public StateType Type;
		public XmlNode Node;
		public int StartIndex;
		public string Name;
		public int Dashes;

		public State(StateType type) {
			Type = type;
			Node = null;
			StartIndex = 0;
			Name = null;
			Dashes = 0;
		}
		
		public static bool IsValidNamePart(char ch, int startIndex, int index) {
			if ( startIndex == index ) {
				return char.IsLetter(ch);
			}
			return char.IsLetterOrDigit(ch) || (ch == '_') || (ch == ':');
		}
		
		public static void UnrollToOpeningTag(string matchingClosingName, Stack<State> states) {
			while ( true ) {
				if ( states.Count == 0 ) {
					throw new XmlFormatException("Can't find matching opening tag");
				}
				var state = states.Pop();
				if ( state.Type == StateType.OpeningTag ) {
					if ( !string.IsNullOrEmpty(matchingClosingName) ) {
						if ( matchingClosingName != state.Node.Name ) {
							throw new XmlFormatException(
								string.Format("Invalid closing tag: '{0}', but '{1}' is expected", matchingClosingName, state.Node.Name)
							);
						}
					}
					return;
				}
			}
		}
		
		public static XmlNode GetLastNode(Stack<State> states) {
			foreach ( var state in states ) {
				if ( (state.Type == StateType.OpeningTag) && (state.Node != null) ) {
					return state.Node;
				}
			}
			return null;
		}
	}
}