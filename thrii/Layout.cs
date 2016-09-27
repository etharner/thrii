namespace thrii
{
	public static class Layout
	{
		public static uint MenuEntryWidth = Settings.Width / 4;
		public static uint MenuEntryHeight = Settings.Height / 12;
		public static uint MenuNewGameX = Settings.Width / 2 - MenuEntryWidth / 2;
		public static uint MenuNewGameY = Settings.Height / 2 - MenuEntryHeight;
		public static uint MenuNewGameTextX = MenuNewGameX + MenuEntryWidth / 8;
		public static uint MenuNewGameTextY = MenuNewGameY + MenuEntryHeight / 10;
		public static uint MenuSettingsX = MenuNewGameX;
		public static uint MenuSettingsY = Settings.Height / 2 + MenuEntryHeight / 4;
		public static uint MenuSettingsTextX = MenuSettingsX + MenuEntryWidth / 5;
		public static uint MenuSettingsTextY = MenuSettingsY + MenuEntryHeight / 10;

		public static uint SessionBackgroundMargin = MenuEntryHeight;
		public static uint SessionBackgroundWidth = Settings.Width -SessionBackgroundMargin * 5;
		public static uint SessionBackgroundHeight = SessionBackgroundWidth;
		public static uint SessionBackgroundX = (Settings.Width - SessionBackgroundWidth) / 2;
		public static uint SessionBackgroundY = Settings.Height / 20;

		public static uint GemMargin = SessionBackgroundWidth / 50;
		public static uint GemSize = SessionBackgroundWidth / (Settings.GameSize * 2) - GemMargin / Settings.GameSize;
		public static uint GemDistance = GemSize * 2;
	}
}
