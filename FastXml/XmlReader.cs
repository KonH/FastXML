namespace FastXml {
	public static class XmlReader {
		public static XmlDocument FromText(string xml) {
			var cursor = 0;
			while ( true ) {
				// Looking for <
				if ( xml[cursor] == '<' ) {
					var root = TryParseNode(xml, ref cursor);
					if ( root != null ) {
						return XmlDocument.FromRoot(root);
					}
				}
				cursor++;
			}
		}
		
		static XmlNode TryParseNode(string xml, ref int cursor) {
			cursor++; // <_
			var charAtCursor = xml[cursor];
			// Skipping <? and <! nodes
			if ( (charAtCursor == '?') || (charAtCursor == '!') ) {
				while ( xml[cursor] != '>' ) {
					cursor++;
				}
				return null;
			}
			// Skipping close tags
			if ( charAtCursor == '/' ) {
				return null;
			}
			XmlNode node = null;
			var nameStart = cursor;
			while ( true ) {
				charAtCursor = xml[cursor];
				if ( char.IsWhiteSpace(charAtCursor) ) {
					if ( node == null ) {
						// <node_
						node = CreateNode(xml.Substring(nameStart, cursor - nameStart));
					}
					cursor++;
					charAtCursor = xml[cursor];
					if ( (charAtCursor != '/') && (charAtCursor != '<') ) {
						string attrName, attrValue;
						ParseAttribute(xml, ref cursor, out attrName, out attrValue);
						node.Attributes.Add(attrName, attrValue);
					}
					continue;
				}
				if ( charAtCursor == '>' ) {
					if ( node == null ) {
						// <node>_
						node = CreateNode(xml.Substring(nameStart, cursor - nameStart));
					}
					cursor++;
					continue;
				}
				if ( charAtCursor == '<' ) {
					if ( node != null ) {
						var subNode = TryParseNode(xml, ref cursor);
						if ( subNode != null ) {
							node.Childs.Add(subNode);
							continue;
						}
					}
					cursor++; // </_
					var closeNameStart = cursor;
					while ( xml[cursor] != '>' ) {
						cursor++;
					}
					if ( node == null ) {
						throw new XmlFormatException("Closing tag without open tag");
					}
					if ( !CompareStringWithSubstring(node.Name, xml, closeNameStart, cursor - closeNameStart) ) {
						throw new XmlFormatException("Closing tag does not match open tag");
					}
					cursor++;
					return node;
				}
				if ( charAtCursor == '/' ) {
					cursor++;
					if ( xml[cursor] != '>' ) {
						throw new XmlFormatException("Unexpected token #3");
					}
					// <node />_
					if ( node == null ) {
						node = CreateNode(xml.Substring(nameStart, cursor - nameStart - 1));
					}
					return node;
				}
				cursor++;
			}
		}

		static XmlNode CreateNode(string name) {
			return new XmlNode(name);
		}
		
		static void ParseAttribute(string xml, ref int cursor, out string name, out string value) {
			var nameStart = cursor;
			char charAtCursor;
			while ( true ) {
				charAtCursor = xml[cursor];
				if ( char.IsWhiteSpace(charAtCursor) || (charAtCursor == '=') ) {
					name = xml.Substring(nameStart, cursor - nameStart);
					while ( xml[cursor] != '=' ) {
						cursor++;
					}
					break;
				}
				cursor++;
			}
			char valueBrace;
			while ( true ) {
				charAtCursor = xml[cursor];
				if ( (charAtCursor == '"') || (charAtCursor == '\'') ) {
					valueBrace = xml[cursor];
					cursor++;
					break;
				}
				cursor++;
			}
			var valueStart = cursor;
			while ( true ) {
				if ( xml[cursor] == valueBrace ) {
					value = xml.Substring(valueStart, cursor - valueStart);
					return;
				}
				cursor++;
			}
		}

		static bool CompareStringWithSubstring(string str, string strForSubString, int startIndex, int length) {
			if ( str.Length != length ) {
			    return false;
			}

			for ( var i = 0; i < length; i++ ) {
				if ( str[i] != strForSubString[startIndex + i] ) {
					return false;
				}
			}
			return true;
		}
	}
}