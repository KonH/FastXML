using System.Collections.Generic;

namespace FastXml.Parser.States {
	class OpeningTag : State {			
		int _startIndex;
			
		public XmlNode Node { get; private set; }
			
		public OpeningTag(int startIndex) {
			_startIndex = startIndex;
		}
			
		public override void Parse(string str, int index, char ch, Stack<State> states, XmlDocument doc) {
			if ( ch == '/' ) {
				CreateNode(str, index, states, doc);
				states.Push(new EmbeddedClosingTag());
			} else if ( ch == '>') {
				CreateNode(str, index, states, doc);
				states.Push(new InsideTag());
			} else if ( char.IsWhiteSpace(ch) ) {
				CreateNode(str, index, states, doc);
				states.Push(new TagBody());
			} else if ( !IsValidNamePart(ch, _startIndex, index) ) {
				throw new XmlFormatException(string.Format("Unexpected character in tag name: '{0}'", ch));
			}
		}
		
		List<XmlNode> GetLastContainer(Stack<State> states, XmlDocument doc) {
			var lastNode = GetLastNode(states);
			return (lastNode != null) ? lastNode.Nodes : doc.Nodes;
		}
		
		void CreateNode(string str, int index, Stack<State> states, XmlDocument doc) {
			var name = str.Substring(_startIndex, index - _startIndex);
			Node = new XmlNode(name);
			var container = GetLastContainer(states, doc);
			container.Add(Node);
		}
	}
}