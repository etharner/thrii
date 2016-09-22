using System;
using Otter;

namespace thrii
{
	public class Actor
	{
		public Entity Entity { get; }

		public Actor(int x, int y, int width, int height)
		{
			Entity = new Entity(x, y, Image.CreateRectangle(width, height, Color.Cyan));
		}
	}
}
