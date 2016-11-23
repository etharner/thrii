using System.Collections.Generic;
using System.Xml;
using System.Linq;

namespace thrii
{
	public enum SwitchSide {
		Left,
		Right
	}

	public enum SettingsEntry
	{
		Volume,
		Resolution,
		GameSize
	}

	static class Settings
	{
		static string settingsFile = Assets.Settings;
		public static List<int> SupportedVolumes = Enumerable.Range(0, 11).Select(n => n * 10).ToList();
		public static List<SFML.System.Vector2i> SupportedResolutions = new List<SFML.System.Vector2i>
		{
			new SFML.System.Vector2i(640, 480),
			new SFML.System.Vector2i(800, 600),
			new SFML.System.Vector2i(1024, 768),
			new SFML.System.Vector2i(1152, 864),
			new SFML.System.Vector2i(1280, 960),

		};
		public static List<int> SupportedGameSizes = new List<int> { 4, 8, 12, 16 };
		public static int VolumeIndex;
		public static int ResolutionIndex;
		public static int GameSizeIndex;
		public static int PrevVolumeIndex;
		public static int PrevResolutionIndex;
		public static int PrevGameSizeIndex;
		public static int Volume;
		public static int Width;
		public static int Height;
		public static string Name;
		public static int GameSize;

		public static void ParseSettings()
		{
			var xml = new XmlDocument();
			xml.Load(settingsFile);

			Volume = int.Parse(xml.GetElementsByTagName("Volume")[0].InnerText);
			Width = int.Parse(xml.GetElementsByTagName("Width")[0].InnerText);
			Height = int.Parse(xml.GetElementsByTagName("Height")[0].InnerText);
			Name = xml.GetElementsByTagName("Name")[0].InnerText;
			GameSize = int.Parse(xml.GetElementsByTagName("GameSize")[0].InnerText);

			VolumeIndex = SupportedVolumes.FindIndex(v => v == Volume);
			PrevVolumeIndex = VolumeIndex;

			ResolutionIndex = SupportedResolutions.FindIndex(r => r.X == Width && r.Y == Height);
			PrevResolutionIndex = ResolutionIndex;

			GameSizeIndex = SupportedGameSizes.FindIndex(gs => gs == GameSize);
			PrevGameSizeIndex = GameSizeIndex;
		}

		public static void SwitchSettings(SettingsEntry entry, int index)
		{
			var xml = new XmlDocument();
			xml.Load(settingsFile);

			var newValue = 0;
			switch (entry)
			{
				case SettingsEntry.Volume:
					newValue = SupportedVolumes[index];

					Volume = newValue;
					VolumeIndex = index;

					break;
				case SettingsEntry.Resolution:
					var newResolution = SupportedResolutions[index];

					Width = newResolution.X;
					Height = newResolution.Y;

					ResolutionIndex = index;

					xml.GetElementsByTagName("Width")[0].InnerText = newResolution.X.ToString();
					xml.GetElementsByTagName("Height")[0].InnerText = newResolution.Y.ToString();
					xml.Save(settingsFile);

					return;
				default:
					newValue = SupportedGameSizes[index];

					GameSize = newValue;
					GameSizeIndex = index;

					break;
			}

			xml.GetElementsByTagName(entry.ToString())[0].InnerText = newValue.ToString();
			xml.Save(settingsFile);
		}
	}
}
