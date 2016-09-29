using System.Collections.Generic;

namespace thrii
{
	public static class NodeComponents
	{
		public static Dictionary<string, List<KeyValuePair<string, string>>> Relations = 
			new Dictionary<string, List<KeyValuePair<string, string>>>()
			{
				{ "RenderNode", new List<KeyValuePair<string, string>>() 
					{ 
						new KeyValuePair<string, string>("DisplayComponent", "Display"),
						new KeyValuePair<string, string>("PositionComponent", "Position"),
					}
				},
				{"MovementNode", new List<KeyValuePair<string, string>>() 
					{ 
						new KeyValuePair<string, string>("PositionComponent", "Position")
					}
				},
				{"AnimationNode", new List<KeyValuePair<string, string>>() 
					{ 
						new KeyValuePair<string, string>("AnimationComponent", "Animation")
					}
				},
				{ "CollisionNode", new List<KeyValuePair<string, string>>() 
					{ 
						new KeyValuePair<string, string>("CollisionComponent", "Collision")
					}
				},
				{ "InterfaceNode", new List<KeyValuePair<string, string>>() 
					{ 
						new KeyValuePair<string, string>("InterfaceComponent", "Interface")
					}
				}
			};
	}
}
