using ProCollections.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ProCollections
{
	public class MultiServiceRegistry : IMultiServiceRegistry
	{
		protected readonly Dictionary<Type, List<object>> registry = new();

		public MultiServiceRegistry() { }
		public MultiServiceRegistry(Dictionary<Type, List<object>> services) => registry = services;


		public void Register<T>(T service) where T : class
		{
			if (!registry.ContainsKey(typeof(T)))
				registry[typeof(T)] = new List<object>();
			registry[typeof(T)].Add(service);
		}

		public IReadOnlyList<T> Get<T>() where T : class => registry.TryGetValue(typeof(T), out List<object> services) ? services.Cast<T>().ToList() : null;

		public bool Remove<T>() where T : class => registry.Remove(typeof(T));

		public bool Remove<T>(T service) where T : class
		{
			if (!registry.ContainsKey(typeof(T))) return false;

			var targetList = registry[typeof(T)];
			if (!targetList.Remove(service)) return false;
			if (targetList.Count == 0) Remove<T>();
			return true;
		}

		public bool TryGet<T>(out IReadOnlyList<T> services) where T : class
		{
			services = Get<T>();
			return services is not null;
		}
	}
}
