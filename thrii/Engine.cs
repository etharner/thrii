using System;
using Otter;

namespace thrii
{
	public class Engine
	{
		Game game;
		GameScene currentScene;

		readonly string icon = "icon.png";

		public Engine()
		{
			game = new Game("THRII", 800, 600, 60, false);
			game.SetIcon(icon);

			currentScene = new GameScene();
		}

		public void Start() {
			game.Start(currentScene.Scene);
		}
	}
}
