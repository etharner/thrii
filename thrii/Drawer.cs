using System;
using SFML.Window;
using SFML.Graphics;

namespace thrii
{
	public class Drawer
	{
		Window window;
		
		public Drawer(uint width, uint height, string name, string iconPath)
		{
			window = new Window(new VideoMode(width, height), name);
			SetIcon(iconPath);
			window.Closed += OnClosed;
		}

		void SetIcon(string iconPath)
		{
			var icon = new Image(iconPath);
			window.SetIcon(32, 32, icon.Pixels);
		}

		static void OnClosed(object sender, EventArgs e)
		{
			((Window)sender).Close();
		}

		public void DrawLoop() {
			while (window.IsOpen)
			{
				window.DispatchEvents();
				window.Display();
			}
		}
	}
}
