using SFML.Graphics;

namespace thrii
{
	public class PositionComponent
	{
		public float X;
		public float Y;
		public float Rotation;
	}

	public class DisplayComponent
	{
		public Transformable DisplayObject;
	}

	public class AnimationComponent : PositionComponent {}

	public class CollisionComponent
	{
		public FloatRect BoundingBox;
	}

	public class InterfaceComponent
	{
		public string Text;
	}

	public class GemComponent
	{
		public Gem GemType;
	}
}
