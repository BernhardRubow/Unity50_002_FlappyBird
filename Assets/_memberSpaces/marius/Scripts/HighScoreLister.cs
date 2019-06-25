using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using nvp.Assets.EventHandling;
using System.Web;

public class HighScoreLister : NvpAbstractEventHandlerV2
{
    public TextMeshPro userScoresUpper;
    public TextMeshPro userScoresLeft;
    public TextMeshPro userScoresRight;
    private NetworkOperation highscoreLoader;
    private NetworkOperation highscoreSetter;

    // Start is called before the first frame update
    protected override void Start() {
        highscoreLoader = new NetworkOperation();
        highscoreSetter = new NetworkOperation();
        highscoreLoader.sendHTTPRequest("https://youtube.alpmann.de/gdp_unity50_flappy_bird.php?action=top5");
        if (PlayerPrefs.GetString("name") != "") // if a name is set
            highscoreSetter.sendHTTPRequest("https://youtube.alpmann.de/gdp_unity50_flappy_bird.php?action=set&name=" + PlayerPrefs.GetString("name") + "&value=" + PlayerPrefs.GetInt("currentScore"));
    }

    protected override void StartListenToEvents()
    {
        base.StartListenToEvents();
    }

    protected override void StopListenToEvents()
    {
        base.StopListenToEvents();
    }

    public void OnPlayAgainButton()
    {
        SceneManager.LoadSceneAsync("04_Game");
    }

    public void OnToMainMenuButton()
    {
        SceneManager.LoadSceneAsync("02_Hauptmenu");
    }

    // fixedupdate instead of update to prevent lag from permanent json parsing and the other stuff
    void FixedUpdate() {
        string userScoresUpperText = null;
        string userScoresLeftText = null;
        string userScoresRightText = null;

        userScoresUpperText += "Your Score:\n" + PlayerPrefs.GetInt("currentScore").ToString();
        if(PlayerPrefs.GetString("name") == "") { // name is set to "" if not set by user
            userScoresUpperText += "\n can't sync: name not given";
        } else if (highscoreSetter.isDone() == true) {
            userScoresUpperText += "\n ☺ synced\n";
        } else {
            userScoresUpperText += "\n X syncing..\n";
        }

        if (highscoreLoader.isDone() == false) {
            userScoresUpperText += "\n\n\n\n\n" + "Loading Highscore table..";
        } else {
            string jsonString = highscoreLoader.getData();
            var dict = MiniJSON.Json.Deserialize(jsonString) as Dictionary<string, object>;
            string[] keys = new string[5];
            dict.Keys.CopyTo(keys, 0);

            for (int i = 0; i < 5; i++) {
                userScoresLeftText += keys[i] + "\n\n";
                userScoresRightText += dict[keys[i]] + "\n\n";
            }
        }

        userScoresUpper.SetText(userScoresUpperText);
        userScoresLeft.SetText(userScoresLeftText);
        userScoresRight.SetText(userScoresRightText);

    }
}
