namespace thrii
{
	public class Layout
	{
		public uint GameSpriteWidth;
		public uint GameSpriteHeight;
		public uint GameSpriteX;
		public uint GameSpriteY;

		public uint FontSize;

		public uint MenuEntryWidth;
		public uint MenuEntryHeight;

		public uint MenuNewGameX;
		public uint MenuNewGameY;
		public uint MenuNewGameTextX;
		public uint MenuNewGameTextY;

		public uint MenuSettingsX;
		public uint MenuSettingsY;
		public uint MenuSettingsTextX;
		public uint MenuSettingsTextY;

		public uint MenuExitX;
		public uint MenuExitY;
		public uint MenuExitTextX;
		public uint MenuExitTextY;

		public uint OptionEntryWidth;
		public uint OptionEntryHeight;
		public uint OptionEntryButtonSize;
		public uint OptionEntryButtonMargin;

		public uint OptionResolutionLabelX;
		public uint OptionResolutionLabelY;
		public uint OptionResolutionX;
		public uint OptionResolutionY;
		public uint OptionResolutionTextX;
		public uint OptionResolutionTextY;
		public uint OptionResolutionLeftButtonX;
		public uint OptionResolutionLeftButtonY;
		public uint OptionResolutionRightButtonX;
		public uint OptionResolutionRightButtonY;

		public uint OptionGameSizeLabelX;
		public uint OptionGameSizeLabelY;
		public uint OptionGameSizeX;
		public uint OptionGameSizeY;
		public uint OptionGameSizeTextX;
		public uint OptionGameSizeTextY;
		public uint OptionGameSizeLeftButtonX; 
		public uint OptionGameSizeLeftButtonY;
		public uint OptionGameSizeRightButtonX;
		public uint OptionGameSizeRightButtonY;

		public uint MenuApplyX;
		public uint MenuApplyY;
		public uint MenuApplyTextX;
		public uint MenuApplyTextY;

		public uint MenuBackX;
		public uint MenuBackY;
		public uint MenuBackTextX;
		public uint MenuBackTextY;

		public uint SessionBackgroundMargin;
		public uint SessionBackgroundWidth;
		public uint SessionBackgroundHeight;
		public uint SessionBackgroundX;
		public uint SessionBackgroundY;

		public uint HudTimeWidth;
		public uint HudTimeHeight;
		public uint HudTimeX;
		public uint HudTimeY;
		public uint HudTimeTextX;
		public uint HudTimeTextY;
		public uint HudTimeLabelX;
		public uint HudTimeLabelY;

		public uint HudScoreWidth;
		public uint HudScoreHeight;
		public uint HudScoreX;
		public uint HudScoreY;
		public uint HudScoreTextX;
		public uint HudScoreTextY;
		public uint HudScoreLabelX;
		public uint HudScoreLabelY;

		public uint GemMargin;
		public uint GemSize;
		public uint GemDistance;

		public Layout()
		{
			GameSpriteWidth = Settings.Width / 3;
			GameSpriteHeight = GameSpriteWidth;
			GameSpriteX = Settings.Width / 2 - GameSpriteWidth / 2;
			GameSpriteY = Settings.Height / 20;

			FontSize = Settings.Height / 20;

			MenuEntryWidth = Settings.Width / 4;
			MenuEntryHeight = Settings.Height / 12;

			MenuNewGameX = Settings.Width / 2 - MenuEntryWidth / 2;
			MenuNewGameY = Settings.Height / 2 - MenuEntryHeight;
			MenuNewGameTextX = MenuNewGameX + MenuEntryWidth / 8;
			MenuNewGameTextY = MenuNewGameY + MenuEntryHeight / 10;

			MenuSettingsX = MenuNewGameX;
			MenuSettingsY = Settings.Height / 2 + MenuEntryHeight / 4;
			MenuSettingsTextX = MenuSettingsX + MenuEntryWidth / 5 + FontSize / 4;
			MenuSettingsTextY = MenuSettingsY + MenuEntryHeight / 10;

			MenuExitX = MenuNewGameX;
			MenuExitY = Settings.Height / 2 + MenuEntryHeight * 2;
			MenuExitTextX = MenuExitX + MenuEntryWidth / 3 + Settings.Height / 64;
			MenuExitTextY = MenuExitY + MenuEntryHeight / 10;

			OptionEntryWidth = MenuEntryWidth;
			OptionEntryHeight = MenuEntryHeight;
			OptionEntryButtonSize = MenuEntryHeight / 2;
			OptionEntryButtonMargin = OptionEntryButtonSize;

			OptionResolutionLabelX = MenuNewGameX + MenuEntryWidth / 6;
			OptionResolutionLabelY = MenuNewGameY;
			OptionResolutionX = MenuNewGameX;
			OptionResolutionY = OptionResolutionLabelY + FontSize + FontSize / 3;
			OptionResolutionTextX = OptionResolutionX + FontSize;
			OptionResolutionTextY = OptionResolutionY;
			OptionResolutionLeftButtonX = OptionResolutionX - OptionEntryButtonMargin;
			OptionResolutionLeftButtonY = OptionResolutionY + OptionEntryButtonSize + OptionEntryButtonSize / 10;
			OptionResolutionRightButtonX = OptionResolutionX + MenuEntryWidth + OptionEntryButtonMargin;
			OptionResolutionRightButtonY = OptionResolutionY  + OptionEntryButtonSize - OptionEntryButtonSize / 10;

			OptionGameSizeLabelX = MenuSettingsX + MenuEntryWidth / 7;
			OptionGameSizeLabelY = OptionResolutionY + MenuEntryHeight;
			OptionGameSizeX = MenuSettingsX;
			OptionGameSizeY = OptionGameSizeLabelY + FontSize + FontSize / 3;
			OptionGameSizeTextX = OptionGameSizeX + FontSize + FontSize * 2;
			OptionGameSizeTextY = OptionGameSizeY;
			OptionGameSizeLeftButtonX = OptionGameSizeX - OptionEntryButtonMargin;
			OptionGameSizeLeftButtonY = OptionGameSizeY  + OptionEntryButtonSize + OptionEntryButtonSize / 10;
			OptionGameSizeRightButtonX = OptionGameSizeX + MenuEntryWidth + OptionEntryButtonMargin;
			OptionGameSizeRightButtonY = OptionGameSizeY + OptionEntryButtonSize - OptionEntryButtonSize / 10;

			MenuApplyX = MenuExitX;
			MenuApplyY = OptionGameSizeY + MenuEntryHeight + MenuEntryHeight / 2;
			MenuApplyTextX = MenuApplyX + MenuEntryWidth / 3;
			MenuApplyTextY = MenuApplyY;

			MenuBackX = MenuExitX;
			MenuBackY = MenuApplyY + MenuEntryHeight + MenuEntryHeight / 4;
			MenuBackTextX = MenuBackX + MenuEntryWidth / 3;
			MenuBackTextY = MenuBackY;

			SessionBackgroundMargin = MenuEntryHeight;
			SessionBackgroundWidth = Settings.Width -SessionBackgroundMargin * 5;
			SessionBackgroundHeight = SessionBackgroundWidth;
			SessionBackgroundX = (Settings.Width - SessionBackgroundWidth) / 2;
			SessionBackgroundY = Settings.Height / 20;

			HudTimeWidth = MenuEntryWidth / 2;
			HudTimeHeight = MenuEntryHeight;
			HudTimeX = Settings.Width / 100;
			HudTimeY = SessionBackgroundY + MenuEntryHeight;
			HudTimeTextX = HudTimeX + FontSize;
			HudTimeTextY = HudTimeY + FontSize / 6;
			HudTimeLabelX = HudTimeX + FontSize / 2;
			HudTimeLabelY = SessionBackgroundY;

			HudScoreWidth = MenuEntryWidth / 2;
			HudScoreHeight = MenuEntryHeight;
			HudScoreX = Settings.Width - (Settings.Width - SessionBackgroundWidth - FontSize) / 2;
			HudScoreY = SessionBackgroundY + MenuEntryHeight;
			HudScoreTextX = HudScoreX + FontSize + FontSize / 3;
			HudScoreTextY = HudScoreY + FontSize / 4;
			HudScoreLabelX = HudScoreX + FontSize / 3;
			HudScoreLabelY = SessionBackgroundY;

			GemMargin = SessionBackgroundWidth / 50;
			GemSize = SessionBackgroundWidth / (Settings.GameSize * 2) - GemMargin / Settings.GameSize;
			GemDistance = GemSize * 2;
		}
	}
}
