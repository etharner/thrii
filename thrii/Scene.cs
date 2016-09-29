using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace thrii
{
	public class Scene
	{
		public List<Entity> EntityList { get; }
		protected Layout layout;

		public Scene()
		{
			EntityList = new List<Entity>();
			layout = new Layout();
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
			EntityList.Add(Spawner.CreateBackground(layout, Settings.Width, Settings.Height, 0, 0, Colors.BgColor, true));
			EntityList.Add(Spawner.CreateGameSprite(layout));

			EntityList.AddRange(Spawner.CreateMenuEntry(layout, BaseNames.MenuNewGame));
			EntityList.AddRange(Spawner.CreateMenuEntry(layout, BaseNames.MenuSettings));
			EntityList.AddRange(Spawner.CreateMenuEntry(layout, BaseNames.MenuExit));
		}
	}

	public class SettingsScene : Scene
	{
		public SettingsScene()
		{
			EntityList.Add(Spawner.CreateBackground(layout, Settings.Width, Settings.Height, 0, 0, Colors.BgColor, true));
			EntityList.Add(Spawner.CreateGameSprite(layout));

			EntityList.AddRange(Spawner.CreateOptionEntry(layout, BaseNames.MenuOptionResolution));
			EntityList.AddRange(Spawner.CreateOptionEntry(layout, BaseNames.MenuOptionGameSize));

			EntityList.AddRange(Spawner.CreateMenuEntry(layout, BaseNames.MenuApply));
			EntityList.AddRange(Spawner.CreateMenuEntry(layout, BaseNames.MenuBack));
		}
	}

	public class SessionScene : Scene
	{
		public SessionScene()
		{
			EntityList.Add(Spawner.CreateBackground(layout, Settings.Width, Settings.Height, 0, 0, Colors.BgColor, true));
			EntityList.Add(Spawner.CreateBackground(
				layout,
				layout.SessionBackgroundWidth,
				layout.SessionBackgroundHeight, 
				layout.SessionBackgroundX,
				layout.SessionBackgroundY, 
				Color.Transparent, true, 2, 
				Color.White
			));
			EntityList.AddRange(Spawner.CreateHud(layout, BaseNames.HudTime));
			EntityList.AddRange(Spawner.CreateHud(layout, BaseNames.HudScore));


			var rnd = new Random();
			for (uint i = 0; i < Settings.GameSize; i++)
			{
				for (uint j = 0; j < Settings.GameSize; j++)
				{
					Shape gem = new GemView((Gems)Enum.GetValues(typeof(Gems)).GetValue(rnd.Next(0, 5)), layout).GemShape;
					EntityList.Add(Spawner.CreateGem(
						layout,
						gem, 
						layout.SessionBackgroundX + layout.GemMargin + layout.GemDistance * j, 
						layout.SessionBackgroundY + layout.GemMargin + layout.GemDistance * i
					));
				}
			}
		}
	}

	public class GameOverScene : Scene
	{
		public GameOverScene()
		{
			EntityList.Add(Spawner.CreateBackground(layout, Settings.Width, Settings.Height, 0, 0, Colors.BgColor, true));
			EntityList.Add(Spawner.CreateLabel(
				layout, layout.MenuGameOverX, layout.MenuGameOverY, "Game Over", BaseNames.Text
			));
			EntityList.Add(Spawner.CreateLabel(
				layout, layout.MenuScoreX, layout.MenuScoreY, "Score: ", BaseNames.MenuScore
			));

			EntityList.AddRange(Spawner.CreateMenuEntry(layout, BaseNames.MenuNewGame));
			EntityList.AddRange(Spawner.CreateMenuEntry(layout, BaseNames.MenuExitToMenu));
		}
	}
}
