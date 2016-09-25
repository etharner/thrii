using System;
using SFML.Window;
using SFML.Graphics;

namespace thrii
{
	public class Drawer
	{
		RenderWindow window;
		Input input;
		Engine engine;
		
		public Drawer(uint width, uint height, string name, string iconPath, Engine e)
		{
			window = new RenderWindow(new VideoMode(width, height), name);
			SetIcon(iconPath);
			window.Closed += OnClosed;
			input = new Input(e, window);
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
				input.CheckInput();
				engine.Update();
				window.Display();
			}
		}
	}
}
