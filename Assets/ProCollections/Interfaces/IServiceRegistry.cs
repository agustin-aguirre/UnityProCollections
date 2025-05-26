using System.Collections.Generic;


namespace ProCollections.Interfaces
{
	public interface IServiceRegistry
	{
		IReadOnlyList<T> Get<T>() where T : class;
		void Register<T>(T service) where T : class;
		bool Remove<T>() where T : class;
		bool Remove<T>(T service) where T : class;
		bool TryGet<T>(out IReadOnlyList<T> services) where T : class;
	}
}