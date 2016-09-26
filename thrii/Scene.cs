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
			EntityList.Add(Spawner.CreateBackground(Settings.Width, Settings.Height, 0, 0, Colors.BgColor));

			var textFrame = Spawner.CreateMenuEntry(
				Layout.MenuNewGameWidth, Layout.MenuNewGameHeight, Layout.MenuNewGameX, Layout.MenuNewGameY, 
				Layout.MenuNewGameTextX, Layout.MenuNewGameTextY, "New Game"
			);
			foreach (var entity in textFrame)
			{
				EntityList.Add(entity);
			}
		}
	}

	public class SessionScene : Scene
	{
		public SessionScene()
		{
			EntityList.Add(Spawner.CreateBackground(Settings.Width, Settings.Height, 0, 0, Colors.BgColor));
			EntityList.Add(Spawner.CreateBackground(
				Layout.SessionBackgroundWidth,
				Layout.SessionBackgroundHeight, 
				Layout.SessionBackgroundX,
				Layout.SessionBackgroundY, 
				Color.Transparent, 2, 
				Color.White
			));


			var rnd = new Random();
			for (uint i = 0; i < Settings.GameSize; i++)
			{
				for (uint j = 0; j < Settings.GameSize; j++)
				{
					Shape gem = new GemView((Gems)Enum.GetValues(typeof(Gems)).GetValue(rnd.Next(0, 5))).GemShape;
					EntityList.Add(Spawner.CreateGem(
						gem, 
						Layout.SessionBackgroundX + Layout.GemMargin + Layout.GemDistance * i, 
						Layout.SessionBackgroundY + Layout.GemMargin + Layout.GemDistance * j
					));
				}
			}
		}
	}
}
