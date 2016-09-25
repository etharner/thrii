using System.Collections.Generic;

namespace thrii
{
	public class Entity
	{
		Dictionary<string, object> componentList;

		public Entity()
		{
			componentList = new Dictionary<string, object>();
		}

		public void AddComponent(object component)
		{
			componentList[component.GetType().Name] = component;
		}

		public void RemoveComponent(string componentClass)
		{
			componentList.Remove(componentClass);
		}

		public object GetComponent(string componentClass)
		{
			if (componentList.ContainsKey(componentClass))
			{
				return componentList[componentClass];
			}

			return null;
		}
	}
}
