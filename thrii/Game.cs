namespace thrii
{
	public class Game
	{
		Engine engine;
		Settings settings;

		public Game()
		{
			settings = new Settings(800, 600, "TRHII", "icon.png");
			engine = new Engine(settings);
		}

		public void Start() {
			engine.Start();
		}
	}
}
