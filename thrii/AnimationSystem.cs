using System.Collections.Generic;
using SFML.System;
using SFML.Graphics;

namespace thrii
{
	public class AnimationSystem : System
	{
		List<Node> animationNodes;
		Layout layout;

		public AnimationSystem(Engine e) : base(e)
		{
			animationNodes = new List<Node>();
			layout = new Layout();
		}

		protected override void GetNodes()
		{
			animationNodes = engine.GetNodeList("AnimationNode");
		} 

		public override void Update()
		{
			GetNodes();

			foreach (AnimationNode target in animationNodes)
			{
				var positionComponent = (PositionComponent)target.Entity.GetComponent("PositionComponent");

				if (positionComponent.X < target.Animation.X)
				{
					positionComponent.X += engine.Time * 0.25f; 
				}

				if (positionComponent.X > target.Animation.X)
				{
					positionComponent.X -= engine.Time * 0.25f; 
				}

				if (positionComponent.Y < target.Animation.Y)
				{
					positionComponent.Y += engine.Time * 0.25f; 
				}

				if (positionComponent.Y > target.Animation.Y)
				{
					positionComponent.Y -= engine.Time * 0.25f; 
				}

				if (engine.CheckClicked(target.Entity.Name))
				{
					positionComponent.Rotation += engine.Time * 0.25f;
				}
				else
				{
					positionComponent.Rotation = 0;
				}
			}
		}
	}
}
