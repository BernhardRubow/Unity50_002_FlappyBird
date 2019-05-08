using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace nvp.Assets.EventHandling.Examples
{
    public class TestObjectA : NvpAbstractEventHandlerV2
    {
        // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
       



        // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        void Update()
        {

        }

        




        // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        void OnEventTriggered(object s, object e)
        {
            Debug.LogFormat("Received: {0}", e);
        }




        // +++ class member +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected override void StartListenToEvents()
        {
            EventController.StartListenForEvent("test".GetHashCode(), OnEventTriggered);
        }

        protected override void StopListenToEvents()
        {
            EventController.StopListenForEvent("test".GetHashCode(), OnEventTriggered);
        }
    }
}