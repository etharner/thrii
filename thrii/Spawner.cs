using System.Collections.Generic;
using SFML.Graphics;

namespace thrii
{
	public static class Spawner
	{
		public static Entity CreateGameSprite(Layout layout)
		{
			var sprite = new Entity(Registrator.GenerateName(BaseNames.GameSprite));

			var sDisplayComponent = new DisplayComponent();
			var sTexture = new Texture("gameSprite.png");

			var sSprite = new Sprite(sTexture);
			sSprite.Scale = new SFML.System.Vector2f(
				layout.GameSpriteWidth / sSprite.GetLocalBounds().Width, 
				layout.GameSpriteHeight / sSprite.GetLocalBounds().Height
			);
			sDisplayComponent.DisplayObject = sSprite;

			var sPositionComponent = new PositionComponent();
			sPositionComponent.X = layout.GameSpriteX;
			sPositionComponent.Y = layout.GameSpriteY;

			sprite.AddComponent(sDisplayComponent);
			sprite.AddComponent(sPositionComponent);

			return sprite;
		}

		public static Entity CreateBackground(
			Layout layout, uint width, uint height, uint x, uint y, 
			Color color, bool isGlobalBackground, int outline = 0, Color outlineColor = new Color(), 
			Name name = null
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

			background.AddComponent(bgDisplayComponent);
			background.AddComponent(bgPositionComponent);

			if (!isGlobalBackground)
			{
				var bgCollisionComponent = new CollisionComponent();
				bgCollisionComponent.BoundingBox = new FloatRect(x, y, width, height);
				background.AddComponent(bgCollisionComponent);
			}

			return background;
		}

		public static List<Entity> CreateTextFrame(
			Layout layout, uint width, uint height, uint x, uint y, 
			uint textX, uint textY, string textString,
			Name bgName = null, Name textName = null
		)
		{
			var textFrame = new List<Entity>();

			var textEntity = new Entity(textName == null ? Registrator.GenerateName(BaseNames.Text) : textName);

			var tDisplayComponent = new DisplayComponent();
			var text = new Text(textString, new Font("helvetica.otf"), layout.FontSize);
			tDisplayComponent.DisplayObject = text;
			textEntity.AddComponent(tDisplayComponent);

			var tPositionComponent = new PositionComponent();
			tPositionComponent.X = textX;
			tPositionComponent.Y = textY;
			textEntity.AddComponent(tPositionComponent);

			var tInterfaceComponent = new InterfaceComponent();
			tInterfaceComponent.Text = textString;
			textEntity.AddComponent(tInterfaceComponent);

			textFrame.Add(CreateBackground(layout, width, height, x, y, Color.Transparent, false, 3, Color.White, bgName));
			textFrame.Add(textEntity);

			return textFrame;
		}

		public static List<Entity> CreateMenuEntry(
			Layout layout,
			BaseNames entryName
		)
		{
			switch (entryName)
			{
				case BaseNames.MenuNewGame:
					return CreateTextFrame(
						layout,
						layout.MenuEntryWidth, layout.MenuEntryHeight, 
						layout.MenuNewGameX, layout.MenuNewGameY, 
						layout.MenuNewGameTextX, layout.MenuNewGameTextY, "New Game", 
						Registrator.GenerateName(BaseNames.MenuNewGameBackground), 
						Registrator.GenerateName(BaseNames.MenuNewGameText)
					);
				case BaseNames.MenuSettings:
					return CreateTextFrame(
						layout,
						layout.MenuEntryWidth, layout.MenuEntryHeight, 
						layout.MenuSettingsX, layout.MenuSettingsY, 
						layout.MenuSettingsTextX, layout.MenuSettingsTextY, "Settings", 
						Registrator.GenerateName(BaseNames.MenuSettingsBackground), 
						Registrator.GenerateName(BaseNames.MenuSettingsText)
					);
				case BaseNames.MenuApply:
					return CreateTextFrame(
						layout,
						layout.MenuEntryWidth, layout.MenuEntryHeight, 
						layout.MenuApplyX, layout.MenuApplyY, 
						layout.MenuApplyTextX, layout.MenuApplyTextY, "Apply", 
						Registrator.GenerateName(BaseNames.MenuApplyBackground), 
						Registrator.GenerateName(BaseNames.MenuApplyText)
					);
				case BaseNames.MenuBack:
					return CreateTextFrame(
						layout,
						layout.MenuEntryWidth, layout.MenuEntryHeight, 
						layout.MenuBackX, layout.MenuBackY, 
						layout.MenuBackTextX, layout.MenuBackTextY, "Back", 
						Registrator.GenerateName(BaseNames.MenuBackBackground), 
						Registrator.GenerateName(BaseNames.MenuBackText)
					);
				case BaseNames.MenuExitToMenu:
					return CreateTextFrame(
						layout,
						layout.MenuEntryWidth, layout.MenuEntryHeight, 
						layout.MenuSettingsX, layout.MenuSettingsY, 
						layout.MenuExitToMenuTextX, layout.MenuExitToMenuTextY, "Exit to Menu", 
						Registrator.GenerateName(BaseNames.MenuExitToMenuBackground), 
						Registrator.GenerateName(BaseNames.MenuExitToMenuText)
					);
				default:
					return CreateTextFrame(
						layout,
						layout.MenuEntryWidth, layout.MenuEntryHeight, 
						layout.MenuExitX, layout.MenuExitY, 
						layout.MenuExitTextX, layout.MenuExitTextY, "Exit", 
						Registrator.GenerateName(BaseNames.MenuExitBackground), 
						Registrator.GenerateName(BaseNames.MenuExitText)
					);	
			}
		}

		public static List<Entity> CreateChooseFrame(
			Layout layout, 
			uint width, uint height, uint x, uint y, uint textX, uint textY, string textString,
			uint labelX, uint labelY, string labelText,
			uint leftX, uint leftY, uint rightX, uint rightY,
			Name bgName = null, Name textName = null, 
			Name leftName = null, Name rightName = null
		)
		{
			var chooseFrame = new List<Entity>();

			var textLabel = new Entity(Registrator.GenerateName(BaseNames.Text));

			var tlDisplayComponent = new DisplayComponent();
			var tlText = new Text(labelText, new Font("helvetica.otf"), layout.FontSize);
			tlDisplayComponent.DisplayObject = tlText;

			var tlPositionComponent = new PositionComponent();
			tlPositionComponent.X = labelX;
			tlPositionComponent.Y = labelY;

			textLabel.AddComponent(tlDisplayComponent);
			textLabel.AddComponent(tlPositionComponent);

			var textFrame = CreateTextFrame(layout, width, height, x, y, textX, textY, textString, bgName, textName);

			var optionLeftButton = new Entity(leftName);

			var lDisplayComponent = new DisplayComponent();
			var lShape = new CircleShape(layout.OptionEntryButtonSize, 3);
			lShape.Origin = new SFML.System.Vector2f(
				lShape.GetLocalBounds().Width / 2,
				lShape.GetLocalBounds().Height / 2
			);
			lDisplayComponent.DisplayObject = lShape;

			var lPositionComponent = new PositionComponent();
			lPositionComponent.X = leftX;
			lPositionComponent.Y = leftY;
			lPositionComponent.Rotation = -90;

			var lCollisionComponent = new CollisionComponent();
			lCollisionComponent.BoundingBox = new FloatRect(
				leftX, leftY, layout.OptionEntryButtonSize, layout.OptionEntryButtonSize
			);

			optionLeftButton.AddComponent(lDisplayComponent);
			optionLeftButton.AddComponent(lPositionComponent);
			optionLeftButton.AddComponent(lCollisionComponent);

			var optionRightButton = new Entity(rightName);

			var rDisplayComponent = new DisplayComponent();
			var rShape = new CircleShape(layout.OptionEntryButtonSize, 3);
			rShape.Origin = new SFML.System.Vector2f(
				rShape.GetLocalBounds().Width / 2,
				rShape.GetLocalBounds().Height / 2
			);
			rDisplayComponent.DisplayObject = rShape;

			var rPositionComponent = new PositionComponent();
			rPositionComponent.X = rightX;
			rPositionComponent.Y = rightY;
			rPositionComponent.Rotation = 90;

			var rCollisionComponent = new CollisionComponent();
			rCollisionComponent.BoundingBox = new FloatRect(
				rightX, rightY, layout.OptionEntryButtonSize, layout.OptionEntryButtonSize
			);

			optionRightButton.AddComponent(rDisplayComponent);
			optionRightButton.AddComponent(rPositionComponent);
			optionRightButton.AddComponent(rCollisionComponent);

			chooseFrame.Add(textLabel);
			chooseFrame.Add(optionLeftButton);
			chooseFrame.Add(optionRightButton);
			chooseFrame.AddRange(textFrame);

			return chooseFrame;
		}

		public static List<Entity> CreateOptionEntry(
			Layout layout,
			BaseNames optionName
		)
		{
			switch (optionName){
				case BaseNames.MenuOptionResolution:
					return CreateChooseFrame(
						layout,
						layout.OptionEntryWidth, layout.OptionEntryHeight, 
						layout.OptionResolutionX, layout.OptionResolutionY, 
						layout.OptionResolutionTextX, layout.OptionResolutionTextY, 
						Settings.Width + "x" + Settings.Height,
						layout.OptionResolutionLabelX, layout.OptionResolutionLabelY, "Resolution",
						layout.OptionResolutionLeftButtonX, layout.OptionResolutionLeftButtonY,
						layout.OptionResolutionRightButtonX, layout.OptionResolutionRightButtonY,
						Registrator.GenerateName(BaseNames.MenuOptionResolutionBackground), 
						Registrator.GenerateName(BaseNames.MenuOptionResolutionText),
						Registrator.GenerateName(BaseNames.MenuOptionResolutionLeftButton), 
						Registrator.GenerateName(BaseNames.MenuOptionResolutionRightButton)
					);
				default:
					return CreateChooseFrame(
						layout,
						layout.OptionEntryWidth, layout.OptionEntryHeight, 
						layout.OptionGameSizeX, layout.OptionGameSizeY, 
						layout.OptionGameSizeTextX, layout.OptionGameSizeTextY, 
						Settings.GameSize.ToString(),
						layout.OptionGameSizeLabelX, layout.OptionGameSizeLabelY, "Game Size",
						layout.OptionGameSizeLeftButtonX, layout.OptionGameSizeLeftButtonY,
						layout.OptionGameSizeRightButtonX, layout.OptionGameSizeRightButtonY,
						Registrator.GenerateName(BaseNames.MenuOptionGameSizeBackground), 
						Registrator.GenerateName(BaseNames.MenuOptionGameSizeText),
						Registrator.GenerateName(BaseNames.MenuOptionGameSizeLeftButton), 
						Registrator.GenerateName(BaseNames.MenuOptionGameSizeRightButton)
					);	
			}
		}

		public static List<Entity> CreateHudFrame(
			Layout layout, 
			uint width, uint height, uint x, uint y, uint textX, uint textY, string textString,
			uint labelX, uint labelY, string labelText,
			Name bgName = null, Name textName = null
		)
		{
			var hudFrame = new List<Entity>();

			var textLabel = new Entity(Registrator.GenerateName(BaseNames.Text));

			var tlDisplayComponent = new DisplayComponent();
			var tlText = new Text(labelText, new Font("helvetica.otf"), layout.FontSize);
			tlDisplayComponent.DisplayObject = tlText;

			var tlPositionComponent = new PositionComponent();
			tlPositionComponent.X = labelX;
			tlPositionComponent.Y = labelY;

			textLabel.AddComponent(tlDisplayComponent);
			textLabel.AddComponent(tlPositionComponent);

			var textFrame = CreateTextFrame(
				layout, width, height, x, y, textX, textY, textString, bgName, textName
			);

			hudFrame.Add(textLabel);
			hudFrame.AddRange(textFrame);

			return hudFrame;
		}

		public static List<Entity> CreateHud(
			Layout layout,
			BaseNames hudName
		)
		{
			switch (hudName) {
				case BaseNames.HudTime:
					return CreateHudFrame(
						layout,
						layout.HudTimeWidth,
						layout.HudTimeHeight,
						layout.HudTimeX,
						layout.HudTimeY,
						layout.HudTimeTextX,
						layout.HudTimeTextY,
						"60",
						layout.HudTimeLabelX,
						layout.HudTimeLabelY,
						"Time",
						Registrator.GenerateName(BaseNames.Background),
						Registrator.GenerateName(BaseNames.HudTimeText)
					);
				default:
					return CreateHudFrame(
						layout,
						layout.HudScoreWidth,
						layout.HudScoreHeight,
						layout.HudScoreX,
						layout.HudScoreY,
						layout.HudScoreTextX,
						layout.HudScoreTextY,
						"0",
						layout.HudScoreLabelX,
						layout.HudScoreLabelY,
						"Score",
						Registrator.GenerateName(BaseNames.Background),
						Registrator.GenerateName(BaseNames.HudScoreText)
					);
			}
		}

		public static Entity CreateLabel(
			Layout layout, uint x, uint y, string text, BaseNames baseName 
		)
		{
			var label = new Entity(Registrator.GenerateName(baseName));

			var lDisplayComponent = new DisplayComponent();
			lDisplayComponent.DisplayObject = new Text(text, new Font("helvetica.otf"), layout.FontSize);

			var lPositionComponent = new PositionComponent();
			lPositionComponent.X = x;
			lPositionComponent.Y = y;

			var lInterfaceComponent = new InterfaceComponent();
			lInterfaceComponent.Text = text;

			label.AddComponent(lDisplayComponent);
			label.AddComponent(lPositionComponent);
			label.AddComponent(lInterfaceComponent);

			return label;
		}

		public static Entity CreateGem(
			Layout layout, Shape gem, uint x, uint y
		)
		{
			var gemEntity = new Entity(Registrator.GenerateName(BaseNames.Gem));

			var gDisplayComponent = new DisplayComponent();
			gem.Origin = new SFML.System.Vector2f(
				gem.GetLocalBounds().Width / 2.0f,
				gem.GetLocalBounds().Height / 2.0f
			);
			gDisplayComponent.DisplayObject = gem;

			var gPositionComponent = new PositionComponent();
			gPositionComponent.X = x;
			gPositionComponent.Y = y;

			var gCollisionComponent = new CollisionComponent();
			gCollisionComponent.BoundingBox = new FloatRect(x ,y, layout.GemSize, layout.GemSize);

			var lAnimationComponent = new AnimationComponent();
			lAnimationComponent.X = x;
			lAnimationComponent.Y = y;

			gemEntity.AddComponent(gDisplayComponent);
			gemEntity.AddComponent(gPositionComponent);
			gemEntity.AddComponent(gCollisionComponent);
			gemEntity.AddComponent(lAnimationComponent);

			return gemEntity;
		}

	}
}
