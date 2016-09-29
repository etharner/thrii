using SFML.Graphics;

namespace thrii
{
	public class PositionComponent
	{
		public uint X;
		public uint Y;
		public float Rotation;
	}

	public class DisplayComponent
	{
		public Transformable DisplayObject;
	}

	public class CollisionComponent
	{
		public FloatRect BoundingBox;
	}

	public class InterfaceComponent
	{
		public string Text;
	}
}
