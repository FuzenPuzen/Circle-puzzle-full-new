using System;
using System.Collections.Generic;
using Zenject;

public interface IPoolsViewService : IService
{
	public IPoolViewService GetPool<T>() where T : class;
}

public class PoolsViewService : IPoolsViewService
{
    [Inject] private IServiceFabric _serviceFabric;
	private Dictionary<Type, IPoolViewService> _pools = new();
	
	public void ActivateService()
	{
		
    }

	private void InitPool<T>(int count = 10) where T : class
	{
        PoolViewService newPool = _serviceFabric.InitMultiple<PoolViewService>();
		newPool.ActivateService();
        newPool.SpawPool<T>(count);
		_pools.Add(typeof(T), newPool);
    }

	public IPoolViewService GetPool<T>() where T : class
    {
		if (!_pools.ContainsKey(typeof(T)))
			InitPool<T>();
        return _pools[typeof(T)];
	}
}
