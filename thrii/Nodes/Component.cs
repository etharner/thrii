using SFML.Graphics;
using SFML.System;

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

	public class AnimationComponent : PositionComponent {
		public float Speed;
		public Vector2f Scale;
	}

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
		public GemSub GemSubType;
	}
}
