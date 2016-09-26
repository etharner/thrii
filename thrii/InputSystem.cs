using System.Collections.Generic;
using SFML.Window;
using SFML.System;

namespace thrii
{
	public class InputSystem : System
	{
		Window window;

		public InputSystem(Engine e, Window w) : base(e)
		{
			nodeType = "CollisionNode";
			engine = e;
			window = w;
		}

		bool CheckMenuItemPressed(Vector2i pos)
		{
			foreach (CollisionNode target in targets)
			{
				if (target.Collision.boundingBox.Contains(pos.X, pos.Y) && 
				    target.Entity.Name.BaseName == BaseNames.MenuNewGameBackground)
				{
					return true;
				}
			}

			return false;
		}

		public override void Update() 
		{
			GetNodes();
			if (Mouse.IsButtonPressed(Mouse.Button.Left))
			{
				Vector2i pos = Mouse.GetPosition(window);

				if (CheckMenuItemPressed(pos))
				{
					engine.SwitchScene(new SessionScene());
				}
			}
		}
	}
}