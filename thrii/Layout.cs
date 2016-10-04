namespace thrii
{
	public class Layout
	{
		public int GameSpriteWidth;
		public int GameSpriteHeight;
		public int GameSpriteX;
		public int GameSpriteY;

		public int FontSize;

		public int MenuEntryWidth;
		public int MenuEntryHeight;

		public int MenuNewGameX;
		public int MenuNewGameY;
		public int MenuNewGameTextX;
		public int MenuNewGameTextY;

		public int MenuSettingsX;
		public int MenuSettingsY;
		public int MenuSettingsTextX;
		public int MenuSettingsTextY;

		public int MenuExitX;
		public int MenuExitY;
		public int MenuExitTextX;
		public int MenuExitTextY;

		public int OptionEntryWidth;
		public int OptionEntryHeight;
		public int OptionEntryButtonSize;
		public int OptionEntryButtonMargin;

		public int OptionResolutionLabelX;
		public int OptionResolutionLabelY;
		public int OptionResolutionX;
		public int OptionResolutionY;
		public int OptionResolutionTextX;
		public int OptionResolutionTextY;
		public int OptionResolutionLeftButtonX;
		public int OptionResolutionLeftButtonY;
		public int OptionResolutionRightButtonX;
		public int OptionResolutionRightButtonY;

		public int OptionGameSizeLabelX;
		public int OptionGameSizeLabelY;
		public int OptionGameSizeX;
		public int OptionGameSizeY;
		public int OptionGameSizeTextX;
		public int OptionGameSizeTextY;
		public int OptionGameSizeLeftButtonX; 
		public int OptionGameSizeLeftButtonY;
		public int OptionGameSizeRightButtonX;
		public int OptionGameSizeRightButtonY;

		public int MenuApplyX;
		public int MenuApplyY;
		public int MenuApplyTextX;
		public int MenuApplyTextY;

		public int MenuBackX;
		public int MenuBackY;
		public int MenuBackTextX;
		public int MenuBackTextY;

		public int MenuGameOverX;
		public int MenuGameOverY;

		public int MenuScoreX;
		public int MenuScoreY;

		public int MenuExitToMenuTextX;
		public int MenuExitToMenuTextY;

		public int SessionBackgroundMargin;
		public int SessionBackgroundWidth;
		public int SessionBackgroundHeight;
		public int SessionBackgroundX;
		public int SessionBackgroundY;

		public int HudTimeWidth;
		public int HudTimeHeight;
		public int HudTimeX;
		public int HudTimeY;
		public int HudTimeTextX;
		public int HudTimeTextY;
		public int HudTimeLabelX;
		public int HudTimeLabelY;

		public int HudScoreWidth;
		public int HudScoreHeight;
		public int HudScoreX;
		public int HudScoreY;
		public int HudScoreTextX;
		public int HudScoreTextY;
		public int HudScoreLabelX;
		public int HudScoreLabelY;

		public int GemMargin;
		public int GemSize;
		public int GemDistance;

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

			MenuGameOverX = MenuNewGameTextX;
			MenuGameOverY = MenuNewGameY - MenuEntryHeight * 2;

			MenuScoreX = MenuSettingsX + MenuEntryWidth / 6;
			MenuScoreY = MenuSettingsY - MenuEntryHeight - FontSize * 2;

			MenuExitToMenuTextX = MenuSettingsX + FontSize / 2;
			MenuExitToMenuTextY = MenuSettingsTextY;

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
			GemSize = SessionBackgroundWidth / (Settings.GameSize * 2) - SessionBackgroundWidth / 100;
			GemDistance = GemSize * 2 + GemSize / 3;
		}
	}
}
