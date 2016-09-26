using SFML.Graphics;

namespace thrii
{
	public class PositionComponent
	{
		public uint X;
		public uint Y;
	}

	public class DisplayComponent
	{
		public Transformable DisplayObject;
	}

	public class CollisionComponent
	{
		public FloatRect boundingBox;
	}
}
