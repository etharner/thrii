using System.Collections.Generic;

namespace thrii
{
	public class System
	{
		protected string nodeType;
		protected List<Node> targets;
		protected Engine engine;

		protected System(Engine e)
		{
			nodeType = "";
			targets = new List<Node>();
			engine = e;
		}

		protected void GetNodes()
		{
			targets = engine.GetNodeList(nodeType);
		}

		public virtual void Update() {}
	}
}
