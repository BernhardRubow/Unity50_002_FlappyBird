using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.Assets.EventHandling;
using UnityEngine.SceneManagement;

public class ButtonController : NvpAbstractEventHandlerV2
{

    void onStartButtonPressed(object s, object e)
    {
        
    }

    protected override void StartListenToEvents()
    {
        EventController.StartListenForEvent(
            EventIdNorm.Hash("Pietro", "onstartbutton"), onStartButtonPressed);
    }

    protected override void StopListenToEvents()
    {
        EventController.StopListenForEvent(
            EventIdNorm.Hash("Pietro", "onstartbutton"), onStartButtonPressed);
    }

}
