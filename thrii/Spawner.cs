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
			var text = new Text(textString, new Font("helvetica.otf"), Settings.Height / 20);
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
			BaseNames entryName
		)
		{
			switch (entryName)
			{
				case BaseNames.MenuNewGame:
					return CreateTextFrame(
						Layout.MenuEntryWidth, Layout.MenuEntryHeight, 
						Layout.MenuNewGameX, Layout.MenuNewGameY, 
						Layout.MenuNewGameTextX, Layout.MenuNewGameTextY, "New Game", 
						Registrator.GenerateName(BaseNames.MenuNewGameBackground), 
						Registrator.GenerateName(BaseNames.MenuNewGameText)
					);
				default:
					return CreateTextFrame(
						Layout.MenuEntryWidth, Layout.MenuEntryHeight, 
						Layout.MenuSettingsX, Layout.MenuSettingsY, 
						Layout.MenuSettingsTextX, Layout.MenuSettingsTextY, "Settings", 
						Registrator.GenerateName(BaseNames.MenuSettingsBackground), 
						Registrator.GenerateName(BaseNames.MenuSettingsText)
					);	
			}
		}

		public static List<Entity> CreateOptionEntry(
			BaseNames optionBack
		)

		public static Entity CreateGem(
			Shape gem, uint x, uint y
		)
		{
			var gemEntity = new Entity(Registrator.GenerateName(BaseNames.Gem));

			var gDisplayComponent = new DisplayComponent();
			gDisplayComponent.DisplayObject = gem;

			var gPositionComponent = new PositionComponent();
			gPositionComponent.X = x;
			gPositionComponent.Y = y;

			gemEntity.AddComponent(gDisplayComponent);
			gemEntity.AddComponent(gPositionComponent);

			return gemEntity;
		}

	}
}
