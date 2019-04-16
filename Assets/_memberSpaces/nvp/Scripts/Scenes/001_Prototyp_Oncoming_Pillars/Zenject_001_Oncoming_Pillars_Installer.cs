using nvp.Scripts.Interfaces;
using nvp.Scripts.Tools.Events;
using Zenject;

public class Zenject_001_Oncoming_Pillars_Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IEventController>().To<NvpEventController>().AsSingle();
    }
}