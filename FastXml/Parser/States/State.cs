using System.Collections.Generic;

namespace FastXml.Parser.States {
	public abstract class State {
		public abstract void Parse(string str, int index, char ch, Stack<State> states, XmlDocument doc);

		protected void CreateNodeFromStates(string closingName, Stack<State> states, XmlDocument doc) {
			states.Pop();
			var openTagNameState = states.Pop() as OpenTagNameState;
			if ( openTagNameState != null ) {
				if ( !string.IsNullOrEmpty(closingName) ) {
					if ( openTagNameState.Name != closingName ) {
						throw new XmlFormatException(string.Format("Invalid closing tag: '{0}', but '{1}' is expected", closingName, openTagNameState.Name));
					}
				}
				doc.Nodes.Add(new XmlNode(openTagNameState.Name));
			} else {
				throw new XmlFormatException("No open tag for closing tag");
			}
		}
	}
}