using System;
using System.Collections.Generic;

namespace thrii
{
	public class Engine
	{
		List<ISystem> systemList;
		Dictionary<string, List<Node>> nodes;

		public Engine()
		{
			systemList = new List<ISystem>();
			var renderSystem = new RenderSystem(this);
			AddSystem(renderSystem);

			nodes = new Dictionary<string, List<Node>>();

			SwitchScene(new MenuScene());

			renderSystem.Render();
		}

		void AddSystem(ISystem system)
		{
			systemList.Add(system);
		}

		void AddNode(Node node)
		{
			string nodeClass = node.GetType().Name;
			if (!nodes.ContainsKey(nodeClass))
			{
				nodes[nodeClass] = new List<Node>() { node };
			}
			else
			{
				nodes[nodeClass].Add(node);
			}
		}

		void AddEntity(Entity entity)
		{
			foreach (var nodeClass in NodeComponents.Relations.Keys)
			{
				var currentNode = Activator.CreateInstance(Type.GetType(GetType().Namespace + "." + nodeClass));

				bool fullNode = true;
				foreach (var componentClass in NodeComponents.Relations[nodeClass])
				{
					var currentComponent = entity.GetComponent(componentClass.Key);
					if (currentComponent == null)
					{
						fullNode = false;
						break;
					}
					currentNode.GetType().GetField(componentClass.Value).SetValue(currentNode, currentComponent);
				}

				if (fullNode)
				{
					AddNode((Node)currentNode);
				}
			}
		}

		public void SwitchScene(Scene scene) 
		{
			nodes.Clear();
			foreach (var entity in scene.EntityList)
			{
				AddEntity(entity);
			}
		}

		public List<Node> GetNodeList(string nodeClass)
		{
			return nodes[nodeClass];
		}

		public void Start()
		{
			//Update();
		}

		public void Update() 
		{
			foreach (ISystem s in systemList)
			{
				s.Update();
			}
		}
	}
}
