using System;
using System.Collections.Generic;

namespace thrii
{
	public class Engine
	{
		List<System> systemList;
		Dictionary<string, List<Node>> nodes;

		public Engine()
		{
			systemList = new List<System>();
			var renderSystem = new RenderSystem(this);
			AddSystem(renderSystem);

			nodes = new Dictionary<string, List<Node>>();

			SwitchScene(new MenuScene());

			renderSystem.Render();
		}

		void AddSystem(System system)
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

		void RemoveNode(Node node, string nodeClass)
		{
			nodes[nodeClass].Remove(node);
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
					((Node)currentNode).Entity = entity;
					AddNode((Node)currentNode);
				}
			}
		}

		void RemoveEntity(Name entityName)
		{
			foreach (var nodeClass in nodes.Keys)
			{
				foreach (var node in nodes[nodeClass])
				{
					if (node.Entity.Name == entityName)
					{
						RemoveNode(node, nodeClass);
					}
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
			foreach (System s in systemList)
			{
				s.Update();
			}
		}
	}
}
