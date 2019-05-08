using System.Collections;
using System.Collections.Generic;
using nvp.Assets.EventHandling;
using UnityEngine;
using Zenject;

namespace nvp.Assets.EventHandling.Examples
{
    public class TestDIContext : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<INvpEventController>().To<NvpEventControllerV2>().AsSingle();
        }
    }
}