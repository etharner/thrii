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
	}

	public class CollisionNode : Node
	{
		public CollisionComponent Collision;
	}

	public class InterfaceNode : Node
	{
		public InterfaceComponent Interface;
	}
}
