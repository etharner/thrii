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
		}

		protected override void GetNodes()
		{
			collisionNodes = engine.GetNodeList("CollisionNode");
			engine.Renderer.Window.MouseButtonPressed += OnMouseLeftClick;
		}

		Name SearchClicked(Vector2i pos) {
			foreach (CollisionNode target in collisionNodes)
			{
				if (target.Collision.BoundingBox.Contains(pos.X, pos.Y))
				{
					return target.Entity.Name;
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
			}
		}
		public override void Update() 
		{
			GetNodes();
		}
	}
}