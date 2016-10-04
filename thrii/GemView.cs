using SFML.Graphics;

namespace thrii
{
	public enum Gem
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
		public Gem GemType { get; set; }

		public GemView(Gem gemType, Layout layout)
		{
			uint cornerCount;
			Color color;

			GemType = gemType;

			switch (gemType)
			{
				case Gem.Romb:
					cornerCount = 4;
					color = Colors.RombGemColor;
					break;
				case Gem.Pentagon:
					cornerCount = 5;
					color = Colors.PentagonGemColor;
					break;
				case Gem.Hexagon:
					cornerCount = 6;
					color = Colors.HexagonGemColor;
					break;
				case Gem.Octagon:
					cornerCount = 8;
					color = Colors.OctagonGemColor;
					break;
				default:
					cornerCount = 0;
					color = Colors.CircleGemColor;
					break;
			}

			GemShape = cornerCount == 0 ? 
				new CircleShape(layout.GemSize - 3) : 
				new CircleShape(layout.GemSize - 3, cornerCount);
			GemShape.OutlineThickness = 3;
			GemShape.OutlineColor = Colors.GemOutlineColor;
			GemShape.FillColor = color;
		}
	}
}
