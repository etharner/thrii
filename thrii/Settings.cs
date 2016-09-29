using System.Collections.Generic;
using System.Xml;

namespace thrii
{
	public enum SwitchSide {
		Left,
		Right
	}

	static class Settings
	{
		static string settingsFile = "settings.xml";
		public static List<SFML.System.Vector2i> SupportedResolutions = new List<SFML.System.Vector2i>()
		{
			new SFML.System.Vector2i(640, 480),
			new SFML.System.Vector2i(800, 600),
			new SFML.System.Vector2i(1024, 768),
			new SFML.System.Vector2i(1152, 864),
			new SFML.System.Vector2i(1280, 960),

		};
		public static List<uint> SupportedGameSizes = new List<uint>() { 4, 8, 12, 16 };
		public static int ResolutionIndex;
		public static int GameSizeIndex;
		public static int PrevResolutionIndex;
		public static int PrevGameSizeIndex;
		public static uint Width;
		public static uint Height;
		public static string Name;
		public static string IconPath;
		public static uint GameSize;

		public static void ParseSettings()
		{
			var xml = new XmlDocument();
			xml.Load(settingsFile);

			Width = uint.Parse(xml.GetElementsByTagName("Width")[0].InnerText);
			Height = uint.Parse(xml.GetElementsByTagName("Height")[0].InnerText);
			Name = xml.GetElementsByTagName("Name")[0].InnerText;
			IconPath = xml.GetElementsByTagName("IconPath")[0].InnerText;
			GameSize = uint.Parse(xml.GetElementsByTagName("GameSize")[0].InnerText);

			ResolutionIndex = SupportedResolutions.FindIndex(r => r.X == Width && r.Y == Height);
			PrevResolutionIndex = ResolutionIndex;

			GameSizeIndex = SupportedGameSizes.FindIndex(gs => gs == GameSize);
			PrevGameSizeIndex = GameSizeIndex;
		}

		public static void SwitchResolution(int index)
		{
			var newResolution = SupportedResolutions[index];

			Width = (uint)newResolution.X;
			Height = (uint)newResolution.Y;

			ResolutionIndex = index;

			var xml = new XmlDocument();
			xml.Load(settingsFile);

			xml.GetElementsByTagName("Width")[0].InnerText = newResolution.X.ToString();
			xml.GetElementsByTagName("Height")[0].InnerText = newResolution.Y.ToString();
			xml.Save(settingsFile);
		}

		public static void SwitchGameSize(int index)
		{
			var newGameSize = SupportedGameSizes[index];

			GameSize = newGameSize;

			GameSizeIndex = index;

			var xml = new XmlDocument();
			xml.Load(settingsFile);

			xml.GetElementsByTagName("GameSize")[0].InnerText = newGameSize.ToString();
			xml.Save(settingsFile);
		}
	}
}
