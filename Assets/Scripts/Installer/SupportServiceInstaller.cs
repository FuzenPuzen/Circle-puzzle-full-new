using Zenject;

public class SupportServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IMarkerService>().To<MarkerService>().AsSingle();
        Container.Bind<ILoaderSceneService>().To<LoaderSceneService>().AsSingle();

#if !UNITY_EDITOR
            Container.Bind<ILoadService>().To<YSaveService>().AsSingle();
#else
        Container.Bind<ILoadService>().To<PrefsLoader>().AsSingle();
#endif



        Container.Bind(
            typeof(IPrefabStorageService),
            typeof(ISOStorageService)
            ).To(typeof(StorageService)).AsSingle();

        Container.Bind<IViewFabric>().To<ViewFabric>().AsSingle();
        Container.Bind<IServiceFabric>().To<ServiceFabric>().AsSingle();
    
        Container.Bind<IPoolsViewService>().To<PoolsViewService>().AsSingle();

        Container.Bind<ITimerService>().To<TimerService>().AsSingle();
        Container.Bind<IAudioDataManager>().To<AudioDataManager>().AsSingle();
    }
}