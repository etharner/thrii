using System.Collections.Generic;

namespace thrii
{
	public static class Assets
	{
		public static string AssetsFolder = "Assets/";
		public static string TexturesFolder = AssetsFolder + "Textures/";
		public static string SoundsFolder = AssetsFolder + "Sounds/";
		public static string FontsFolder = AssetsFolder + "Fonts/";

		public static string Icon = TexturesFolder + "icon.png";
		public static string Settings = "settings.xml";
		public static string Progress = "progress.xml";
		public static string Font = FontsFolder + "helvetica.otf";
		public static string GameLogo = TexturesFolder + "gameLogo.png";
		public static string CircleBomb = TexturesFolder + "circleBomb.png";
		public static string RombBomb = TexturesFolder + "rombBomb.png";
		public static string PentagonBomb = TexturesFolder + "pentagonBomb.png";
		public static string HexagonBomb = TexturesFolder + "hexagonBomb.png";
		public static string OctagonBomb = TexturesFolder + "octagonBomb.png";
		public static string CircleDestroyer = TexturesFolder + "circleDestroyer.png";
		public static string RombDestroyer = TexturesFolder + "rombDestroyer.png";
		public static string PentagonDestroyer = TexturesFolder + "pentagonDestroyer.png";
		public static string HexagonDestroyer = TexturesFolder + "hexagonDestroyer.png";
		public static string OctagonDestroyer = TexturesFolder + "octagonDestroyer.png";
		public static string CircleLine = TexturesFolder + "circleLine.png";
		public static string RombLine = TexturesFolder + "rombLine.png";
		public static string PentagonLine = TexturesFolder + "pentagonLine.png";
		public static string HexagonLine = TexturesFolder + "hexagonLine.png";
		public static string OctagonLine = TexturesFolder + "octagonLine.png";
		public static List<string> Music = new List<string> {
			SoundsFolder + "thrii1.ogg", 
			SoundsFolder + "thrii2.ogg", 
			SoundsFolder + "thrii3.ogg", 
			SoundsFolder + "thrii4.ogg"
		};
		public static string GemSound = SoundsFolder + "gem.ogg";
		public static string DestroyerSound = SoundsFolder + "destroyer.ogg";
		public static string BoomSound = SoundsFolder + "boom.ogg";
	}
}
