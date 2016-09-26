using SFML.Window;
using SFML.System;

namespace thrii
{
	public class Input
	{
		Engine engine;
		Window window;

		public Input(Engine e, Window w) 
		{
			engine = e;
			window = w;
		}

		public void CheckInput()
		{
			if (Mouse.IsButtonPressed(Mouse.Button.Left))
			{
				Vector2i pos = Mouse.GetPosition(window);

				if (CheckMenuItemPressed(pos))
				{
					engine.SwitchScene(new SessionScene());
				}
			}
		}

		bool CheckMenuItemPressed(Vector2i pos)
		{
			if (pos.X >= Layout.MenuNewGameX && pos.X <= Layout.MenuNewGameX + Layout.MenuNewGameWidth)
			{
				if (pos.Y >= Layout.MenuNewGameY && pos.Y <= Layout.MenuNewGameY + Layout.MenuNewGameHeight)
				{
					return true;
				}
			}

			return false;
		}
	}
}
