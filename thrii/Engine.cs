using System;
using System.Collections.Generic;
using SFML.System;

namespace thrii
{
	public class Engine
	{
		List<System> systemList;
		Dictionary<string, List<Node>> nodes;
		bool needRestart;

		public List<Name> RemoveList { get; set; }
		public List<Name> LastClicked { get; set; }
		public Drawer Renderer;
		public Clock GlobalClock;
		public Clock SessionClock;
		public float Time;
		public int Score;
		public LevelInfo CurrentLevel;
		public static float GameSpeed;
		public GameState GameState;
		public bool NeedSwitchScene;
		public List<string> Playlist;

		public bool AnimationEnded;

		public Engine()
		{
			Renderer = new Drawer(Settings.Width, Settings.Height, Settings.Name, Assets.Icon);

			ResetSystems();

			nodes = new Dictionary<string, List<Node>>();

			needRestart = false;

			RemoveList = new List<Name>();

			LastClicked = new List<Name>();

			GlobalClock = new Clock();

			Score = 0;

			CurrentLevel = Levels.LevelsList[0];

			ChangeGameSpeed();

			GameState = GameState.Menu;

			NeedSwitchScene = true;
			AnimationEnded = true;

			Playlist = new List<string>();

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
				nodes[nodeClass] = new List<Node> { node };
			}
			else
			{
				nodes[nodeClass].Add(node);
			}
		}

		public void AddEntity(Entity entity)
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

		public void RemoveEntity(Name entityName)
		{
			foreach (var nodeClass in nodes.Keys)
			{
				nodes[nodeClass].RemoveAll(n => n.Entity.Name == entityName);
			}
		}

		public void ResetSystems() {
			Layout.Update();
			Levels.Update();

			if (systemList != null)
			{
				SoundSystem soundSystem = (SoundSystem)systemList.Find(
					s => s.GetType().ToString() == GetType().Namespace + "." + "SoundSystem"
				);
				soundSystem.StopAll();
			}

			systemList = new List<System>(Enum.GetNames(typeof(SystemPriority)).Length);

			AddSystem(new InputSystem(this), SystemPriority.Input);
			AddSystem(new InterfaceSystem(this), SystemPriority.Interface);
			AddSystem(new SceneSystem(this), SystemPriority.Scene);
			AddSystem(new GemSystem(this), SystemPriority.Gem);
			AddSystem(new AnimationSystem(this), SystemPriority.Animation);		
			AddSystem(new RenderSystem(this), SystemPriority.Render);

			AddSystem(new SoundSystem(this), SystemPriority.Sound);

			ChangeGameSpeed();
			Score = 0;
			needRestart = true;
		}

		public void SwitchScene(Scene scene) 
		{
			nodes.Clear();
			Registrator.ClearNames();

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

		public void ChangeGameSpeed()
		{
			float ratio = (float)Settings.Width / 
			                             Settings.SupportedResolutions[Settings.SupportedResolutions.Count - 1].X;
			GameSpeed = 0.25f * ratio;
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
				if (needRestart)
				{
					needRestart = false;
					break;
				}
				s.Update();
			}

			foreach (Name n in RemoveList)
			{
				RemoveEntity(n);
			}
		}
	}
}
