using System.Collections.Generic;
using SFML.System;
using SFML.Graphics;

namespace thrii
{
	public class AnimationSystem : System
	{
		List<Node> animationNodes;

		public AnimationSystem(Engine e) : base(e)
		{
			animationNodes = new List<Node>();
		}

		protected override void GetNodes()
		{
			animationNodes = engine.GetNodeList("AnimationNode");
		} 

		public override void Update()
		{
			GetNodes();

			engine.AnimationEnded = true;
			foreach (AnimationNode target in animationNodes)
			{
				if (target.Position.X < target.Animation.X)
				{
					engine.AnimationEnded = false;
					target.Position.X += engine.Time * target.Animation.Speed; 
					if (target.Position.X > target.Animation.X)
					{
						target.Position.X = target.Animation.X;
						target.Animation.Speed = Engine.GameSpeed;
					}
				}

				if (target.Position.X > target.Animation.X)
				{
					engine.AnimationEnded = false;
					target.Position.X -= engine.Time * target.Animation.Speed; 
					if (target.Position.X < target.Animation.X)
					{
						target.Position.X = target.Animation.X;
						target.Animation.Speed = Engine.GameSpeed;
					}
				}

				if (target.Position.Y < target.Animation.Y)
				{
					engine.AnimationEnded = false;
					target.Position.Y += engine.Time * target.Animation.Speed; 
					if (target.Position.Y > target.Animation.Y)
					{
						target.Position.Y = target.Animation.Y;
						target.Animation.Speed = Engine.GameSpeed;
					}
				}

				if (target.Position.Y > target.Animation.Y)
				{
					engine.AnimationEnded = false;
					target.Position.Y -= engine.Time * target.Animation.Speed; 
					if (target.Position.Y < target.Animation.Y)
					{
						target.Position.Y = target.Animation.Y;
						target.Animation.Speed = Engine.GameSpeed;

					}
				}

				if (target.Display.DisplayObject.Scale.X > target.Animation.Scale.X &&
				   	target.Display.DisplayObject.Scale.Y > target.Animation.Scale.Y)
				{
					engine.AnimationEnded = false;
					target.Display.DisplayObject.Scale = new Vector2f(
						target.Display.DisplayObject.Scale.X - 0.1f,
						target.Display.DisplayObject.Scale.Y - 0.1f
					);
				}

				if (engine.CheckClicked(target.Entity.Name))
				{
					//engine.AnimationEnded = false;
					target.Position.Rotation += engine.Time * target.Animation.Speed / 2;
					if (target.Position.Rotation >= 360)
					{
						target.Position.Rotation = 0;
					}
				}
				else if (target.Entity.Name.BaseName == BaseNames.Gem)
				{
					target.Position.Rotation = 0;
					target.Animation.Speed = Engine.GameSpeed;
				}

				if (target.Entity.Name.BaseName == BaseNames.Destroyer)
				{
					engine.AnimationEnded = true;
				}
			}
		}
	}
}
