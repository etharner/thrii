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

			var newGameMenuEntry = Spawner.CreateMenuEntry(layout, BaseNames.MenuNewGame);
			var settingsMenuEntry = Spawner.CreateMenuEntry(layout, BaseNames.MenuSettings);
			var exitMenuEntry = Spawner.CreateMenuEntry(layout, BaseNames.MenuExit);

			newGameMenuEntry.AddRange(settingsMenuEntry);
			newGameMenuEntry.AddRange(exitMenuEntry);
			foreach (var entity in newGameMenuEntry)
			{
				EntityList.Add(entity);
			}
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


			var rnd = new Random();
			for (uint i = 0; i < Settings.GameSize; i++)
			{
				for (uint j = 0; j < Settings.GameSize; j++)
				{
					Shape gem = new GemView((Gems)Enum.GetValues(typeof(Gems)).GetValue(rnd.Next(0, 5)), layout).GemShape;
					EntityList.Add(Spawner.CreateGem(
						gem, 
						layout.SessionBackgroundX + layout.GemMargin + layout.GemDistance * i, 
						layout.SessionBackgroundY + layout.GemMargin + layout.GemDistance * j
					));
				}
			}
		}
	}

	public class SettingsScene : Scene
	{
		public SettingsScene()
		{
			EntityList.Add(Spawner.CreateBackground(layout, Settings.Width, Settings.Height, 0, 0, Colors.BgColor, true));
			EntityList.Add(Spawner.CreateGameSprite(layout));

			var resolutionMenuOptionEntry = Spawner.CreateOptionEntry(layout, BaseNames.MenuOptionResolution);
			var gameSizeMenuOptionEntry = Spawner.CreateOptionEntry(layout, BaseNames.MenuOptionGameSize);

			var applyMenuEntry = Spawner.CreateMenuEntry(layout, BaseNames.MenuApply);
			var backMenuEntry = Spawner.CreateMenuEntry(layout, BaseNames.MenuBack);

			resolutionMenuOptionEntry.AddRange(gameSizeMenuOptionEntry);
			resolutionMenuOptionEntry.AddRange(applyMenuEntry);
			resolutionMenuOptionEntry.AddRange(backMenuEntry);
			foreach (var entity in resolutionMenuOptionEntry)
			{
				EntityList.Add(entity);
			}
		}
	}
}
