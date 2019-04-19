using nvp.Tools.Events;
using nvp.Interfaces;
using Zenject;

namespace nvp.Prototypes.Prototy_001
{

    public class Zenject_001_Oncoming_Pillars_Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<nvp.Interfaces.IEventController>().To<NvpEventController>().AsSingle();
        }
    }
}