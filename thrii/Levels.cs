using System.Collections.Generic;

namespace thrii
{
	public class LevelInfo
	{
		public int GameSize { get; set; }
		public int Time { get; set; }
		public int Goal { get; set; }

		public LevelInfo(int gameSize, int time, int goal)
		{
			GameSize = gameSize;
			Time = time;
			Goal = goal;
		}
	}

	public enum LevelDifficulty
	{
		Easy,
		Medium,
		Hard
	}

	public static class Levels
	{
		public static List<LevelInfo> LevelsList = new List<LevelInfo>
		{
			new LevelInfo(Settings.GameSize, 60, 0),
			new LevelInfo(16, 60, 3000),
			new LevelInfo(16, 60, 5000),
			new LevelInfo(16, 50, 6000),
 			new LevelInfo(12, 60, 3000),
			new LevelInfo(12, 60, 5000),
			new LevelInfo(12, 50, 6000),
			new LevelInfo(8,  60, 4000),
			new LevelInfo(8,  60, 6000),
			new LevelInfo(8,  50, 7000),
			new LevelInfo(4,  60, 3000),
			new LevelInfo(4,  50, 3500),
			new LevelInfo(4,  50, 4500),
			new LevelInfo(16, 30, 8000),
			new LevelInfo(16, 30, 10000),
			new LevelInfo(12, 30, 8000),
			new LevelInfo(8,  20, 7000),
			new LevelInfo(8,  20, 8000),
			new LevelInfo(4,  30, 8000)
		};

		public static void Update()
		{
			LevelsList[0].GameSize = Settings.GameSize;
		}
	}
}
