namespace ProCollections.Interfaces
{
	public interface IServiceRegistry : IServiceRegistrator
	{
		T Get<T>() where T : class;
		bool TryGet<T>(out T services) where T : class;
	}
}