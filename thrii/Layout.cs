namespace thrii
{
	public static class Layout
	{
		public static uint MenuNewGameWidth = Settings.Width / 4;
		public static uint MenuNewGameHeight = Settings.Height / 12;
		public static uint MenuNewGameX = Settings.Width / 2 - MenuNewGameWidth / 2;
		public static uint MenuNewGameY = Settings.Height / 2 - MenuNewGameHeight / 2;
		public static uint MenuNewGameTextX = MenuNewGameX + MenuNewGameWidth / 8;
		public static uint MenuNewGameTextY = MenuNewGameY + MenuNewGameHeight / 10;

		public static uint SessionBackgroundMargin = MenuNewGameHeight;
		public static uint SessionBackgroundWidth = Settings.Width -SessionBackgroundMargin * 5;
		public static uint SessionBackgroundHeight = SessionBackgroundWidth;
		public static uint SessionBackgroundX = (Settings.Width - SessionBackgroundWidth) / 2;
		public static uint SessionBackgroundY = Settings.Height / 20;

		public static uint GemMargin = SessionBackgroundWidth / 50;
		public static uint GemSize = SessionBackgroundWidth / (Settings.GameSize * 2) - GemMargin / Settings.GameSize;
		public static uint GemDistance = GemSize * 2;
	}
}
