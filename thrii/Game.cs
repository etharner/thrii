using System;
using SFML.Window;


namespace thrii
{
	public class Game
	{
		public Game()
		{
		}

		public void Start() {
			var drawer = new Drawer(800, 600, "THRII", "icon.png");
			drawer.DrawLoop();
		}
	}
}
