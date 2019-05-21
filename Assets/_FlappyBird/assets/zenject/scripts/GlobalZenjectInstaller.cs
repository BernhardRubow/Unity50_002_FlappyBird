using Zenject;
using FlappyBird.Events;
using nvp.Assets.EventHandling;

namespace FlappyBird
{
    public class GlobalZenjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<INvpEventController>().To<NvpEventControllerV2>().AsSingle();
        }
    }
}