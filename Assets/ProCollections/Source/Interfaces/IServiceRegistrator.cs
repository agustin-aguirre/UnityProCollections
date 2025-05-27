namespace ProCollections.Interfaces
{
	public interface IServiceRegistrator
	{
		void Register<T>(T service) where T : class;
		bool Remove<T>() where T : class;
		bool Remove<T>(T service) where T : class;
	}
}
