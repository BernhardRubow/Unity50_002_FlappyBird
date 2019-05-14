using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.Assets.EventHandling;
using TMPro;

public class score : NvpAbstractEventHandlerV2
{

    int Score = 0;
    public TextMeshProUGUI scoretext; 

    // Update is called once per frame
    void Update()
    {
        scoretext.text = Score.ToString("00");
    }

    void OnScored(object s, object e)
    {
        if (Score == 9999)
        { } else { Score++; }
    }

    protected override void StartListenToEvents()
    {
        EventController.StartListenForEvent("onscored".GetHashCode(), OnScored);
    }

    protected override void StopListenToEvents()
    {
        EventController.StartListenForEvent("onscored".GetHashCode(), OnScored);
    }
}
