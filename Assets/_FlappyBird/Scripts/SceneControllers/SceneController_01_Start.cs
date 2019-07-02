using System;
using System.Threading.Tasks;
using FlappyBird.Events;
using nvp.Assets.EventHandling;
using UnityEngine;

namespace FlappyBird.ScenesControllers
{
    public class SceneController_01_Start : NvpAbstractEventHandlerV2
    {
        // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        


        // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        async void Start()
        {
            // Wait for all general scripts to be initialized
            await Task.Delay(TimeSpan.FromSeconds(1));

            // Inform everybody, that the game has finished initialization
            EventController.TriggerEvent((int)FlappyBirdEvents.OnGameInitialized, this, null);
        }

        private void OnDisable()
        {
            //Debug.Log("im disabled");
            var tmp = GameObject.Find("DependencyInjectionController");
            Destroy(tmp);
        }


        // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++




        // +++ class member +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    }
}
