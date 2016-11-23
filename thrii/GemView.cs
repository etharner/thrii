using SFML.Graphics;

namespace thrii
{
	public enum Gem
	{
		Circle,
		Romb,
		Pentagon,
		Hexagon,
		Octagon,
		Bomb
	}

	public enum GemSub
	{
		Gem,
		Line,
		Bomb
	}

	public class GemView
	{
		public Shape GemShape { get; set; }
		public Gem GemType { get; set; }
		public GemSub GemSubType { get; set; }

		public GemView(Gem gemType, GemSub subType = GemSub.Gem)
		{
			uint cornerCount;
			Color color;
			Texture texture;

			GemType = gemType;
			GemSubType = subType;
			 
			switch (gemType)
			{
				case Gem.Romb:
					cornerCount = 4;
					color = Colors.RombGemColor;
					texture = subType == GemSub.Line ? 
					                           new Texture(Assets.RombLine) : 
											   new Texture(Assets.RombBomb);
					break;
				case Gem.Pentagon:
					cornerCount = 5;
					color = Colors.PentagonGemColor;
					texture = subType == GemSub.Line ?
											   new Texture(Assets.PentagonLine) :
											   new Texture(Assets.PentagonBomb);
					break;
				case Gem.Hexagon:
					cornerCount = 6;
					color = Colors.HexagonGemColor;
					texture = subType == GemSub.Line ?
											   new Texture(Assets.HexagonLine) :
											   new Texture(Assets.HexagonBomb);
					break;
				case Gem.Octagon:
					cornerCount = 8;
					color = Colors.OctagonGemColor;
					texture = subType == GemSub.Line ?
											   new Texture(Assets.OctagonLine) :
											   new Texture(Assets.OctagonBomb);
					break;
				default:
					cornerCount = 0;
					color = Colors.CircleGemColor;
					texture = subType == GemSub.Line ?
											   new Texture(Assets.CircleLine) :
											   new Texture(Assets.CircleBomb);
					break;
			}

			if (subType == GemSub.Gem)
			{
				GemShape = cornerCount == 0 ? 
					new CircleShape(Layout.GemSize - 3) : 
					new CircleShape(Layout.GemSize - 3, cornerCount);
				GemShape.OutlineThickness = 3;
				GemShape.OutlineColor = Colors.GemOutlineColor;
				GemShape.FillColor = color;
			}
			else {
				GemShape = new RectangleShape(new SFML.System.Vector2f(Layout.BombSize, Layout.BombSize));
				GemShape.Texture = texture;
			}
		}
	}

	public class DestroyerView
	{
		public Shape DestroyerShape { get; set; }
		public Gem GemType { get; set; }

		public DestroyerView(Gem gemType)
		{
			Texture texture;

			GemType = gemType;

			switch (gemType)
			{
				case Gem.Romb:
					texture = new Texture(Assets.RombDestroyer);
					break;
				case Gem.Pentagon:
					texture = new Texture(Assets.PentagonDestroyer);
					break;
				case Gem.Hexagon:
					texture = new Texture(Assets.HexagonDestroyer);
					break;
				case Gem.Octagon:
					texture = new Texture(Assets.OctagonDestroyer);
					break;
				default:
					texture = new Texture(Assets.CircleDestroyer);
					break;
			}

			DestroyerShape = new RectangleShape(
				new SFML.System.Vector2f((Layout.GemSize - 3) * 2, 
				                         (Layout.GemSize - 3) * 2)
			);
			DestroyerShape.Texture = texture;
		}
	}

}
