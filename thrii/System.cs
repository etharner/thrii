using System.Collections.Generic;

namespace thrii
{
	public class System
	{
		readonly string NodeType;
		List<Node> targets;
		Engine engine;

		protected void GetNodes()
		{
			engine.GetNodeList(NodeType);
		}

		public void Update() {}
	}
}
