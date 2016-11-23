using System.Collections.Generic;
using SFML.System;
using SFML.Graphics;
using System;
using System.Web.UI;

namespace thrii
{
	public class Gotten
	{
		public bool Horizontal { get; set; }
		public bool Vertical { get; set; }

		public Gotten()
		{
			Horizontal = false;
			Vertical = false;
		}
	}

	public enum DestroyerDirection
	{
		Left,
		Right,
		Up,
		Down
	}

	public class DestroyerInfo
	{
		public FloatRect CurrentField { get; set; }
		public Vector2i FieldPosition { get; set; }
		public DestroyerDirection Direction { get; }

		public DestroyerInfo(DestroyerDirection direction)
		{
			CurrentField = new FloatRect();
			FieldPosition = new Vector2i(0, 0);
			Direction = direction;
		}
	}

	public class GemSystem : System
	{
		List<Node> gemNodes;
		List<Vector2f> coordGrid;
		List<int> idGrid;
		Gem[,] gemGrid;
		List<Pair> prevClicked;
		HashSet<int> needDelete;
		List<FloatRect> fieldGrid;
		Dictionary<Name, DestroyerInfo> destroyerGrid;
		int lastMoved;
		bool initCoords;
		bool gemsDestroying;

		static int minLineSize = 3;

		public GemSystem(Engine e) : base(e)
		{
			gemNodes = new List<Node>();
			coordGrid = new List<Vector2f>();
			idGrid = new List<int>();
			gemGrid = new Gem[Settings.GameSize, Settings.GameSize];
			prevClicked = new List<Pair>();
			needDelete = new HashSet<int>();
			fieldGrid = new List<FloatRect>();
			destroyerGrid = new Dictionary<Name, DestroyerInfo>();
			lastMoved = -1;
			initCoords = true;
			gemsDestroying = false;

			for (var i = 0; i < Settings.GameSize; i++)
			{
				for (var j = 0; j < Settings.GameSize; j++)
				{
					coordGrid.Add(new Vector2f(
						Layout.SessionBackgroundX + Layout.GemMargin + Layout.GemDistance * j,
						Layout.SessionBackgroundY + Layout.GemMargin + Layout.GemDistance * i
					));
					idGrid.Add(Settings.GameSize * i + j); 
					gemGrid[i, j] = Gem.Romb;
					fieldGrid.Add(new FloatRect(
						Layout.SessionBackgroundX + Layout.SessionBackgroundWidth / Settings.GameSize * j,
						Layout.SessionBackgroundY + Layout.SessionBackgroundHeight / Settings.GameSize * i,
						Layout.SessionBackgroundWidth / Settings.GameSize,
						Layout.SessionBackgroundHeight / Settings.GameSize
					));
				}
			}
		}

		Vector2i GetGridPlace(int id)
		{
			int place = idGrid.IndexOf(id);
			int x = place / Settings.GameSize;
			int y = place - x * Settings.GameSize;
				
			return new Vector2i(x, y);
		}

		List<Vector2i> GetNeighbours(int id)
		{
			var neighbours = new List<Vector2i>();
			Vector2i gridPlace = GetGridPlace(id);

			if (gridPlace.X > 0)
			{
				neighbours.Add(new Vector2i(gridPlace.X - 1, gridPlace.Y));
			}
			if (gridPlace.X < Settings.GameSize - 1)
			{
				neighbours.Add(new Vector2i(gridPlace.X + 1, gridPlace.Y));
			}
			if (gridPlace.Y > 0)
			{
				neighbours.Add(new Vector2i(gridPlace.X, gridPlace.Y - 1));
			}
			if (gridPlace.Y < Settings.GameSize - 1)
			{
				neighbours.Add(new Vector2i(gridPlace.X, gridPlace.Y + 1));
			}

			return neighbours;
		}

		bool AreNeighbours(int firstId, int secondId)
		{
			List<Vector2i> neighbours = GetNeighbours(firstId);
			foreach (var neighbour in neighbours)
			{
				if (idGrid.IndexOf(secondId) == neighbour.X * Settings.GameSize + neighbour.Y) {
					return true;
				}
			}

			return false;
		}

		void SwapGems(GemNode first, GemNode second, float speed, bool onlySecond = false)
		{
			int firstId = first.Entity.Name.Id - 1;
			int secondId = second.Entity.Name.Id - 1;

			Vector2f firstPosition = coordGrid[firstId];
			Vector2f secondPosition = coordGrid[secondId];
			int firstIndex = idGrid.IndexOf(firstId);
			int secondIndex = idGrid.IndexOf(secondId);

			coordGrid[firstId] = secondPosition;
			coordGrid[secondId] = firstPosition;

			idGrid[firstIndex] = secondId;
			idGrid[secondIndex] = firstId;

			second.Animation.Speed = speed;
			second.Animation.X = coordGrid[secondId].X;
			second.Animation.Y = coordGrid[secondId].Y;

			if (!onlySecond)
			{
				first.Animation.X = coordGrid[firstId].X;
				first.Animation.Y = coordGrid[firstId].Y;
			}
		}

		protected override void GetNodes()
		{
			gemNodes = engine.GetNodeList("GemNode");
		}

		void CheckBonuses(List<int> horDelete, List<int> vertDelete)
		{
			HashSet<int> deleteList = new HashSet<int>();
			deleteList.UnionWith(horDelete);
			deleteList.UnionWith(vertDelete);

			foreach (var id in deleteList)
			{
				var target = (GemNode)gemNodes.Find(
					n => n.Entity.Name.BaseName == BaseNames.Gem &&
					n.Entity.Name.Id - 1 == id
				);

				var gemSubType = target.Gem.GemSubType;

				var gridPos = GetGridPlace(id);
				var index = gridPos.X * Settings.GameSize + gridPos.Y;

				if (gemSubType == GemSub.Line)
				{
					engine.Playlist.Add(Assets.DestroyerSound);

					if (gridPos.Y - 1 >= 0 && 
					    deleteList.Contains(idGrid[index - 1]) ||
					   	gridPos.Y + 1 < Settings.GameSize && 
					    deleteList.Contains(idGrid[index + 1])
					   )
					{
						var leftDestroyer = Spawner.CreateDestroyer(
							new DestroyerView(target.Gem.GemType),
							target.Position.X, target.Position.Y,
							0, target.Position.Y
						);
						var rightDestroyer = Spawner.CreateDestroyer(
							new DestroyerView(target.Gem.GemType),
							target.Position.X, target.Position.Y,
							Layout.SessionBackgroundX + Layout.SessionBackgroundWidth,
							target.Position.Y
						);

						engine.AddEntity(leftDestroyer);
						engine.AddEntity(rightDestroyer);

						destroyerGrid[leftDestroyer.Name] = new DestroyerInfo(DestroyerDirection.Left);
						destroyerGrid[rightDestroyer.Name] = new DestroyerInfo(DestroyerDirection.Right);
					}

					if (gridPos.X - 1 >= 0 &&
					    deleteList.Contains(idGrid[(gridPos.X - 1) * Settings.GameSize + gridPos.Y]) ||
					   	gridPos.X + 1 < Settings.GameSize &&
					    deleteList.Contains(idGrid[(gridPos.X + 1) * Settings.GameSize + gridPos.Y])
					   )
					{
						var upDestroyer = Spawner.CreateDestroyer(
							new DestroyerView(target.Gem.GemType),
							target.Position.X, target.Position.Y,
							target.Position.X, 0
						);
						var downDestroyer = Spawner.CreateDestroyer(
							new DestroyerView(target.Gem.GemType),
							target.Position.X, target.Position.Y,
							target.Position.X,
							Layout.SessionBackgroundY + Layout.SessionBackgroundHeight
						);

						engine.AddEntity(upDestroyer);
						engine.AddEntity(downDestroyer);

						destroyerGrid[upDestroyer.Name] = new DestroyerInfo(DestroyerDirection.Up);
						destroyerGrid[downDestroyer.Name] = new DestroyerInfo(DestroyerDirection.Down);
					}
				}

				if (gemSubType == GemSub.Bomb)
				{
					engine.Playlist.Add(Assets.BoomSound);

					for (var i = gridPos.X - 1; i <= gridPos.X + 1; i++)
					{
						for (var j = gridPos.Y - 1; j <= gridPos.Y + 1; j++)
						{
							if (i >= 0 && i < Settings.GameSize &&
								j >= 0 && j < Settings.GameSize)
							{
								needDelete.Add(idGrid[i * Settings.GameSize + j]);
							}
						}
					}
				}
			}
		}

		void FindLines()
		{
			var gottenGems = new List<Gotten>();

			for (int i = 0; i < Settings.GameSize; i++)
			{
				for (int j = 0; j < Settings.GameSize; j++)
				{
					gottenGems.Add(new Gotten());
				}
			}

			for (int i = 0; i < Settings.GameSize; i++)
			{
				for (int j = 0; j < Settings.GameSize; j++)
				{
					var currentId = i * Settings.GameSize + j;

					var horDelete = new List<int> { idGrid[currentId] };
					var vertDelete = new List<int> { idGrid[currentId] };
					int horLineSize = 1;
					int vertLineSize = 1;

					for (int z = 1; j + z < Settings.GameSize; z++)
					{
						if (gemGrid[i, j] == gemGrid[i, j + z])
						{
							var id = idGrid[i * Settings.GameSize + j + z];
							if (!gottenGems[id].Horizontal)
							{
								gottenGems[id].Horizontal = true;
								horDelete.Add(id);
								horLineSize++;
							}
						}
						else
						{
							break;
						}
					}

					for (int z = 1; i + z < Settings.GameSize; z++)
					{
						if (gemGrid[i, j] == gemGrid[i + z, j])
						{
							var id = idGrid[(i + z) * Settings.GameSize + j];

							if (!gottenGems[id].Vertical)
							{
								gottenGems[id].Vertical = true;
								vertDelete.Add(id);
								vertLineSize++;
							}
						}
						else
						{
							break;
						}
					}

					if (horLineSize < minLineSize)
					{
						horDelete.Clear();
					}
					if (vertLineSize < minLineSize)
					{
						vertDelete.Clear();
					}

					CheckBonuses(horDelete, vertDelete);

					if (horLineSize >= 4 || vertLineSize >= 4 ||
					   	horLineSize >= 3 && vertLineSize >= 3
					   )
					{
						int id;
						if (lastMoved != -1)
						{
							id = lastMoved;
							lastMoved = -1;
						}
						else
						{
							id = currentId;
						}

						GemSub subType = GemSub.Line;

						if (horLineSize >= 3 && vertLineSize >= 3)
						{
							horDelete.Remove(id);
							vertDelete.Remove(id);
						}
						else if (vertLineSize >= 4)
						{
							vertDelete.Remove(id);
						}
						else if (horLineSize >= 4)
						{
							horDelete.Remove(id);
						}

						if (horLineSize >= 5 || vertLineSize >= 5 ||
					   		horLineSize >= 3 && vertLineSize >= 3
						   )
						{
							subType = GemSub.Bomb;
						}

						var target = (GemNode)gemNodes.Find(
							n => n.Entity.Name.BaseName == BaseNames.Gem &&
							n.Entity.Name.Id - 1 == id 
						);

						var gem = new GemView(gemGrid[GetGridPlace(id).X, GetGridPlace(id).Y], subType);

						var gemShape = gem.GemShape;
						gemShape.Origin = new Vector2f(
							gemShape.GetLocalBounds().Width / 2.0f,
							gemShape.GetLocalBounds().Height / 2.0f
						);
						target.Display.DisplayObject = gemShape;
						target.Gem.GemSubType = gem.GemSubType;
					}

					needDelete.UnionWith(horDelete);
					needDelete.UnionWith(vertDelete);
				}
			}
		}

		void StabilizeField() {
			for (int i = Settings.GameSize - 1; i >= 0; i--)
			{
				for (int j = Settings.GameSize - 1; j >= 0; j--)
				{
					int currentIndex = i * Settings.GameSize + j;
					var target = (GemNode)gemNodes.Find(
						n => n.Entity.Name.BaseName == BaseNames.Gem &&
						n.Entity.Name.Id - 1 == idGrid[currentIndex]
					);

					if (needDelete.Contains(idGrid[currentIndex]))
					{
						var foundUpper = false;
						for (int z = 1; i - z >= 0; z++)
						{
							var upperIndex = (i - z) * Settings.GameSize + j;
							if (!needDelete.Contains(idGrid[upperIndex]))
							{
								foundUpper = true;

								var upperTarget = (GemNode)gemNodes.Find(
									n => n.Entity.Name.BaseName == BaseNames.Gem &&
									n.Entity.Name.Id - 1 == idGrid[upperIndex]
								);

								SwapGems(target, upperTarget, Engine.GameSpeed * i, true);

								break;
							}
						}

						if (!foundUpper)
						{
							if (engine.AnimationEnded)
							{
								target.Position.Y = 0;
								target.Animation.Speed = Engine.GameSpeed * i;
								target.Animation.X = coordGrid[idGrid[currentIndex]].X;
								target.Animation.Y = coordGrid[idGrid[currentIndex]].Y;
							}
								
							target.Display.DisplayObject.Scale = new Vector2f(1.0f, 1.0f);

							needDelete.Remove(idGrid[currentIndex]);
						}
					}
				}
			}
		}

		void DestroyGems()
		{
			gemsDestroying = true;

			foreach (GemNode target in gemNodes)
			{
				if (target.Entity.Name.BaseName == BaseNames.Gem &&
					needDelete.Contains(target.Entity.Name.Id - 1))
				{
					target.Animation.Scale = new Vector2f(0.01f, 0.01f);
				}
			}
		}

		void PlayMatch(List<GemNode> clickedGems, List<Name> clickedGemsNames)
		{
			if (engine.AnimationEnded)
			{
				if (!gemsDestroying)
				{
					if (clickedGems.Count == 2)
					{
						GemNode first;
						GemNode second;

						int firstClicked = 0;
						if (clickedGems[0].Entity.Name != clickedGemsNames[0])
						{
							firstClicked = 1;
						}

						first = clickedGems[firstClicked];
						second = clickedGems[1 - firstClicked];

						if (AreNeighbours(first.Entity.Name.Id - 1, second.Entity.Name.Id - 1))
						{
							SwapGems(first, second, Engine.GameSpeed);
							prevClicked.Add(new Pair(first, second));
							lastMoved = first.Entity.Name.Id - 1;
						}

						return;
					}

					FindLines();

					if (needDelete.Count == 0)
					{
						if (prevClicked.Count != 0)
						{
							foreach (var clickedPair in prevClicked)
							{
								SwapGems((GemNode)clickedPair.First,
										 (GemNode)clickedPair.Second,
										 Engine.GameSpeed
										);
							}
						}
					}
					else
					{
						if (engine.Playlist.Count == 0)
						{
							engine.Playlist.Add(Assets.GemSound);
						}

						engine.Score += 10 * needDelete.Count;

						DestroyGems();
					}

					prevClicked.Clear();

					return;
				}


				var rnd = new Random();
				foreach (GemNode target in gemNodes)
				{
					if (target.Entity.Name.BaseName == BaseNames.Gem &&
					needDelete.Contains(target.Entity.Name.Id - 1))
					{
						var gem = new GemView(
							(Gem)Enum.GetValues(typeof(Gem)).GetValue(rnd.Next(0, 5))
						);

						var gemShape = gem.GemShape;
						gemShape.Origin = new Vector2f(
							gemShape.GetLocalBounds().Width / 2.0f,
							gemShape.GetLocalBounds().Height / 2.0f
						);
						target.Display.DisplayObject = gemShape;

						target.Gem.GemType = gem.GemType;
						target.Gem.GemSubType = GemSub.Gem;

						Vector2i gridPlace = GetGridPlace(target.Entity.Name.Id - 1);
						gemGrid[gridPlace.X, gridPlace.Y] = target.Gem.GemType;

						target.Animation.Scale = new Vector2f(1.0f, 1.0f);
					}
				}

				StabilizeField();

				needDelete.Clear();
				gemsDestroying = false;
			}
		}

		public override void Update()
		{
			GetNodes();

			List<Name> clickedGemsNames = new List<Name>();
			List<GemNode> clickedGems = new List<GemNode>();

			int gemsCount = 0;
			clickedGemsNames = engine.LastClicked.FindAll(n => n.BaseName == BaseNames.Gem);
			if (clickedGemsNames.Count == 2)
			{
				gemsCount = 2;
				clickedGems = new List<GemNode>(gemsCount);
				engine.LastClicked.Clear();
			}

			bool gemSpawned = false;
			foreach (GemNode target in gemNodes)
			{
				Vector2f position = new Vector2f(target.Position.X, target.Position.Y);

				if (gemsCount > 0 && clickedGemsNames.Contains(target.Entity.Name))
				{
					clickedGems.Add(target);
					gemsCount--;
				}

				if (target.Entity.Name.BaseName == BaseNames.Gem)
				{
					gemSpawned = true;

					var id = target.Entity.Name.Id - 1;
					Vector2i gridPlace = GetGridPlace(id);

					if (initCoords)
					{
						coordGrid[gridPlace.X * Settings.GameSize + gridPlace.Y] = position;

						var gem = (Shape)target.Display.DisplayObject;
						gem.Position = new Vector2f(target.Position.X, target.Position.Y);
					}

					gemGrid[gridPlace.X, gridPlace.Y] = target.Gem.GemType;	
				}

				if (target.Entity.Name.BaseName == BaseNames.Destroyer)
				{
					var destroyer = (RectangleShape)target.Display.DisplayObject;
					Name name = target.Entity.Name;
					DestroyerDirection direction = destroyerGrid[target.Entity.Name].Direction;

					for (int i = 0; i < fieldGrid.Count; i++)
					{
						var field = fieldGrid[i];
						var gridPlace = GetGridPlace(idGrid[i]);

						if (field.Contains(destroyer.GetGlobalBounds().Left + destroyer.Size.X,
						                   destroyer.GetGlobalBounds().Top + destroyer.Size.Y)
						   )
						{
							if (!(destroyerGrid[name].CurrentField == field))
							{
								destroyerGrid[name].CurrentField = field;
								destroyerGrid[name].FieldPosition = gridPlace;
								needDelete.Add(idGrid[i]);
								CheckBonuses(new List<int> { idGrid[i] }, new List<int> { idGrid[i] });
							}
							 
							break;
						}
					}

					var fieldPosition = destroyerGrid[name].FieldPosition;
					if (direction == DestroyerDirection.Left && fieldPosition.Y <= 0 ||
						direction == DestroyerDirection.Right && fieldPosition.Y >= Settings.GameSize - 1 ||
						direction == DestroyerDirection.Up && fieldPosition.X <= 0 ||
						direction == DestroyerDirection.Down && fieldPosition.X >= Settings.GameSize - 1
						)
					{
						engine.RemoveList.Add(target.Entity.Name);
						destroyerGrid.Remove(target.Entity.Name);

						break;
					}
				}
			}

			if (initCoords && gemSpawned)
			{
				initCoords = false;
			}

			else if (engine.GameState == GameState.NewGame)
			{
				PlayMatch(clickedGems, clickedGemsNames);
			}
		}
	}
}
