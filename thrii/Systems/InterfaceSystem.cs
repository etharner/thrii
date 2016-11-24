using System.Collections.Generic;

namespace thrii
{
	public class InterfaceSystem : System
	{
		List<Node> interfaceNodes;
		bool progressRaised;

		public InterfaceSystem(Engine e) : base(e)
		{
			interfaceNodes = new List<Node>();
			progressRaised = false;
		}

		protected override void GetNodes()
		{
			interfaceNodes = engine.GetNodeList("InterfaceNode");
		}

		public override void Update() {
			GetNodes();

			foreach (InterfaceNode target in interfaceNodes)
			{
				if (engine.CheckClicked(BaseNames.MenuOptionResolutionLeftButton) &&
				   target.Entity.Name.BaseName == BaseNames.MenuOptionResolutionText)
				{
					engine.LastClicked.Clear();
					if (Settings.ResolutionIndex > 0)
					{
						Settings.SwitchSettings(SettingsEntry.Resolution, Settings.ResolutionIndex - 1);
						target.Interface.Text = Settings.Width + "x" + Settings.Height;
					}
				}

				if (engine.CheckClicked(BaseNames.MenuOptionResolutionRightButton) &&
				    target.Entity.Name.BaseName == BaseNames.MenuOptionResolutionText)
				{
					engine.LastClicked.Clear();
					if (Settings.ResolutionIndex < Settings.SupportedResolutions.Count - 1)
					{
						Settings.SwitchSettings(SettingsEntry.Resolution, Settings.ResolutionIndex + 1);
						target.Interface.Text = Settings.Width + "x" + Settings.Height;
					}
				}

				if (engine.CheckClicked(BaseNames.MenuOptionGameSizeLeftButton) &&
				    target.Entity.Name.BaseName == BaseNames.MenuOptionGameSizeText)
				{
					engine.LastClicked.Clear();
					if (Settings.GameSizeIndex > 0)
					{
						Settings.SwitchSettings(SettingsEntry.GameSize, Settings.GameSizeIndex - 1);
						target.Interface.Text = Settings.GameSize.ToString();
					}
				}

				if (engine.CheckClicked(BaseNames.MenuOptionGameSizeRightButton) &&
				    target.Entity.Name.BaseName == BaseNames.MenuOptionGameSizeText)
				{
					engine.LastClicked.Clear();
					if (Settings.GameSizeIndex < Settings.SupportedGameSizes.Count - 1)
					{
						Settings.SwitchSettings(SettingsEntry.GameSize, Settings.GameSizeIndex + 1);
						target.Interface.Text = Settings.GameSize.ToString();
					}
				}

				if (engine.CheckClicked(BaseNames.MenuOptionVolumeLeftButton) &&
					target.Entity.Name.BaseName == BaseNames.MenuOptionVolumeText)
				{
					engine.LastClicked.Clear();
					if (Settings.VolumeIndex > 0)
					{
						Settings.SwitchSettings(SettingsEntry.Volume, Settings.VolumeIndex - 1);
						target.Interface.Text = Settings.Volume.ToString();
					}
				}

				if (engine.CheckClicked(BaseNames.MenuOptionVolumeRightButton) &&
					target.Entity.Name.BaseName == BaseNames.MenuOptionVolumeText)
				{
					engine.LastClicked.Clear();
					if (Settings.VolumeIndex < Settings.SupportedVolumes.Count - 1)
					{
						Settings.SwitchSettings(SettingsEntry.Volume, Settings.VolumeIndex + 1);
						target.Interface.Text = Settings.Volume.ToString();
					}
				}


				if (target.Entity.Name.BaseName == BaseNames.HudTimeText)
				{
					var time = (int)(engine.CurrentLevel.Time + 1 - engine.SessionClock.ElapsedTime.AsSeconds());
					target.Interface.Text = time.ToString();
					if (time == -1)
					{
						engine.NeedSwitchScene = true;
						engine.GameState = GameState.GameOver;
					}
				}

				if (target.Entity.Name.BaseName == BaseNames.HudScoreText)
				{
					target.Interface.Text = engine.Score.ToString();
				}

				if (target.Entity.Name.BaseName == BaseNames.HudGoalText)
				{
					target.Interface.Text = engine.CurrentLevel.Goal.ToString();
				}

				if (target.Entity.Name.BaseName == BaseNames.GameOver)
				{
					if (engine.Score >= engine.CurrentLevel.Goal)
					{
						target.Interface.Text = "You win!";
						if (!progressRaised && engine.CurrentLevel != Levels.LevelsList[0] &&
						    Settings.GetProgress() <= Levels.LevelsList.FindIndex(l => l == engine.CurrentLevel)
						   )
						{
							Settings.SetProgress(Settings.GetProgress() + 1);
							progressRaised = true;
						}
					}
					else
					{
						target.Interface.Text = "You lose";
					}
				}

				if (target.Entity.Name.BaseName == BaseNames.MenuScore)
				{
					target.Interface.Text = "Score: " + engine.Score;
				}
			}
		}
	}
}
