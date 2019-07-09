using System;
using System.Collections;
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
            StartCoroutine(activateScene("04_Game"));
        }

        private void OnBackToMenuPressed(object sender, object data)
        {
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("03_Settings");
        }

        private void showHighscores(object arg0, object arg1)
        {
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("04_Game");
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("05_Highscores", LoadSceneMode.Additive);
        }

        private void onPlayAgainButton(object arg0, object arg1)
        {
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("05_Highscores");
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("04_Game", LoadSceneMode.Additive);

            StartCoroutine(activateScene("04_Game"));
        }

        private void onMainMenuButton(object arg0, object arg1)
        {
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("05_Highscores");
        }


        // +++ class member +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void SetActiveSceneByName(string name)
        {
            UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.SceneManager.GetSceneByName(name));
        }

        IEnumerator activateScene(string name)
        {
            yield return new WaitForEndOfFrame(); // one end of the frame is not enough
            yield return new WaitForEndOfFrame();
            SetActiveSceneByName(name);
        }

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

            EventController.StartListenForEvent(
                EventIdNorm.Hash("marius", "showhighscores"),
                showHighscores);

            EventController.StartListenForEvent(
                EventIdNorm.Hash("marius", "onplayagainbutton"),
                onPlayAgainButton);

            EventController.StartListenForEvent(
                EventIdNorm.Hash("marius", "onMainMenuButton"),
                onMainMenuButton);
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

            EventController.StopListenForEvent(
                EventIdNorm.Hash("marius", "showhighscores"),
                showHighscores);

            EventController.StopListenForEvent(
                EventIdNorm.Hash("marius", "onplayagainbutton"),
                onPlayAgainButton);

            EventController.StartListenForEvent(
                EventIdNorm.Hash("marius", "onMainMenuButton"),
                onMainMenuButton);
        }

    }
}
