namespace ProCollections.Interfaces
{
	public interface IMultiTypeServiceRegistry : IServiceRegistry
	{
		void Register(object service);
		bool Remove(object service);
	}
}