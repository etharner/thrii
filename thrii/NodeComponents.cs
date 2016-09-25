﻿using System.Collections.Generic;

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
						new KeyValuePair<string, string>("PositionComponent", "Position")
					}
				}
			};
	}
}
