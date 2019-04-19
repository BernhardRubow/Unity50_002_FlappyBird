using Zenject;
using FlappyBird.Events;
using FlappyBird.Interfaces;

public class GlobalZenjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IEventController>().To<NvpEventController>().AsSingle();
    }
}