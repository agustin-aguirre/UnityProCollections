using ProCollections.Interfaces;
using System;
using System.Collections.Generic;


namespace ProCollections
{
	public class ServiceRegistry : IServiceRegistry
	{
		protected readonly Dictionary<Type, object> registry = new();

		public ServiceRegistry() { }
		public ServiceRegistry(Dictionary<Type, object> services) => registry = services;


		public void Register<T>(object service) where T : class => registry[typeof(T)] = service;

		public void Register<T>(T service) where T : class => Register<T>((object)service);

		public T Get<T>() where T : class => registry.TryGetValue(typeof(T), out object service) ? service as T : null;

		public bool Remove<T>() where T : class => registry.Remove(typeof(T));

		public bool Remove<T>(T service) where T : class => registry.Remove(service.GetType());

		public bool TryGet<T>(out T service) where T : class
		{
			service = Get<T>();
			return service is not null;
		}
	}
}
