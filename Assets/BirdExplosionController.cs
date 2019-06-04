using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.Assets.EventHandling;
using System;

public class BirdExplosionController : NvpAbstractEventHandlerV2
{

    public string eventPerson = "";
    public string eventName = "";

    public Animator animator;

    void Start()
    {
        
    }

    
    void Update()
    {
        

        
    }

    protected override void StartListenToEvents()
    {
        EventController.StartListenForEvent(
            EventIdNorm.Hash(eventPerson, eventName),
            onAnimation);
    }

    private void onAnimation(object s, object e)
    {
        Vector3 position = (Vector3)e ;
        this.transform.position = position;
        animator.Play("BirdExplosion");
    }

    protected override void StopListenToEvents()
    {
        
    }
   
}
