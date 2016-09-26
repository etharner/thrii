using System;
using SFML.Window;
using SFML.Graphics;

namespace thrii
{
	public class Drawer
	{
		public RenderWindow Window { get; set; }
		Engine engine;
		
		public Drawer(uint width, uint height, string name, string iconPath, Engine e)
		{
			Window = new RenderWindow(new VideoMode(width, height), name);
			SetIcon(iconPath);
			Window.Closed += OnClosed;
			engine = e;
		}

		void SetIcon(string iconPath)
		{
			var icon = new Image(iconPath);
			Window.SetIcon(32, 32, icon.Pixels);
		}

		static void OnClosed(object sender, EventArgs e)
		{
			((Window)sender).Close();
		}

		public void Draw(Transformable t) 
		{
			Window.Draw((Drawable)t);
		}

		public void DrawLoop() 
		{
			while (Window.IsOpen)
			{
				Window.DispatchEvents();
				engine.Update();
				Window.Display();
			}
		}
	}
}
