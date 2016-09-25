using System.Collections.Generic;

namespace thrii
{
	public class Node
	{
		public Entity Entity { get; set; }
	}

	public class RenderNode : Node
	{
		public DisplayComponent Display;
		public PositionComponent Position;
	}
}
