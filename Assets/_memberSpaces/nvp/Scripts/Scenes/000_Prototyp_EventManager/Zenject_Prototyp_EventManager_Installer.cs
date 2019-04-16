using nvp.Scripts.Interfaces;
using nvp.Scripts.Tools.Events;
using Zenject;

public class Zenject_Prototyp_EventManager_Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IEventController>().To<NvpEventController>().AsSingle();
    }
}