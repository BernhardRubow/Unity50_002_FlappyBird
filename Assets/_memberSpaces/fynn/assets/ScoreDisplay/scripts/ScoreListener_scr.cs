using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.Assets.EventHandling;
using TMPro;

public class ScoreListener_scr : NvpAbstractEventHandlerV2
{
    public TextMeshProUGUI scoretext; 

    // Update is called once per frame
    void Update()
    {
        scoretext.text = PlayerPrefs.GetInt("currentScore").ToString().PadLeft(7, '0');
    }

    void OnScored(object s, object e)
    {
        // we dont need to check the score for a overflow here because the settings manager does it automatically
        PlayerPrefs.SetInt("currentScore", PlayerPrefs.GetInt("currentScore") + 1);
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
