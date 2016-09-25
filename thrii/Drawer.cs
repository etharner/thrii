using System;
using SFML;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace thrii
{
	public class Drawer
	{
		RenderWindow window;
		Engine engine;
		
		public Drawer(uint width, uint height, string name, string iconPath, Engine e)
		{
			window = new RenderWindow(new VideoMode(width, height), name);
			SetIcon(iconPath);
			window.Closed += OnClosed;
			engine = e;
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

		public void Draw(Transformable t) 
		{
			window.Draw((Drawable)t);
		}

		public void DrawLoop() 
		{
			while (window.IsOpen)
			{
				window.DispatchEvents();
				engine.Update();
				window.Display();
			}
		}
	}
}
