namespace thrii
{
	public class Game
	{
		Engine engine;

		public Game()
		{
			Settings.ParseSettings();
			engine = new Engine();
		}

		public void Start() {
			engine.Start();
		}
	}
}
