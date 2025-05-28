using ProCollections.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ProCollections
{
	public class MultiTypeServiceRegistry : MultiServiceRegistry, IMultiTypeServiceRegistry
	{
		public void Register(object service)
		{
			Type serviceType = service.GetType();
			foreach (var type in serviceType.GetInterfaces().Append(serviceType))
			{
				if (!registry.ContainsKey(type))
					registry[type] = new List<object>();
				var targetList = registry[type];
				if (!targetList.Contains(service))
					targetList.Add(service);
			}
		}

		public bool Remove(object service)
		{
			Type serviceType = service.GetType();
			var servicesTypes = serviceType.GetInterfaces().Append(serviceType);
			if (servicesTypes.Any(type => !registry.ContainsKey(type))) return false;
			foreach (var type in servicesTypes)
				registry[type].Remove(service);
			return true;
		}
	}
}
