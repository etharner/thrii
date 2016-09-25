using SFML.Graphics;

namespace thrii
{
	public class PositionComponent
	{
		public uint X { get; set; }
		public uint Y { get; set; }
	}

	public class DisplayComponent
	{
		public Transformable DisplayObject { get; set; }
	}
}
