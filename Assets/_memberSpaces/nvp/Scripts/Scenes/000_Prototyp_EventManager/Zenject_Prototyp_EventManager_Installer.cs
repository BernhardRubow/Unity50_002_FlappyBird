using nvp.Tools.Events;
using nvp.Interfaces;
using Zenject;

namespace nvp.Prototypes.Prototy_000
{

    public class Zenject_Prototyp_EventManager_Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<nvp.Interfaces.IEventController>().To<NvpEventController>().AsSingle();
        }
    }
}