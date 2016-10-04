using System;
using SFML.Window;
using SFML.Graphics;

namespace thrii
{
	public class Drawer
	{
		public RenderWindow Window { get; set; }

		public Drawer(int width, int height, string name, string iconPath)
		{
			var windowSettings = new ContextSettings();
			windowSettings.AntialiasingLevel = 8;

			Window = new RenderWindow(new VideoMode((uint)width, (uint)height), name, Styles.Close, windowSettings);
			SetIcon(iconPath);
			Window.Closed += OnClosed;
		}

		void SetIcon(string iconPath)
		{
			var icon = new Image(iconPath);
			Window.SetIcon(256, 256, icon.Pixels);
		}

		static void OnClosed(object sender, EventArgs e)
		{
			((Window)sender).Close();
		}

		public void Draw(Transformable t) 
		{
			Window.Draw((Drawable)t);
		}
	}
}
