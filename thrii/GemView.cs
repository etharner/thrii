using SFML.Graphics;

namespace thrii
{
	public enum Gems
	{
		Circle,
		Romb,
		Pentagon,
		Hexagon,
		Octagon
	}

	public class GemView
	{
		public Shape GemShape { get; set; }

		public GemView(Gems gemType)
		{
			uint cornerCount;
			Color color;

			switch (gemType)
			{
				case Gems.Romb:
					cornerCount = 4;
					color = Colors.RombGemColor;
					break;
				case Gems.Pentagon:
					cornerCount = 5;
					color = Colors.PentagonGemColor;
					break;
				case Gems.Hexagon:
					cornerCount = 6;
					color = Colors.HexagonGemColor;
					break;
				case Gems.Octagon:
					cornerCount = 8;
					color = Colors.OctagonGemColor;
					break;
				default:
					cornerCount = 0;
					color = Colors.CircleGemColor;
					break;
			}


			GemShape = cornerCount == 0 ? new CircleShape(Layout.GemSize) : new CircleShape(Layout.GemSize, cornerCount);
			GemShape.FillColor = color;
		}
	}
}
