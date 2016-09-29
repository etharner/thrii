using System;
using System.Collections.Generic;
using SFML.System;

namespace thrii
{
	public class Engine
	{
		List<System> systemList;
		Dictionary<string, List<Node>> nodes;
		public List<Name> LastClicked { get; set; }
		public Drawer Renderer;
		public Clock GlobalClock;
		public Clock SessionClock;
		public float Time;
		public GameState GameState;
		public bool NeedSwitchScene;

		public Engine()
		{
			Renderer = new Drawer(Settings.Width, Settings.Height, Settings.Name, Settings.IconPath);

			ResetSystems();

			nodes = new Dictionary<string, List<Node>>();

			LastClicked = new List<Name>();

			GlobalClock = new Clock();

			GameState = GameState.MENU;

			NeedSwitchScene = true;

			Start();
		}

		void AddSystem(System system, SystemPriority priority)
		{
			systemList.Insert((int)priority, system);
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

		public void ResetSystems() {
			systemList = new List<System>(Enum.GetNames(typeof(SystemPriority)).Length);

			AddSystem(new InputSystem(this), SystemPriority.Input);
			AddSystem(new InterfaceSystem(this), SystemPriority.Interface);
			AddSystem(new SceneSystem(this), SystemPriority.Scene);
			AddSystem(new GemSystem(this), SystemPriority.Gem);
			AddSystem(new AnimationSystem(this), SystemPriority.Animation);
			AddSystem(new RenderSystem(this), SystemPriority.Render);
		}

		public void SwitchScene(Scene scene) 
		{
			nodes.Clear();
			foreach (var entity in scene.EntityList)
			{
				AddEntity(entity);
			}
			scene = null;
		}

		public List<Node> GetNodeList(string nodeClass)
		{
			if (nodes.ContainsKey(nodeClass))
			{
				return nodes[nodeClass];
			}

			return new List<Node>();
		}

		public bool CheckClicked(BaseNames baseName)
		{
			return LastClicked.Exists(n => n.BaseName == baseName);
		}

		public bool CheckClicked(Name name)
		{
			return LastClicked.Exists(n => n == name);
		}

		public void Start()
		{
			while (Renderer.Window.IsOpen)
			{
				Renderer.Window.DispatchEvents();

				Time = GlobalClock.ElapsedTime.AsMicroseconds() / 500;
				GlobalClock.Restart();

				Update();
				Renderer.Window.Display();
			}
		}

		public void Stop()
		{
			Renderer.Window.Close();
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
