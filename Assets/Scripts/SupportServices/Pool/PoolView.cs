
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using Zenject;

public class PoolView: MonoBehaviour
{

}

public interface IPoolViewService
{
    public void SpawPool<T>(int objCount = 10) where T : class;
    public IPoolingViewService GetItem<T>() where T : class;
    public void ReturnItem(IPoolingViewService item);
    public int GetViewServicesCount();
}

public class PoolViewService : IPoolViewService
{
    private List<IPoolingViewService> _freeItems = new();

    private List<IPoolingViewService> _viewServices = new();
    [Inject] private IServiceFabric _serviceFabric;
    [Inject] private IViewFabric _viewFabric;
    private PoolView _poolView;
	private int _objCount;

    public void ActivateService()
    {
        _poolView = _viewFabric.Init<PoolView>();       
    }

    public int GetViewServicesCount() => _viewServices.Count;

    public IPoolingViewService GetItem<T>() where T : class
    {
        if (_freeItems.Count == 1) SpawnAddedItem<T>();
        IPoolingViewService Item = _freeItems.FirstOrDefault();
        _freeItems.Remove(Item);
        return Item;
    }

    public void ReturnItem(IPoolingViewService item)  
    {
        _freeItems.Add(item);
    }

    public void SpawPool<T>(int objCount = 10) where T : class
    {
        _objCount = objCount;
        _poolView.name = $"Pool({typeof(T).Name})";
        for (int i = 0; i < _objCount; i++)
        {
            SpawnAddedItem<T>();
        }
    }

    private void SpawnAddedItem<T>() where T : class
    {
        IPoolingViewService item = (IPoolingViewService)_serviceFabric.InitMultiple<T>();
        item.ActivateServiceFromPool(_poolView.transform);
        item.SetDeactivateAction(ReturnItem);
        _viewServices.Add(item);
        _freeItems.Add(item);
    }
}
