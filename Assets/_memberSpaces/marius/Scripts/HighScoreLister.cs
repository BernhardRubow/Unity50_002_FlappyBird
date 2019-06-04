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
    public TextMeshPro userScores;
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
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("highscores");
        NetworkHandler.sendHTTPRequest("https://youtube.alpmann.de/gdp_unity50_flappy_bird1.php?action=top5");
        while (asyncLoad.isDone == false) { }
    }

    // Start is called before the first frame update
    protected override void Start() {
        OnShowHighscores(null, null);
        PlayerPrefs.SetInt("currentScore", 890234234);
        //EventController.StartListenForEvent(EventIdNorm.Hash("marius", "showHighscores"), OnShowHighscores);
        //EventController.TriggerEvent(EventIdNorm.Hash("marius", "showHighscores"), this, null);
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
        string text = "Score:\t" + numToShortString(PlayerPrefs.GetInt("currentScore")) + "\n";
        /*if (NetworkHandler.isDone() == false)
            text += "\n\n\nloading highscore table..\n";
        else
            text += "wwi";*/
        string jsonString = "{\"H4X0R\":438258000000000,\"lalala\":33259800000,\"test\":300000000,\"gunterino\":334333,\"Micky Mouse\":2000}"; //NetworkHandler.getData();
        var dict = MiniJSON.Json.Deserialize(jsonString) as Dictionary<string, object>;
        string[] keys = new string[5];
        dict.Keys.CopyTo(keys, 0);
        // to-do:
        // - for loop for this down there
        // - remove the static-ness from the network manager i can do ?action=set and ?action=top5 at the same time
        text += keys[0] + "\t" + dict[keys[0]] + "\n";
        text += keys[1] + "\t" + dict[keys[1]] + "\n";
        text += keys[2] + "\t" + dict[keys[2]] + "\n";
        text += keys[3] + "\t" + dict[keys[3]] + "\n";
        text += keys[4] + "\t" + dict[keys[4]] + "\n";

        userScores.SetText(text);
    }
}
