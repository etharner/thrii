namespace thrii
{
	public class Node
	{
		public Entity Entity;
	}

	public class RenderNode : Node
	{
		public DisplayComponent Display;
		public PositionComponent Position;
	}
}
