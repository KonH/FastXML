namespace Tests {
	public static class Cases {
		public const string SingleNode1      = "<root/>";
		public const string SingleNode2      = "<root />";
		public const string OpenCloseNode1   = "<root></root>";
		public const string OpenCloseNode2   = "<root>\n</root>";
		public const string NodeWithHeader   = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<root/>";
		public const string NodeWithComment1 = "<!-- comment -->\n<root/>";
		public const string NodeWithComment2 = "<!-- comment - <commented_tag /> -->\n<root/>";
		public const string NodeWithChilds1  = "<root><child/></root>";
		public const string NodeWithChilds2  = "<root><child/><child/></root>";
		public const string NodeWithChilds3  = "<root><child><subChild/></child></root>";
		public const string NodeWithAttr1    = "<root attribute=\"value\"/>";
		public const string NodeWithAttr2    = "<root attribute=\"\"/>";
	}
}