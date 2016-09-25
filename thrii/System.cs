namespace thrii
{
	interface ISystem
	{
		string NodeType { get; }

		void GetNodes();
		void Update();	
	}
}
