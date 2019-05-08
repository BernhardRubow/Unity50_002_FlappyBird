using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace nvp.Assets.EventHandling.Examples
{

    public class TestObjectB : NvpAbstractEventHandlerV2
    {
        // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++



        // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected override async void Start()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            EventController.TriggerEvent("test".GetHashCode(), this, "Hello, World!");
        }

        // Update is called once per frame
        void Update()
        {

        }




        // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++





        // +++ class member +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    }
}