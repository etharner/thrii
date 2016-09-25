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

			var textFrame = Spawner.CreateTextFrame(
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
				Settings.Width - Layout.SessionBackgroundMargin * 2, Settings.Height - Layout.SessionBackgroundMargin * 2, 
				Layout.SessionBackgroundMargin, Layout.SessionBackgroundMargin, Color.Transparent, 2, Color.White
			));
		}
	}
}
