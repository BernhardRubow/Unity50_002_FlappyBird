using System.Collections;
using System.Collections.Generic;
using nvp.Assets.EventHandling;
using UnityEngine;

public class RainbowFartUpdater : NvpAbstractEventHandlerV2
{
    public Transform birdVisualTransform;
    public Transform particleTransform;
    public ParticleSystem rainbowFartParticles;

   

    // +++ class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    protected override void StartListenToEvents()
    {
        EventController.StartListenForEvent(EventIdNorm.Hash("nvp", "movePressed"), OnMoved);
    }

    protected override void StopListenToEvents()
    {
        EventController.StopListenForEvent(EventIdNorm.Hash("nvp", "movePressed"), OnMoved);
    }

    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnMoved(object arg0, object arg1)
    {
        this.rainbowFartParticles.Play();
    }

}
