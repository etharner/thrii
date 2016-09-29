using System.Collections.Generic;
using SFML.System;
using System;

namespace thrii
{
	public class GemSystem : System
	{
		List<Node> movementNodes;
		List<Vector2f> gemGrid;
		Layout layout;

		public GemSystem(Engine e) : base(e)
		{
			movementNodes = new List<Node>();
			gemGrid = new List<Vector2f>();
			layout = new Layout();

			for (var i = 0; i < Settings.GameSize; i++)
			{
				for (var j = 0; j < Settings.GameSize; j++)
				{
					gemGrid.Add(new Vector2f(
						layout.SessionBackgroundX + layout.GemMargin + layout.GemDistance * j,
						layout.SessionBackgroundY + layout.GemMargin + layout.GemDistance * i
					));
				}
			}
		}

		Vector2i GetGridPlace(Vector2f coords)
		{
			return new Vector2i(
				(int)((coords.X - layout.SessionBackgroundX - layout.GemMargin) / layout.GemDistance),
				(int)((coords.Y - layout.SessionBackgroundY - layout.GemMargin) / layout.GemDistance)
			);
		}

		void SwitchGems(List<Name> clickedGemsNames, List<MovementNode> clickedGems)
		{
			MovementNode first;
			MovementNode second;

			int firstClicked = 0;
			if (clickedGems[0].Entity.Name != clickedGemsNames[0])
			{
				firstClicked = 1;
			}

			first = clickedGems[firstClicked];
			second = clickedGems[1 - firstClicked];

			Vector2f newPosition = gemGrid[second.Entity.Name.Id - 1];
			var animationComponent = (AnimationComponent)first.Entity.GetComponent("AnimationComponent");
			animationComponent.X = second.Position.X;
			animationComponent.Y = second.Position.Y;

			newPosition = gemGrid[first.Entity.Name.Id - 1];
			animationComponent = (AnimationComponent)second.Entity.GetComponent("AnimationComponent");
			animationComponent.X = first.Position.X;
			animationComponent.Y = first.Position.Y;

			gemGrid[first.Entity.Name.Id - 1] = gemGrid[second.Entity.Name.Id - 1];
			gemGrid[second.Entity.Name.Id - 1] = newPosition;
		}

		protected override void GetNodes()
		{
			movementNodes = engine.GetNodeList("MovementNode");
		} 

		public override void Update()
		{
			GetNodes();

			List<Name> clickedGemsNames = new List<Name>();
			List<MovementNode> clickedGems = new List<MovementNode>();

			int gemsCount = 0;
			clickedGemsNames = engine.LastClicked.FindAll(n => n.BaseName == BaseNames.Gem);
			if (clickedGemsNames.Count == 2)
			{
				gemsCount = 2;
				clickedGems = new List<MovementNode>(gemsCount);
				engine.LastClicked.Clear();
			}

			foreach (MovementNode target in movementNodes)
			{
				Vector2f newPosition = new Vector2f(target.Position.X, target.Position.Y);

				if (gemsCount > 0 && clickedGemsNames.Contains(target.Entity.Name))
				{
					clickedGems.Add(target);
					gemsCount--;
				}
			}

			if (clickedGems.Count == 2)
			{
				SwitchGems(clickedGemsNames, clickedGems);
			}
		}
	}
}
