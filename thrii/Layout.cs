namespace thrii
{
	public static class Layout
	{
		public static int GameSpriteWidth;
		public static int GameSpriteHeight;
		public static int GameSpriteX;
		public static int GameSpriteY;
			
		public static int FontSize;
			   
		public static int MenuEntryWidth;
		public static int MenuEntryHeight;
			  
		public static int MenuNewGameX;
		public static int MenuNewGameY;
		public static int MenuNewGameTextX;
		public static int MenuNewGameTextY;
			 
		public static int MenuSettingsX;
		public static int MenuSettingsY;
		public static int MenuSettingsTextX;
		public static int MenuSettingsTextY;
			  
		public static int MenuExitX;
		public static int MenuExitY;
		public static int MenuExitTextX;
		public static int MenuExitTextY;
			 
		public static int OptionEntryWidth;
		public static int OptionEntryHeight;
		public static int OptionEntryButtonSize;
		public static int OptionEntryButtonMargin;

		public static int OptionVolumeLabelX;
		public static int OptionVolumeLabelY;
		public static int OptionVolumeX;
		public static int OptionVolumeY;
		public static int OptionVolumeTextX;
		public static int OptionVolumeTextY;
		public static int OptionVolumeLeftButtonX;
		public static int OptionVolumeLeftButtonY;
		public static int OptionVolumeRightButtonX;
		public static int OptionVolumeRightButtonY;
			  
		public static int OptionResolutionLabelX;
		public static int OptionResolutionLabelY;
		public static int OptionResolutionX;
		public static int OptionResolutionY;
		public static int OptionResolutionTextX;
		public static int OptionResolutionTextY;
		public static int OptionResolutionLeftButtonX;
		public static int OptionResolutionLeftButtonY;
		public static int OptionResolutionRightButtonX;
		public static int OptionResolutionRightButtonY;
			  
		public static int OptionGameSizeLabelX;
		public static int OptionGameSizeLabelY;
		public static int OptionGameSizeX;
		public static int OptionGameSizeY;
		public static int OptionGameSizeTextX;
		public static int OptionGameSizeTextY;
		public static int OptionGameSizeLeftButtonX; 
		public static int OptionGameSizeLeftButtonY;
		public static int OptionGameSizeRightButtonX;
		public static int OptionGameSizeRightButtonY;
			  
		public static int MenuApplyX;
		public static int MenuApplyY;
		public static int MenuApplyTextX;
		public static int MenuApplyTextY;
			
		public static int MenuBackX;
		public static int MenuBackY;
		public static int MenuBackTextX;
		public static int MenuBackTextY;
			 
		public static int MenuGameOverX;
		public static int MenuGameOverY;
			
		public static int MenuScoreX;
		public static int MenuScoreY;
			
		public static int MenuExitToMenuTextX;
		public static int MenuExitToMenuTextY;
	
		public static int SessionBackgroundMargin;
		public static int SessionBackgroundWidth;
		public static int SessionBackgroundHeight;
		public static int SessionBackgroundX;
		public static int SessionBackgroundY;
			
		public static int HudTimeWidth;
		public static int HudTimeHeight;
		public static int HudTimeX;
		public static int HudTimeY;
		public static int HudTimeTextX;
		public static int HudTimeTextY;
		public static int HudTimeLabelX;
		public static int HudTimeLabelY;

		public static int HudScoreWidth;
		public static int HudScoreHeight;
		public static int HudScoreX;
		public static int HudScoreY;
		public static int HudScoreTextX;
		public static int HudScoreTextY;
		public static int HudScoreLabelX;
		public static int HudScoreLabelY;

		public static int GemMargin;
		public static int GemSize;
		public static int GemDistance;
	
		public static int BombSize;

		public static void Update()
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

			OptionVolumeLabelX = MenuNewGameX + MenuEntryWidth / 4;
			OptionVolumeLabelY = GameSpriteY + MenuEntryHeight * 2 + MenuEntryHeight / 2;
			OptionVolumeX = MenuNewGameX;
			OptionVolumeY = OptionVolumeLabelY + FontSize + FontSize / 3;
			OptionVolumeTextX = OptionVolumeX + FontSize * 2 + FontSize / 2 + FontSize / 3;
			OptionVolumeTextY = OptionVolumeY;
			OptionVolumeLeftButtonX = OptionVolumeX - OptionEntryButtonMargin;
			OptionVolumeLeftButtonY = OptionVolumeY + OptionEntryButtonSize + OptionEntryButtonSize / 10;
			OptionVolumeRightButtonX = OptionVolumeX + MenuEntryWidth + OptionEntryButtonMargin;
			OptionVolumeRightButtonY = OptionVolumeY + OptionEntryButtonSize - OptionEntryButtonSize / 10;

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
			OptionGameSizeLeftButtonY = OptionGameSizeY + OptionEntryButtonSize + OptionEntryButtonSize / 10;
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
			MenuScoreY = MenuSettingsY - MenuEntryHeight - FontSize * 3 + FontSize / 2;

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
			HudScoreTextX = HudScoreX + FontSize / 4;
			HudScoreTextY = HudScoreY + FontSize / 4;
			HudScoreLabelX = HudScoreX + FontSize / 3;
			HudScoreLabelY = SessionBackgroundY;

			GemMargin = SessionBackgroundWidth / 50;
			GemSize = SessionBackgroundWidth / Settings.GameSize / 2 - GemMargin / (Settings.GameSize / 4);
			GemDistance = GemSize * 2 + GemSize / 3;

			BombSize = GemSize * 2;
		}
	}
}
