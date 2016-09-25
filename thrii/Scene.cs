using System.Collections.Generic;

namespace thrii
{
	public class Scene
	{
		List<Entity> EntityList { get; }

		public Scene()
		{
			EntityList = new List<Entity>();
		}

		public void AddEntity(Entity e)
		{
			EntityList.Add(e);
		}

		public void RemoveEntity(Entity e)
		{
			EntityList.Remove(e);
		}
	}
}
