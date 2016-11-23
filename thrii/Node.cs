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

	public class MovementNode : Node
	{
		public PositionComponent Position;
	}

	public class AnimationNode : Node
	{
		public AnimationComponent Animation;
		public PositionComponent Position;
		public DisplayComponent Display;
	}

	public class CollisionNode : Node
	{
		public CollisionComponent Collision;
	}

	public class InterfaceNode : Node
	{
		public InterfaceComponent Interface;
	}

	public class GemNode : Node
	{
		public DisplayComponent Display;
		public PositionComponent Position;
		public AnimationComponent Animation;
		public GemComponent Gem;
	}
}
