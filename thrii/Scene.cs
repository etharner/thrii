using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace thrii
{
	public class Scene
	{
		public List<Entity> EntityList { get; }

		public Scene()
		{
			EntityList = new List<Entity>();
		}

		public void AddEntity(Entity e)
		{
			EntityList.Add(e);
		}

		public void RemoveEntity(Entity e)
		{
			EntityList.Remove(e);
		}
	}

	public class MenuScene : Scene
	{
		public MenuScene()
		{
			EntityList.Add(Spawner.CreateBackground(Settings.Width, Settings.Height, 0, 0, Colors.BgColor, true));
			EntityList.Add(Spawner.CreateGameSprite());

			EntityList.AddRange(Spawner.CreateMenuEntry(BaseNames.MenuNewGame));
			EntityList.AddRange(Spawner.CreateMenuEntry(BaseNames.MenuSettings));
			EntityList.AddRange(Spawner.CreateMenuEntry(BaseNames.MenuExit));
		}
	}

	public class SettingsScene : Scene
	{
		public SettingsScene()
		{
			EntityList.Add(Spawner.CreateBackground(Settings.Width, Settings.Height, 0, 0, Colors.BgColor, true));

			EntityList.AddRange(Spawner.CreateOptionEntry(BaseNames.MenuOptionVolume));
			EntityList.AddRange(Spawner.CreateOptionEntry(BaseNames.MenuOptionResolution));
			EntityList.AddRange(Spawner.CreateOptionEntry(BaseNames.MenuOptionGameSize));

			EntityList.AddRange(Spawner.CreateMenuEntry(BaseNames.MenuApply));
			EntityList.AddRange(Spawner.CreateMenuEntry(BaseNames.MenuBack));
		}
	}

	public class LevelScene : Scene
	{
		public LevelScene()
		{
			EntityList.Add(Spawner.CreateBackground(Settings.Width, Settings.Height, 0, 0, Colors.BgColor, true));

			int currentLevel = Settings.GetProgress();

			for (var i = 0; i < 3; i++)
			{
				for (var j = 0; j < 6; j++)
				{
					int level = i * 6 + j + 1;

					if (level <= currentLevel)
					{
						EntityList.AddRange(Spawner.CreateTextFrame(
							Layout.HudLevelWidth, Layout.HudLevelHeight,
							Layout.HudLevelDistance + (Layout.HudLevelWidth + Layout.HudLevelDistance / 4) * j,
							Layout.HudLevelDistance + (Layout.HudLevelHeight + Layout.HudLevelDistance / 4) * i,
							level > 9 ? Layout.HudLevelDistance + (Layout.HudLevelWidth + Layout.HudLevelDistance / 3) * j :
							Layout.HudLevelDistance + Layout.HudLevelWidth / 3 +
							(Layout.HudLevelWidth + Layout.HudLevelDistance / 5) * j,
							Layout.HudLevelDistance + (Layout.HudLevelHeight + Layout.HudLevelDistance / 3) * i,
							level.ToString(),
							Registrator.GenerateName(BaseNames.Level), null, (uint)Layout.FontSize * 2,
							i == 0 ? LevelDifficulty.Easy : i == 1 ? LevelDifficulty.Medium : LevelDifficulty.Hard
						));
					}
					else
					{
						EntityList.AddRange(Spawner.CreateTextFrame(
							Layout.HudLevelWidth, Layout.HudLevelHeight,
							Layout.HudLevelDistance + (Layout.HudLevelWidth + Layout.HudLevelDistance / 4) * j,
							Layout.HudLevelDistance + (Layout.HudLevelHeight + Layout.HudLevelDistance / 4) * i,
							level > 9 ? Layout.HudLevelDistance + (Layout.HudLevelWidth + Layout.HudLevelDistance / 3) * j :
							Layout.HudLevelDistance + Layout.HudLevelWidth / 3 +
							(Layout.HudLevelWidth + Layout.HudLevelDistance / 5) * j,
							Layout.HudLevelDistance + (Layout.HudLevelHeight + Layout.HudLevelDistance / 3) * i,
							level.ToString(),
							null, null, (uint)Layout.FontSize * 2, null
						));
					}
				}
			}

			EntityList.AddRange(Spawner.CreateMenuEntry(BaseNames.LevelExitToMenu));
			EntityList.AddRange(Spawner.CreateMenuEntry(BaseNames.LevelNewGame));
		}
	}

	public class SessionScene : Scene
	{
		public SessionScene()
		{
			EntityList.Add(Spawner.CreateBackground(Settings.Width, Settings.Height, 0, 0, Colors.BgColor, true));
			EntityList.Add(Spawner.CreateBackground(
				Layout.SessionBackgroundWidth,
				Layout.SessionBackgroundHeight, 
				Layout.SessionBackgroundX,
				Layout.SessionBackgroundY, 
				Color.Transparent, true, 3, 
				Color.White
			));
			EntityList.AddRange(Spawner.CreateHud(BaseNames.HudTime));
			EntityList.AddRange(Spawner.CreateHud(BaseNames.HudScore));
			EntityList.AddRange(Spawner.CreateHud(BaseNames.HudGoal));

			var rnd = new Random();
			for (int i = 0; i < Settings.GameSize; i++)
			{
				for (int j = 0; j < Settings.GameSize; j++)
				{
					var gem = new GemView((Gem)Enum.GetValues(typeof(Gem)).GetValue(rnd.Next(0, 5)));
					EntityList.Add(Spawner.CreateGem(
						gem, 
						Layout.SessionBackgroundX + Layout.GemMargin + Layout.GemDistance * j, 
						Layout.SessionBackgroundY + Layout.GemMargin + Layout.GemDistance * i
					));
				}
			}
		}
	}

	public class GameOverScene : Scene
	{
		public GameOverScene(int score)
		{
			EntityList.Add(Spawner.CreateBackground(Settings.Width, Settings.Height, 0, 0, Colors.BgColor, true));

			EntityList.Add(Spawner.CreateLabel(
				Layout.MenuGameOverX, Layout.MenuGameOverY, "Game Over", BaseNames.GameOver
			));
			EntityList.Add(Spawner.CreateLabel(
				Layout.MenuScoreX, Layout.MenuScoreY, "Score: " + score, BaseNames.MenuScore
			));

			EntityList.AddRange(Spawner.CreateMenuEntry(BaseNames.MenuNewGame));
			EntityList.AddRange(Spawner.CreateMenuEntry(BaseNames.MenuExitToMenu));
		}
	}
}
