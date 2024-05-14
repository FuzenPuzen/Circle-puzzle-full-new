using Zenject;

public class SessionInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<StateMachine>().AsSingle();
        Container.Bind<GameCanvasViewService>().AsSingle();

        Container.Bind<YSaveService>().AsSingle();

        Container.Bind<MainCameraViewService>().AsSingle();

        Container.Bind<AudioUnitViewService>().AsSingle();
        Container.Bind<IScoreDataManager>().To<ScoreDataManager>().AsSingle();
        Container.Bind<IRecordDataManager>().To<RecordDataManager>().AsSingle();
        Container.Bind<IAudioService>().To<AudioService>().AsSingle();
        Container.Bind<IDifficultDataManager>().To<DifficultDataManager>().AsSingle();
        Container.Bind<IDifficultyService>().To<DifficultyService>().AsSingle();

        Container.Bind<LineGeneratorService>().AsSingle();
        Container.Bind<RotateLineService>().AsSingle();

    }
}
