using System;
using System.Collections.Generic;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace thrii
{
	public class InputSystem : System
	{
		List<Node> collisionNodes;

		public InputSystem(Engine e) : base(e)
		{
			collisionNodes = new List<Node>();

			if (e.Renderer.JustCreated)
			{
				engine.Renderer.Window.MouseButtonPressed += OnMouseLeftClick;
				engine.Renderer.Window.KeyPressed += OnEscapeClick;

				e.Renderer.JustCreated = false;
			}
		}

		protected override void GetNodes()
		{
			collisionNodes = engine.GetNodeList("CollisionNode");
		}

		Name SearchClicked(Vector2i pos) {
			GetNodes();
			foreach (CollisionNode target in collisionNodes)
			{
				if (target.Collision.BoundingBox.Contains(pos.X, pos.Y))
				{
					if (target.Entity.Name.BaseName != BaseNames.Destroyer)
					{
						return target.Entity.Name;
					}
				}
			}

			return null;
		}

		void OnMouseLeftClick(object sender, EventArgs e)
		{
			if (Mouse.IsButtonPressed(Mouse.Button.Left))
			{
				Vector2i pos = Mouse.GetPosition(engine.Renderer.Window);

				Name clicked = SearchClicked(pos);
				if (clicked != null)
				{
					engine.LastClicked.Add(clicked);
				}
				else
				{
					engine.LastClicked.Clear();
				}
			}
		}

		void OnEscapeClick(object sender, EventArgs e)
		{
			if (Keyboard.IsKeyPressed(Keyboard.Key.Escape) && engine.GameState == GameState.NewGame)
			{
				engine.NeedSwitchScene = true;
				engine.GameState = GameState.GameOver;
			}	
		}

		public override void Update() { }
	}
}