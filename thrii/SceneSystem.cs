namespace thrii
{
	public class SceneSystem : System
	{
		public SceneSystem(Engine e) : base(e) {}

		public override void Update()
		{
			if (engine.NeedSwitchScene)
			{
				switch (engine.GameState)
				{
					case GameState.MENU:
						engine.SwitchScene(new MenuScene());
						break;
					case GameState.NEW_GAME:
						engine.SwitchScene(new SessionScene());
						break;
					case GameState.GAME_OVER:
						engine.SwitchScene(new GameOverScene());
						break;	
				}

				engine.NeedSwitchScene = false;
			}

			if (engine.CheckClicked(BaseNames.MenuNewGameBackground))
			{
				engine.LastClicked.Clear();

				engine.SwitchScene(new SessionScene());
				engine.SessionClock = new SFML.System.Clock();
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

				Settings.PrevResolutionIndex = Settings.ResolutionIndex;
				Settings.PrevGameSizeIndex = Settings.GameSizeIndex;

				var oldWindow = engine.Renderer.Window;
				engine.Renderer = new Drawer(Settings.Width, Settings.Height, Settings.Name, Settings.IconPath);
				oldWindow.Close();
				engine.ResetSystems();

				engine.SwitchScene(new MenuScene());
			}

			if (engine.CheckClicked(BaseNames.MenuBackBackground))
			{
				engine.LastClicked.Clear();

				Settings.SwitchResolution(Settings.PrevResolutionIndex);
				Settings.SwitchGameSize(Settings.PrevGameSizeIndex);

				engine.SwitchScene(new MenuScene());
			}

			if (engine.CheckClicked(BaseNames.MenuExitToMenuBackground))
			{
				engine.LastClicked.Clear();

				engine.SwitchScene(new MenuScene());
			}

			if (engine.CheckClicked(BaseNames.MenuExitBackground))
			{
				engine.Stop();
			}
		}
	}
}
