using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using nvp.Assets.EventHandling;

public class HighScoreLister : NvpAbstractEventHandlerV2
{
    public TextMeshPro userScores;
    private int userScore = 13489;
    private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public static long GetCurrentUnixTimestampMillis()
    {
        return (long)(DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
    }

    private string numToShortString(long n)
    {
        if (n > 1000000000)
            return Mathf.Floor(n / 1000000000).ToString() + "B";
        if (n > 1000000)
            return Mathf.Floor(n / 1000000).ToString() + "M";
        if (n > 1000)
            return Mathf.Floor(n / 1000).ToString() + "K";
        else
            return n.ToString();
    }

    private void OnShowHighscores(object s, object e) {
        Debug.LogFormat("OnShowHighscores({0}, {1}) call", s.ToString(), e.ToString());
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("highscores");
        NetworkHandler.sendHTTPRequest("https://youtube.alpmann.de/gdp_unity50_flappy_bird1.php?action=top5");
        while (asyncLoad.isDone == false) { }
    }

    // Start is called before the first frame update
    protected override void Start() {
        EventController.StartListenForEvent(EventIdNorm.Hash("marius", "showHighscores"), OnShowHighscores);
        EventController.TriggerEvent(EventIdNorm.Hash("marius", "showHighscores"), this, "roflcopter");
    }

    protected override void StartListenToEvents()
    {
        base.StartListenToEvents();
    }

    protected override void StopListenToEvents()
    {
        base.StopListenToEvents();
    }

    // Update is called once per frame
    void Update() {
        string text = "Your Score:\t" + numToShortString(userScore) + "\n";
        if (NetworkHandler.isDone() == false)
            text += "\n\n\nloading highscore table..\n";
        else
            text += "wwi";

        userScores.SetText(text);
    }
}
