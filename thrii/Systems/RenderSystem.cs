﻿using System.Collections.Generic;
using SFML.Graphics;

namespace thrii
{
	public class RenderSystem : System
	{
		List<Node> interfaceNodes;
		List<Node> renderNodes;

		public RenderSystem(Engine e) : base(e)
		{
			interfaceNodes = new List<Node>();
			renderNodes = new List<Node>();
		}

		protected override void GetNodes()
		{
			interfaceNodes = engine.GetNodeList("InterfaceNode");
			renderNodes = engine.GetNodeList("RenderNode");
		}

		public override void Update() 
		{
			GetNodes();

			var interfaceTargets = new Dictionary<Name, string>();

			foreach (InterfaceNode target in interfaceNodes)
			{
				interfaceTargets.Add(target.Entity.Name, target.Interface.Text);
			}

			foreach (RenderNode target in renderNodes)
			{
				target.Display.DisplayObject.Position = new SFML.System.Vector2f(target.Position.X, target.Position.Y);
				target.Display.DisplayObject.Rotation = target.Position.Rotation;
				if (interfaceTargets.ContainsKey(target.Entity.Name))
				{
					((Text)target.Display.DisplayObject).DisplayedString = interfaceTargets[target.Entity.Name];
				}

				CollisionComponent collision = (CollisionComponent)target.Entity.GetComponent("CollisionComponent");
				if (collision != null)
				{
					Shape shape = (Shape)(target.Display.DisplayObject);

					if (target.Entity.Name.BaseName == BaseNames.Gem || 
					   	target.Entity.Name.BaseName == BaseNames.Destroyer
					   )
					{
						target.Display.DisplayObject.Position = new SFML.System.Vector2f(
							target.Position.X + shape.GetLocalBounds().Width / 2.0f, 
							target.Position.Y + shape.GetLocalBounds().Height / 2.0f
						);

						if (engine.CheckClicked(target.Entity.Name))
						{
							shape.OutlineColor = Colors.GemSelectedOutlineColor;
						}
						else
						{
							shape.OutlineColor = Colors.GemOutlineColor;
						}
					}

					collision.BoundingBox = shape.GetGlobalBounds();
				}

				engine.Renderer.Draw(target.Display.DisplayObject);
			}
		}
	}
}
