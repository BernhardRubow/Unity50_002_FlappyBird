using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverController : nvp.Assets.EventHandling.NvpAbstractEventHandlerV2
{

    [SerializeField] TextMeshProUGUI text;

    protected override void Start()
    {
        base.Start();
        //text.enabled = true;
    }

    protected override void StartListenToEvents()
    {
        EventController.StartListenForEvent(EventIdNorm.Hash("Jan", "hitTube"), OnHitTube);
    }

    protected override void StopListenToEvents()
    {
        EventController.StopListenForEvent(EventIdNorm.Hash("Jan", "hitTube"), OnHitTube);
    }

    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    async void OnHitTube(object s, object e)
    {
        //StartCoroutine(wait());
        await System.Threading.Tasks.Task.Delay(1000);
        text.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        SetTextStage(true);
        for (float i = 0.0f; i < 1; i += 0.1f)
        {
            await System.Threading.Tasks.Task.Delay(100);
            text.color = new Color(1.0f, 1.0f, 1.0f, i);
        }
    }

    void SetTextStage(bool state)
    {
        text.enabled = state;
    }
}
