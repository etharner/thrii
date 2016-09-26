using System.Collections.Generic;
using SFML.Graphics;

namespace thrii
{
	public static class Spawner
	{
		public static Entity CreateBackground(
			uint width, uint height, uint x, uint y, Color color, int outline = 0, 
			Color outlineColor = new Color(), Name name = null
		)
		{
			var background = new Entity(name == null ? Registrator.GenerateName(BaseNames.Background) : name);

			var bgDisplayComponent = new DisplayComponent();
			var bgShape = new RectangleShape(new SFML.System.Vector2f(width, height));
			bgShape.FillColor = color;
			if (outline > 0)
			{
				bgShape.OutlineThickness = outline;
				bgShape.OutlineColor = outlineColor;
			}
			bgDisplayComponent.DisplayObject = bgShape;

			var bgPositionComponent = new PositionComponent();
			bgPositionComponent.X = x;
			bgPositionComponent.Y = y;

			var bgCollisionComponent = new CollisionComponent();
			bgCollisionComponent.boundingBox = new FloatRect(x, y, width, height);

			background.AddComponent(bgDisplayComponent);
			background.AddComponent(bgPositionComponent);
			background.AddComponent(bgCollisionComponent);

			return background;
		}

		public static List<Entity> CreateTextFrame(
			uint width, uint height, uint x, uint y, uint textX, uint textY, string textString,
			Name bgName = null, Name textName = null
		)
		{
			var textFrame = new List<Entity>();

			var textEntity = new Entity(textName == null ? Registrator.GenerateName(BaseNames.Text) : textName);

			var tDisplayComponent = new DisplayComponent();
			var text = new Text(textString, new Font("helvetica.otf"));
			tDisplayComponent.DisplayObject = text;
			textEntity.AddComponent(tDisplayComponent);

			var tPositionComponent = new PositionComponent();
			tPositionComponent.X = textX;
			tPositionComponent.Y = textY;
			textEntity.AddComponent(tPositionComponent);

			textFrame.Add(CreateBackground(width, height, x, y, Color.Transparent, 2, Color.White, bgName));
			textFrame.Add(textEntity);

			return textFrame;
		}

		public static List<Entity> CreateMenuEntry(
			uint width, uint height, uint x, uint y, uint textX, uint textY, string textString
		)
		{
			return CreateTextFrame(
				width, height, x, y, textX, textY, textString, 
				Registrator.GenerateName(BaseNames.MenuNewGameBackground), 
				Registrator.GenerateName(BaseNames.MenuNewGameText)
			);
		}

	}
}
