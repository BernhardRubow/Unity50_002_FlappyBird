using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.Assets.EventHandling;
using TMPro;

public class ScoreListener_scr : NvpAbstractEventHandlerV2
{

    int Score = 0;
    public TextMeshProUGUI scoretext; 

    // Update is called once per frame
    void Update()
    {
        scoretext.text = Score.ToString("0000");
    }

    void OnScored(object s, object e)
    {
        if (Score == 9999)
        { } else { Score++; }
    }

    protected override void StartListenToEvents()
    {
        EventController.StartListenForEvent(
            EventIdNorm.Hash("fynn", "onscored"),
            OnScored);
    }

    protected override void StopListenToEvents()
    {
        EventController.StopListenForEvent(
            EventIdNorm.Hash("fynn", "onscored"), 
            OnScored);
    } 
}
