using System.Collections.Generic;
using SFML.Window;

namespace thrii
{
	interface ISystem
	{
		string NodeType { get; }

		void GetNodes();
		void Update();	
	}

	public class RenderSystem : ISystem
	{
		public string NodeType { get; }
		List<Node> targets;
		Drawer drawer;
		Engine engine;

		public RenderSystem(Settings settings, Engine e)
		{
			NodeType = "RenderNode";
			drawer = new Drawer(settings.Width, settings.Height, settings.Name, settings.IconPath, e);
			engine = e;
		}

		public void GetNodes()
		{
			targets = engine.GetNodeList(NodeType);
		}

		public void Render()
		{
			drawer.DrawLoop();	
		}

		public void Update() 
		{
			GetNodes();
			foreach (var target in targets)
			{
				var renderTarget = ((RenderNode)target);
				renderTarget.Display.DisplayObject.Position = new SFML.System.Vector2f(renderTarget.Position.X, renderTarget.Position.Y);
				drawer.Draw(renderTarget.Display.DisplayObject);
			}
		}
	}
}
