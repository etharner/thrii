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
				Layout.MenuGameOverX, Layout.MenuGameOverY, "Game Over", BaseNames.Text
			));
			EntityList.Add(Spawner.CreateLabel(
				Layout.MenuScoreX, Layout.MenuScoreY, "Score: " + score, BaseNames.MenuScore
			));

			EntityList.AddRange(Spawner.CreateMenuEntry(BaseNames.MenuNewGame));
			EntityList.AddRange(Spawner.CreateMenuEntry(BaseNames.MenuExitToMenu));
		}
	}
}
