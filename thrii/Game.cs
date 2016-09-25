namespace thrii
{
	public class Game
	{
		Engine engine;

		public Game()
		{
			engine = new Engine();
		}

		public void Start() {
			engine.Start();
		}
	}
}
