namespace thrii
{
	public class SceneSystem : System
	{
		public SceneSystem(Engine e) : base(e) {}

		void StartLevel(LevelInfo levelInfo)
		{
			engine.LastClicked.Clear();

			engine.GameState = GameState.NewGame;

			engine.CurrentLevel = levelInfo;

			Settings.GameSize = levelInfo.GameSize;

			engine.ResetSystems();

			engine.SwitchScene(new SessionScene());

			engine.SessionClock = new SFML.System.Clock();
		}

		public override void Update()
		{
			if (engine.NeedSwitchScene)
			{
				int score = engine.Score;
	
				switch (engine.GameState)
				{
					case GameState.Menu:
						engine.SwitchScene(new MenuScene());
						break;
					case GameState.NewGame:
						engine.ResetSystems();
						engine.SwitchScene(new SessionScene());
						break;
					case GameState.GameOver:
						engine.ResetSystems();
						engine.Score = score;
						engine.SwitchScene(new GameOverScene(score));
 						break;	
				}

				engine.NeedSwitchScene = false;
			}

			if (engine.CheckClicked(BaseNames.MenuNewGameBackground))
			{
				engine.LastClicked.Clear();

				//engine.GameState = GameState.NewGame;

				engine.ResetSystems();

				engine.SwitchScene(new LevelScene());

				engine.SessionClock = new SFML.System.Clock();
			}

			if (engine.CheckClicked(BaseNames.Level))
			{
				int i = engine.LastClicked.Find(n => n.BaseName == BaseNames.Level).Id;
				LevelInfo l = Levels.LevelsList[i];

				StartLevel(l);
			}

			if (engine.CheckClicked(BaseNames.LevelNewGameBackground))
			{
				StartLevel(Levels.LevelsList[0]);	
			}

			if (engine.CheckClicked(BaseNames.MenuSettingsBackground))
			{
				engine.LastClicked.Clear();

				Settings.PrevResolutionIndex = Settings.ResolutionIndex;
				Settings.PrevGameSizeIndex = Settings.GameSizeIndex;

				engine.SwitchScene(new SettingsScene());
			}

			if (engine.CheckClicked(BaseNames.MenuApplyBackground))
			{
				engine.LastClicked.Clear();

				Settings.PrevVolumeIndex = Settings.VolumeIndex;
				Settings.PrevResolutionIndex = Settings.ResolutionIndex;
				Settings.PrevGameSizeIndex = Settings.GameSizeIndex;

				var oldWindow = engine.Renderer.Window;
				engine.Renderer = new Drawer(Settings.Width, Settings.Height, Settings.Name, Assets.Icon);
				oldWindow.Close();
				engine.ResetSystems();

				engine.SwitchScene(new MenuScene());
			}

			if (engine.CheckClicked(BaseNames.MenuBackBackground))
			{
				engine.LastClicked.Clear();

				Settings.SwitchSettings(SettingsEntry.Volume, Settings.PrevVolumeIndex);
				Settings.SwitchSettings(SettingsEntry.Resolution, Settings.PrevResolutionIndex);
				Settings.SwitchSettings(SettingsEntry.GameSize, Settings.PrevGameSizeIndex);

				engine.SwitchScene(new MenuScene());
			}

			if (engine.CheckClicked(BaseNames.MenuExitToMenuBackground))
			{
				engine.LastClicked.Clear();

				engine.GameState = GameState.Menu;

				Settings.RestoreGameSize();

				engine.ResetSystems();

				engine.SwitchScene(new MenuScene());
			}

			if (engine.CheckClicked(BaseNames.MenuExitBackground))
			{
				engine.Stop();
			}
		}
	}
}
