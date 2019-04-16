using System.ComponentModel;
using nvp.events;
using UnityEngine;
using Zenject;

public class Zenject_Prototyp_EventManager_Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IEventController>().To<NvpEventController>().AsSingle();
    }
}