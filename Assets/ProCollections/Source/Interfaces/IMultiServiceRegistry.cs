using System.Collections.Generic;


namespace ProCollections.Interfaces
{
	public interface IMultiServiceRegistry : IServiceRegistrator
	{
		IReadOnlyList<T> Get<T>() where T : class;
		bool TryGet<T>(out IReadOnlyList<T> services) where T : class;
	}
}
