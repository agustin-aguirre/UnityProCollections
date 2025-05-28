namespace ProCollections.Interfaces
{
	public interface IMultiTypeServiceRegistry : IMultiServiceRegistry
	{
		void Register(object service);
		bool Remove(object service);
	}
}