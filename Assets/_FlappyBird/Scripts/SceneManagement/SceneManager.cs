using FlappyBird.Events;
using nvp.Assets.EventHandling;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyBird
{
    public class SceneManager : NvpAbstractEventHandlerV2
    {
        // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++




        // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void Update()
        {

        }

        // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void OnGameInitialized(object arg1, object arg2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                "_FlappyBird/Scenes/02_Hauptmenu",
                LoadSceneMode.Additive);
        }

        private void OnSettingsButtonPressed(object sender, object data)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("03_Settings", LoadSceneMode.Additive);
        }

        private void OnStartButtonPressed(object sender, object data)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("04_Game", LoadSceneMode.Additive);
        }

        private void OnBackToMenuPressed(object sender, object data)
        {
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("03_Settings");
        }

        // +++ class member +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected override void StartListenToEvents()
        {
            EventController.StartListenForEvent(
                (int)FlappyBirdEvents.OnGameInitialized,
                OnGameInitialized);

            EventController.StartListenForEvent(
                EventIdNorm.Hash("pietro", "onsettingsbutton"),
                OnSettingsButtonPressed);

            EventController.StartListenForEvent(
                EventIdNorm.Hash("pietro", "onstartbutton"),
                OnStartButtonPressed);

            EventController.StartListenForEvent(
                EventIdNorm.Hash("marius", "backToMenu"),
                OnBackToMenuPressed);

        }

        protected override void StopListenToEvents()
        {
            EventController.StopListenForEvent(
                (int)FlappyBirdEvents.OnGameInitialized,
                OnGameInitialized);

            EventController.StopListenForEvent(
                EventIdNorm.Hash("pietro", "onsettingsbutton"),
                OnSettingsButtonPressed);

            EventController.StopListenForEvent(
                EventIdNorm.Hash("pietro", "onstartbutton"),
                OnStartButtonPressed);

            EventController.StopListenForEvent(
                EventIdNorm.Hash("marius", "backToMenu"),
                OnBackToMenuPressed);

        }

    }
}
