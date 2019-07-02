using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverController : nvp.Assets.EventHandling.NvpAbstractEventHandlerV2
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] TextMeshProUGUI text;




    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    protected override void Start()
    {
        base.Start();
        //text.enabled = true;
    }




    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    async void OnHitTube(object s, object e)
    {
        //StartCoroutine(wait());
        await System.Threading.Tasks.Task.Delay(1000);
        text.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        SetTextStage(true);
        for (float i = 0.0f; i < 1; i += 0.05f)
        {
            await System.Threading.Tasks.Task.Delay(50);
            text.color = new Color(1.0f, 1.0f, 1.0f, i);
        }
        await System.Threading.Tasks.Task.Delay(750);

        EventController.TriggerEvent(
            EventIdNorm.Hash("marius", "showHighscores"),
            this,
            null);

    }




    // +++ class member +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    protected override void StartListenToEvents()
    {
        EventController.StartListenForEvent(
            EventIdNorm.Hash("Jan", "hitTube"), 
            OnHitTube);
    }

    protected override void StopListenToEvents()
    {
        //Debug.Log("now calling hitTube aka. stoplistentoevents");
        EventController.StopListenForEvent(
            EventIdNorm.Hash("Jan", "hitTube"), 
            OnHitTube);
    }

    void SetTextStage(bool state)
    {
        text.enabled = state;
    }
}
