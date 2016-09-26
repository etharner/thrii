using System.Collections.Generic;

namespace thrii
{
	public class RenderSystem : System
	{
		public Drawer Drawer { get; set; }

		public RenderSystem(Engine e) : base(e)
		{
			nodeType = "RenderNode";
			Drawer = new Drawer(Settings.Width, Settings.Height, Settings.Name, Settings.IconPath, e);
		}

		public void Render()
		{
			Drawer.DrawLoop();	
		}

		public override void Update() 
		{
			GetNodes();
			foreach (RenderNode target in targets)
			{
				var renderTarget = target;
				renderTarget.Display.DisplayObject.Position = new SFML.System.Vector2f(renderTarget.Position.X, renderTarget.Position.Y);
				Drawer.Draw(renderTarget.Display.DisplayObject);
			}
		}
	}
}
