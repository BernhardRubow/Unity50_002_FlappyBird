using System;
using System.Threading.Tasks;
using FlappyBird.Events;

namespace FlappyBird.Scenes
{
    public class SceneController_01_Start : NvpAbstractEventHandler
    {
        // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++




        // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        async void Start()
        {
            // Wait for all general scripts to be initialized
            await Task.Delay(TimeSpan.FromSeconds(1));

            // Inform everybody, that the game has finished initialization
            EventController.InvokeEvent(NvpGameEvents.OnGameInitialized, this, null);
        }




        // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++




        // +++ class member +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected override void SubscribeToEvents()
        {

        }

        protected override void UnsubscribeFromEvents()
        {

        }
    }
}
