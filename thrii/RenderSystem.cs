using System.Collections.Generic;

namespace thrii
{
	public class RenderSystem : ISystem
	{
		public string NodeType { get; }
		List<Node> targets;
		Drawer drawer;
		Engine engine;

		public RenderSystem(Engine e)
		{
			NodeType = "RenderNode";
			drawer = new Drawer(Settings.Width, Settings.Height, Settings.Name, Settings.IconPath, e);
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
