using System;

namespace thrii
{
	public class Settings
	{
		public uint Width { get; }
		public uint Height { get; }
		public string Name { get; }
		public string IconPath { get; }

		public Settings(uint width, uint height, string name, string iconPath)
		{
			Width = width;
			Height = height;
			Name = name;
			IconPath = iconPath;
		}
	}
}
