using System.Collections.Generic;

namespace FastXml.Parser.States {
	class AttributeValue : State {			
		int _startIndex;
			
		public AttributeValue(int startIndex) {
			_startIndex = startIndex;
		}
			
		public override void Parse(string str, int index, char ch, Stack<State> states, XmlDocument doc) {
			if ( ch == '"' ) {
				states.Pop();
				var attrName = states.Pop() as AttributeName;
				if ( attrName != null ) {
					var name = attrName.Name;
					var value = str.Substring(_startIndex, index - _startIndex);
					var node = GetLastNode(states);
					node.Attributes.Add(name, value);
				} else {
					throw new XmlFormatException("No matching attribute name");
				}
			}
		}
	}
}