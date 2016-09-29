namespace thrii
{
	public class SceneSystem : System
	{
		public SceneSystem(Engine e) : base(e) {}

		public override void Update()
		{
			if (engine.CheckClicked(BaseNames.MenuNewGameBackground))
			{
				engine.LastClicked.Clear();
				engine.SwitchScene(new SessionScene());
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

				engine.SwitchScene(new MenuScene());

			}

			if (engine.CheckClicked(BaseNames.MenuBackBackground))
			{
				engine.LastClicked.Clear();

				Settings.SwitchResolution(Settings.PrevResolutionIndex);
				Settings.SwitchGameSize(Settings.PrevGameSizeIndex);

				engine.SwitchScene(new MenuScene());
			}

			if (engine.CheckClicked(BaseNames.MenuExitBackground))
			{
				engine.Stop();
			}
		}
	}
}
