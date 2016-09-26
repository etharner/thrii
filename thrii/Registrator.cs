using System.Collections.Generic;

namespace thrii
{
	public enum BaseNames
	{
		MenuNewGameBg,
		MenuNewGameText,
		SessionBg
	}

	public class Name
	{
		public BaseNames BaseName;
		public int Id;

		public Name(BaseNames baseName, int id)
		{
			BaseName = baseName;
			Id = id;
		}
	}

	public class Registrator
	{
		Dictionary<BaseNames, int> registered;

		public Registrator()
		{
			registered = new Dictionary<BaseNames, int>();
		}

		public Name GenerateName(BaseNames name)
		{
			if (!registered.ContainsKey(name))
			{
				registered[name] = 1;
				return new Name(name, 1);
			}

			registered[name]++;

			return new Name(name, registered[name]);
		}

		public void RemoveName(BaseNames name)
		{
			registered[name]--;
			if (registered[name] == 0)
			{
				registered.Remove(name);
			}
		}
	}
}
