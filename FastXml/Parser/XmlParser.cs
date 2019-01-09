using System.Linq;
using System.Collections.Generic;

namespace FastXml.Parser {
	public static class XmlParser {				
		public static XmlDocument Parse(string xml) {
			var doc = new XmlDocument();
			var states = new Stack<State>();
			states.Push(new State(StateType.Document));
			for ( var i = 0; i < xml.Length; i++ ) {
				var ch = xml[i];
				var @this = states.Peek();
				switch ( @this.Type ) {
					case StateType.AttributeEquals: {
						if ( ch == '=' ) {
							states.Pop();
							states.Push(new State(StateType.AttributeStartingQuote) { Name = @this.Name});
						} else if ( !char.IsWhiteSpace(ch) ) {
							throw new XmlFormatException(
								string.Format("Unexpected non-whitespace character in attribute declaration: '{0}'", ch)
							);
						}
					}
					break;

					case StateType.AttributeName: {
						if ( char.IsWhiteSpace(ch) ) {
							states.Pop();
							states.Push(new State(StateType.AttributeEquals) {
								Name = xml.Substring(@this.StartIndex, i - @this.StartIndex)
							});
						} else if ( ch == '=' ) {
							states.Pop();
							states.Push(new State(StateType.AttributeStartingQuote) {
								Name = xml.Substring(@this.StartIndex, i - @this.StartIndex)
							});
						}  else if ( !State.IsValidNamePart(ch, states.Peek().StartIndex, i) ) {
							throw new XmlFormatException(string.Format("Unexpected character in attribute name: '{0}'", ch));
						}
					}
					break;
					
					case StateType.AttributeStartingQuote: {
						if ( ch == '"' ) {
							states.Pop();
							states.Push(new State(StateType.AttributeValue) { StartIndex = i + 1, Name = @this.Name });
						} else if ( !char.IsWhiteSpace(ch) ) {
							throw new XmlFormatException(
								string.Format("Unexpected non-whitespace character in attribute declaration: '{0}'", ch)
							);
						}
					}
					break;
					
					case StateType.AttributeValue: {
						if ( ch == '"' ) {
							states.Pop();
							var name  = @this.Name;
							var value = xml.Substring(@this.StartIndex, i - @this.StartIndex);
							var node  = State.GetLastNode(states);
							node.Attributes.Add(name, value);
						}
					}
					break;
					
					case StateType.ClosingTag: {
						if ( ch == '>' ) {
							var closingName = xml.Substring(@this.StartIndex, i - @this.StartIndex);
							State.UnrollToOpeningTag(closingName, states);
						} else if ( !State.IsValidNamePart(ch, @this.StartIndex, i) ) {
							throw new XmlFormatException(string.Format("Unexpected character in closing tag name: '{0}'", ch));
						}
					}
					break;
					
					case StateType.Comment: {
						if ( i < (@this.StartIndex + 2) ) {
							continue;
						}
						if ( @this.Dashes == 2 ) {
							if ( ch == '>' ) {
								states.Pop();
							} else {
								throw new XmlFormatException(string.Format("Unexpected character inside comment: '{0}' instead of '>'", ch));
							}
						} else if ( ch == '-' ) {
							@this.Dashes++;
							states.Pop();
							states.Push(@this);
						} else {
							@this.Dashes = 0;
							states.Pop();
							states.Push(@this);
						}
					}
					break;
					
					case StateType.Document: {
						if ( ch == '<' ) {
							states.Push(new State(StateType.TagSelector));
						} else if ( !char.IsWhiteSpace(ch) ) {
							throw new XmlFormatException("Unexpected non-whitespace character in document");
						}
					}
					break;
					
					case StateType.EmbeddedClosingTag: {
						if ( ch == '>' ) {
							State.UnrollToOpeningTag(string.Empty, states);
						} else if ( !char.IsLetterOrDigit(ch) ) {
							throw new XmlFormatException("Unexpected character in tag");
						}
					}
					break;
					
					case StateType.InsideTag: {
						if ( ch == '<' ) {
							states.Push(new State(StateType.TagSelector));
						} else if ( !char.IsWhiteSpace(ch) ) {
							throw new XmlFormatException("Unexpected non-whitespace character inside tag");
						}
					}
					break;
					
					case StateType.OpeningTag: {
						if ( ch == '/' ) {
							AddNode(@this, xml, i, states, doc);
							states.Push(new State(StateType.EmbeddedClosingTag));
						} else if ( ch == '>') {
							AddNode(@this, xml, i, states, doc);
							states.Push(new State(StateType.InsideTag));
						} else if ( char.IsWhiteSpace(ch) ) {
							AddNode(@this, xml, i, states, doc);
							states.Push(new State(StateType.TagBody));
						} else if ( !State.IsValidNamePart(ch, @this.StartIndex, i) ) {
							throw new XmlFormatException(string.Format("Unexpected character in tag name: '{0}'", ch));
						}
					}
					break;
					
					case StateType.SkipToClosingTag: {
						if ( ch == '>' ) {
							states.Pop();
						}
					}
					break;
					
					case StateType.TagBody: {
						if ( ch == '>' ) {
							states.Push(new State(StateType.InsideTag));
						} else if ( ch == '/' ) {
							states.Pop();
							states.Push(new State(StateType.EmbeddedClosingTag));
						} else if ( !char.IsWhiteSpace(ch) ) {
							states.Push(new State(StateType.AttributeName) { StartIndex = i });
						}
					}
					break;
					
					case StateType.TagSelector: {
						if ( ch == '!' ) {
							states.Pop();
							states.Push(new State(StateType.Comment) { StartIndex = i });
						} else if ( ch == '?' ) {
							states.Pop();
							states.Push(new State(StateType.SkipToClosingTag));
						} else if ( ch == '/' ) {
							states.Pop();
							states.Push(new State(StateType.ClosingTag) { StartIndex = i + 1 });
						} else if ( char.IsLetter(ch) ) {
							states.Pop();
							states.Push(new State(StateType.OpeningTag) { StartIndex = i });
						} else {
							throw new XmlFormatException(string.Format("Unexpected character after '<': '{0}'", ch));
						}
					}
					break;
				}
				#if DEBUG
					System.Console.WriteLine(
						"'{0}' => {1}", 
						xml[i], string.Join("; ", states.Select(s => s.GetType().Name).Reverse())
					);
				#endif
			}
			if ( states.Peek().Type == StateType.Document ) {
				return doc;
			} else {
				throw new XmlFormatException("Invalid Xml document");
			}
		}
		
		static void AddNode(State @this, string str, int index, Stack<State> states, XmlDocument doc) {
			var name = str.Substring(@this.StartIndex, index - @this.StartIndex);
			@this.Node = new XmlNode(name);
			List<XmlNode> container = null;
			var           lastNode  = State.GetLastNode(states);
			if ( lastNode != null ) {
				container = lastNode.Nodes;
			} else {
				container = doc.Nodes;
			}
			container.Add(@this.Node);
			states.Pop();
			states.Push(@this);
		}
	}
}