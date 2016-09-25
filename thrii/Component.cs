using SFML.Graphics;

namespace thrii
{
	public class Component
	{
		public Component()
		{
		}
	}

	public class PositionComponent : Component
	{
		public int X { get; set; }
		public int Y { get; set; }
	}

	public class DisplayComponent : Component
	{
		public Transformable DisplayObject { get; set; }
	}
}
