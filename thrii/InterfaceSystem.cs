using System.Collections.Generic;

namespace thrii
{
	public class InterfaceSystem : System
	{
		List<Node> interfaceNodes;

		public InterfaceSystem(Engine e) : base(e)
		{
			interfaceNodes = new List<Node>();
		}

		protected override void GetNodes()
		{
			interfaceNodes = engine.GetNodeList("InterfaceNode");
		}

		public override void Update() {
			GetNodes();

			foreach (InterfaceNode target in interfaceNodes)
			{
				if (engine.CheckClicked(BaseNames.MenuOptionResolutionLeftButton) &&
				   target.Entity.Name.BaseName == BaseNames.MenuOptionResolutionText)
				{
					engine.LastClicked.Clear();
					if (Settings.ResolutionIndex > 0)
					{
						Settings.SwitchResolution(Settings.ResolutionIndex - 1);
						target.Interface.Text = Settings.Width + "x" + Settings.Height;
					}
				}

				if (engine.CheckClicked(BaseNames.MenuOptionResolutionRightButton) &&
				    target.Entity.Name.BaseName == BaseNames.MenuOptionResolutionText)
				{
					engine.LastClicked.Clear();
					if (Settings.ResolutionIndex < Settings.SupportedResolutions.Count - 1)
					{
						Settings.SwitchResolution(Settings.ResolutionIndex + 1);
						target.Interface.Text = Settings.Width + "x" + Settings.Height;
					}
				}

				if (engine.CheckClicked(BaseNames.MenuOptionGameSizeLeftButton) &&
				    target.Entity.Name.BaseName == BaseNames.MenuOptionGameSizeText)
				{
					engine.LastClicked.Clear();
					if (Settings.GameSizeIndex > 0)
					{
						Settings.SwitchGameSize(Settings.GameSizeIndex - 1);
						target.Interface.Text = Settings.GameSize.ToString();
					}
				}

				if (engine.CheckClicked(BaseNames.MenuOptionGameSizeRightButton) &&
				    target.Entity.Name.BaseName == BaseNames.MenuOptionGameSizeText)
				{
					engine.LastClicked.Clear();
					if (Settings.GameSizeIndex < Settings.SupportedGameSizes.Count - 1)
					{
						Settings.SwitchGameSize(Settings.GameSizeIndex + 1);
						target.Interface.Text = Settings.GameSize.ToString();
					}
				}
			}
		}
	}
}
