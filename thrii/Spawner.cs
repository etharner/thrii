using System.Collections.Generic;
using SFML.Graphics;

namespace thrii
{
	public static class Spawner
	{
		public static Entity CreateGameSprite()
		{
			var sprite = new Entity(Registrator.GenerateName(BaseNames.GameSprite));

			var sDisplayComponent = new DisplayComponent();
			var sTexture = new Texture(Assets.GameLogo);

			var sSprite = new Sprite(sTexture);
			sSprite.Scale = new SFML.System.Vector2f(
				Layout.GameSpriteWidth / sSprite.GetLocalBounds().Width, 
				Layout.GameSpriteHeight / sSprite.GetLocalBounds().Height
			);
			sDisplayComponent.DisplayObject = sSprite;

			var sPositionComponent = new PositionComponent();
			sPositionComponent.X = Layout.GameSpriteX;
			sPositionComponent.Y = Layout.GameSpriteY;

			sprite.AddComponent(sDisplayComponent);
			sprite.AddComponent(sPositionComponent);

			return sprite;
		}

		public static Entity CreateBackground(
			int width, int height, int x, int y, 
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
			int width, int height, int x, int y, 
			int textX, int textY, string textString,
			Name bgName = null, Name textName = null
		)
		{
			var textFrame = new List<Entity>();

			var textEntity = new Entity(textName == null ? Registrator.GenerateName(BaseNames.Text) : textName);

			var tDisplayComponent = new DisplayComponent();
			var text = new Text(textString, new Font(Assets.Font), (uint)Layout.FontSize);
			tDisplayComponent.DisplayObject = text;
			textEntity.AddComponent(tDisplayComponent);

			var tPositionComponent = new PositionComponent();
			tPositionComponent.X = textX;
			tPositionComponent.Y = textY;
			textEntity.AddComponent(tPositionComponent);

			var tInterfaceComponent = new InterfaceComponent();
			tInterfaceComponent.Text = textString;
			textEntity.AddComponent(tInterfaceComponent);

			textFrame.Add(CreateBackground(width, height, x, y, Color.Transparent, false, 3, Color.White, bgName));
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
				case BaseNames.MenuSettings:
					return CreateTextFrame(
						Layout.MenuEntryWidth, Layout.MenuEntryHeight, 
						Layout.MenuSettingsX, Layout.MenuSettingsY, 
						Layout.MenuSettingsTextX, Layout.MenuSettingsTextY, "Settings", 
						Registrator.GenerateName(BaseNames.MenuSettingsBackground), 
						Registrator.GenerateName(BaseNames.MenuSettingsText)
					);
				case BaseNames.MenuApply:
					return CreateTextFrame(
						Layout.MenuEntryWidth, Layout.MenuEntryHeight, 
						Layout.MenuApplyX, Layout.MenuApplyY, 
						Layout.MenuApplyTextX, Layout.MenuApplyTextY, "Apply", 
						Registrator.GenerateName(BaseNames.MenuApplyBackground), 
						Registrator.GenerateName(BaseNames.MenuApplyText)
					);
				case BaseNames.MenuBack:
					return CreateTextFrame(
						Layout.MenuEntryWidth, Layout.MenuEntryHeight, 
						Layout.MenuBackX, Layout.MenuBackY, 
						Layout.MenuBackTextX, Layout.MenuBackTextY, "Back", 
						Registrator.GenerateName(BaseNames.MenuBackBackground), 
						Registrator.GenerateName(BaseNames.MenuBackText)
					);
				case BaseNames.MenuExitToMenu:
					return CreateTextFrame(
						Layout.MenuEntryWidth, Layout.MenuEntryHeight, 
						Layout.MenuSettingsX, Layout.MenuSettingsY, 
						Layout.MenuExitToMenuTextX, Layout.MenuExitToMenuTextY, "Exit to Menu", 
						Registrator.GenerateName(BaseNames.MenuExitToMenuBackground), 
						Registrator.GenerateName(BaseNames.MenuExitToMenuText)
					);
				default:
					return CreateTextFrame(
						Layout.MenuEntryWidth, Layout.MenuEntryHeight, 
						Layout.MenuExitX, Layout.MenuExitY, 
						Layout.MenuExitTextX, Layout.MenuExitTextY, "Exit", 
						Registrator.GenerateName(BaseNames.MenuExitBackground), 
						Registrator.GenerateName(BaseNames.MenuExitText)
					);	
			}
		}

		public static List<Entity> CreateChooseFrame(
			int width, int height, int x, int y, int textX, int textY, string textString,
			int labelX, int labelY, string labelText,
			int leftX, int leftY, int rightX, int rightY,
			Name bgName = null, Name textName = null, 
			Name leftName = null, Name rightName = null
		)
		{
			var chooseFrame = new List<Entity>();

			var textLabel = new Entity(Registrator.GenerateName(BaseNames.Text));

			var tlDisplayComponent = new DisplayComponent();
			var tlText = new Text(labelText, new Font(Assets.Font), (uint)Layout.FontSize);
			tlDisplayComponent.DisplayObject = tlText;

			var tlPositionComponent = new PositionComponent();
			tlPositionComponent.X = labelX;
			tlPositionComponent.Y = labelY;

			textLabel.AddComponent(tlDisplayComponent);
			textLabel.AddComponent(tlPositionComponent);

			var textFrame = CreateTextFrame(width, height, x, y, textX, textY, textString, bgName, textName);

			var optionLeftButton = new Entity(leftName);

			var lDisplayComponent = new DisplayComponent();
			var lShape = new CircleShape(Layout.OptionEntryButtonSize, 3);
			lShape.Origin = new SFML.System.Vector2f(
				lShape.GetLocalBounds().Width / 2,
				lShape.GetLocalBounds().Height / 2
			);
			lShape.FillColor = Color.Transparent;
			lShape.OutlineThickness = 3;
			lShape.OutlineColor = Color.White;
			lDisplayComponent.DisplayObject = lShape;

			var lPositionComponent = new PositionComponent();
			lPositionComponent.X = leftX;
			lPositionComponent.Y = leftY;
			lPositionComponent.Rotation = -90;

			var lCollisionComponent = new CollisionComponent();
			lCollisionComponent.BoundingBox = new FloatRect(
				leftX, leftY, Layout.OptionEntryButtonSize, Layout.OptionEntryButtonSize
			);

			optionLeftButton.AddComponent(lDisplayComponent);
			optionLeftButton.AddComponent(lPositionComponent);
			optionLeftButton.AddComponent(lCollisionComponent);

			var optionRightButton = new Entity(rightName);

			var rDisplayComponent = new DisplayComponent();
			var rShape = new CircleShape(Layout.OptionEntryButtonSize, 3);
			rShape.Origin = new SFML.System.Vector2f(
				rShape.GetLocalBounds().Width / 2,
				rShape.GetLocalBounds().Height / 2
			);
			rShape.FillColor = Color.Transparent;
			rShape.OutlineThickness = 3;
			rShape.OutlineColor = Color.White;
			rDisplayComponent.DisplayObject = rShape;

			var rPositionComponent = new PositionComponent();
			rPositionComponent.X = rightX;
			rPositionComponent.Y = rightY;
			rPositionComponent.Rotation = 90;

			var rCollisionComponent = new CollisionComponent();
			rCollisionComponent.BoundingBox = new FloatRect(
				rightX, rightY, Layout.OptionEntryButtonSize, Layout.OptionEntryButtonSize
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
			BaseNames optionName
		)
		{
			switch (optionName){
				case BaseNames.MenuOptionVolume:
					return CreateChooseFrame(
						Layout.OptionEntryWidth, Layout.OptionEntryHeight,
						Layout.OptionVolumeX, Layout.OptionVolumeY,
						Layout.OptionVolumeTextX, Layout.OptionVolumeY,
						Settings.Volume.ToString(),
						Layout.OptionVolumeLabelX, Layout.OptionVolumeLabelY, "Volume",
						Layout.OptionVolumeLeftButtonX, Layout.OptionVolumeLeftButtonY,
						Layout.OptionVolumeRightButtonX, Layout.OptionVolumeRightButtonY,
						Registrator.GenerateName(BaseNames.MenuOptionVolumeBackground),
						Registrator.GenerateName(BaseNames.MenuOptionVolumeText),
						Registrator.GenerateName(BaseNames.MenuOptionVolumeLeftButton),
						Registrator.GenerateName(BaseNames.MenuOptionVolumeRightButton)
					);
				case BaseNames.MenuOptionResolution:
					return CreateChooseFrame(
						Layout.OptionEntryWidth, Layout.OptionEntryHeight, 
						Layout.OptionResolutionX, Layout.OptionResolutionY, 
						Layout.OptionResolutionTextX, Layout.OptionResolutionTextY, 
						Settings.Width + "x" + Settings.Height,
						Layout.OptionResolutionLabelX, Layout.OptionResolutionLabelY, "Resolution",
						Layout.OptionResolutionLeftButtonX, Layout.OptionResolutionLeftButtonY,
						Layout.OptionResolutionRightButtonX, Layout.OptionResolutionRightButtonY,
						Registrator.GenerateName(BaseNames.MenuOptionResolutionBackground), 
						Registrator.GenerateName(BaseNames.MenuOptionResolutionText),
						Registrator.GenerateName(BaseNames.MenuOptionResolutionLeftButton), 
						Registrator.GenerateName(BaseNames.MenuOptionResolutionRightButton)
					);
				default:
					return CreateChooseFrame(
						Layout.OptionEntryWidth, Layout.OptionEntryHeight, 
						Layout.OptionGameSizeX, Layout.OptionGameSizeY, 
						Layout.OptionGameSizeTextX, Layout.OptionGameSizeTextY, 
						Settings.GameSize.ToString(),
						Layout.OptionGameSizeLabelX, Layout.OptionGameSizeLabelY, "Game Size",
						Layout.OptionGameSizeLeftButtonX, Layout.OptionGameSizeLeftButtonY,
						Layout.OptionGameSizeRightButtonX, Layout.OptionGameSizeRightButtonY,
						Registrator.GenerateName(BaseNames.MenuOptionGameSizeBackground), 
						Registrator.GenerateName(BaseNames.MenuOptionGameSizeText),
						Registrator.GenerateName(BaseNames.MenuOptionGameSizeLeftButton), 
						Registrator.GenerateName(BaseNames.MenuOptionGameSizeRightButton)
					);	
			}
		}

		public static List<Entity> CreateHudFrame(
			int width, int height, int x, int y, int textX, int textY, string textString,
			int labelX, int labelY, string labelText,
			Name bgName = null, Name textName = null
		)
		{
			var hudFrame = new List<Entity>();

			var textLabel = new Entity(Registrator.GenerateName(BaseNames.Text));

			var tlDisplayComponent = new DisplayComponent();
			var tlText = new Text(labelText, new Font(Assets.Font), (uint)Layout.FontSize);
			tlDisplayComponent.DisplayObject = tlText;

			var tlPositionComponent = new PositionComponent();
			tlPositionComponent.X = labelX;
			tlPositionComponent.Y = labelY;

			textLabel.AddComponent(tlDisplayComponent);
			textLabel.AddComponent(tlPositionComponent);

			var textFrame = CreateTextFrame(
				width, height, x, y, textX, textY, textString, bgName, textName
			);

			hudFrame.Add(textLabel);
			hudFrame.AddRange(textFrame);

			return hudFrame;
		}

		public static List<Entity> CreateHud(
			BaseNames hudName
		)
		{
			switch (hudName) {
				case BaseNames.HudTime:
					return CreateHudFrame(
						Layout.HudTimeWidth,
						Layout.HudTimeHeight,
						Layout.HudTimeX,
						Layout.HudTimeY,
						Layout.HudTimeTextX,
						Layout.HudTimeTextY,
						"60",
						Layout.HudTimeLabelX,
						Layout.HudTimeLabelY,
						"Time",
						Registrator.GenerateName(BaseNames.Background),
						Registrator.GenerateName(BaseNames.HudTimeText)
					);
				default:
					return CreateHudFrame(
						Layout.HudScoreWidth,
						Layout.HudScoreHeight,
						Layout.HudScoreX,
						Layout.HudScoreY,
						Layout.HudScoreTextX,
						Layout.HudScoreTextY,
						"0",
						Layout.HudScoreLabelX,
						Layout.HudScoreLabelY,
						"Score",
						Registrator.GenerateName(BaseNames.Background),
						Registrator.GenerateName(BaseNames.HudScoreText)
					);
			}
		}

		public static Entity CreateLabel(
			int x, int y, string text, BaseNames baseName 
		)
		{
			var label = new Entity(Registrator.GenerateName(baseName));

			var lDisplayComponent = new DisplayComponent();
			lDisplayComponent.DisplayObject = new Text(text, new Font(Assets.Font), (uint)Layout.FontSize);

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
			GemView gem, int x, int y
		)
		{
			var gemEntity = new Entity(Registrator.GenerateName(BaseNames.Gem));

			var gDisplayComponent = new DisplayComponent();
			gem.GemShape.Origin = new SFML.System.Vector2f(
				gem.GemShape.GetLocalBounds().Width / 2.0f,
				gem.GemShape.GetLocalBounds().Height / 2.0f
			);
			gDisplayComponent.DisplayObject = gem.GemShape;

			var gPositionComponent = new PositionComponent();
			gPositionComponent.X = x;
			gPositionComponent.Y = y;

			var gCollisionComponent = new CollisionComponent();
			gCollisionComponent.BoundingBox = new FloatRect(x ,y, Layout.GemSize, Layout.GemSize);

			var gAnimationComponent = new AnimationComponent();
			gAnimationComponent.X = x;
			gAnimationComponent.Y = y;
			gAnimationComponent.Speed = Engine.GameSpeed;
			gAnimationComponent.Scale = gDisplayComponent.DisplayObject.Scale;

			var gGemComponent = new GemComponent();
			gGemComponent.GemType = gem.GemType;
			gGemComponent.GemSubType = gem.GemSubType;

			gemEntity.AddComponent(gDisplayComponent);
			gemEntity.AddComponent(gPositionComponent);
			gemEntity.AddComponent(gCollisionComponent);
			gemEntity.AddComponent(gAnimationComponent);
			gemEntity.AddComponent(gGemComponent);

			return gemEntity;
		}

		public static Entity CreateDestroyer(
			DestroyerView destroyer, float x, float y,
			float animX, float animY
		)
		{
			var destroyerEntity = new Entity(Registrator.GenerateName(BaseNames.Destroyer));

			var dDisplayComponent = new DisplayComponent();
			destroyer.DestroyerShape.Origin = new SFML.System.Vector2f(
				destroyer.DestroyerShape.GetLocalBounds().Width / 2.0f,
				destroyer.DestroyerShape.GetLocalBounds().Height / 2.0f
			);
			dDisplayComponent.DisplayObject = destroyer.DestroyerShape;

			var dPositionComponent = new PositionComponent();
			dPositionComponent.X = x;
			dPositionComponent.Y = y;

			float angle = 0.0f;
			if (animX > x)
			{
				angle = 180.0f;
			}
			else if (animY < y)
			{
				angle = 90.0f;
			}
			else if (animY > y)
			{
				angle = 270.0f;
			}
			dPositionComponent.Rotation = angle;

			var dCollisionComponent = new CollisionComponent();
			dCollisionComponent.BoundingBox = new FloatRect(x, y, Layout.GemSize, Layout.GemSize);

			var dAnimationComponent = new AnimationComponent();
			dAnimationComponent.X = animX;
			dAnimationComponent.Y = animY;
			dAnimationComponent.Speed = Engine.GameSpeed;
			dAnimationComponent.Scale = dDisplayComponent.DisplayObject.Scale;

			var dGemComponent = new GemComponent();
			dGemComponent.GemType = destroyer.GemType;
			dGemComponent.GemSubType = GemSub.Gem;

			destroyerEntity.AddComponent(dDisplayComponent);
			destroyerEntity.AddComponent(dPositionComponent);
			destroyerEntity.AddComponent(dCollisionComponent);
			destroyerEntity.AddComponent(dAnimationComponent);
			destroyerEntity.AddComponent(dGemComponent);

			return destroyerEntity;
		}
	}
}
