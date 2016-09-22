using System;
using Otter;

namespace thrii
{
	public class GameScene
	{
		public Scene Scene { get; }

		public GameScene()
		{
			Scene = new Scene();
			Scene.Add(new Actor(0, 0, 100, 100).Entity);
		}
	}
}
