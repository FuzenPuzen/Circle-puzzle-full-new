using Zenject;
public interface IServiceFabric
{
    T InitSingle<T>() where T : class;
    public T InitMultiple<T>() where T : class;
}

public class ServiceFabric: IServiceFabric
{
    [Inject] private readonly DiContainer _container;

    public T InitSingle<T>() where T : class
    {
        T instance = _container.TryResolve<T>();
        // Если экземпляр не найден, то биндим и создаем новый
        if (instance == null)
        {
            _container.Bind<T>().AsSingle();
            instance = _container.Resolve<T>();
        }
        return instance;
    }

    public T InitMultiple<T>() where T : class => _container.Instantiate<T>();
}

