using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.Assets.EventHandling;

public class Reciever : NvpAbstractEventHandlerV2
{
    void Update()
    {
        
    }

    protected override void StartListenToEvents()
    {
        EventController.StartListenForEvent("HitTube".GetHashCode(), OnHitTube);
    }

    protected override void StopListenToEvents()
    {
        EventController.StopListenForEvent("HitTube".GetHashCode(), OnHitTube);
    }

    void OnHitTube(object s, object e)
    {
        Debug.Log("EventHitTubeTriggered");
    }
}
