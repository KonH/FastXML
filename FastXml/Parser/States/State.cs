using System.Collections.Generic;

namespace FastXml.Parser.States {
	public abstract class State {
		public abstract void Parse(string str, int index, char ch, Stack<State> states, XmlDocument doc);

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
	}
}