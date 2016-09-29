using System.Collections.Generic;

namespace thrii
{
	public class System
	{
		protected Engine engine;

		protected System(Engine e)
		{
			engine = e;
		}

		protected virtual void GetNodes() {}

		public virtual void Update() {}
	}
}
