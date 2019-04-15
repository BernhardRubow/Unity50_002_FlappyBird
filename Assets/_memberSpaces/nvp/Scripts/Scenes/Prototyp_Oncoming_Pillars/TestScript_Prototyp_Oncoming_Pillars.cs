using System.Collections;
using System.Collections.Generic;
using Assets._memberSpaces.nvp.Scripts._AbstractBaseClasses;
using nvp.events;
using UnityEngine;

public class TestScript_Prototyp_Oncoming_Pillars : AbstractEventHandler
{
    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Awake()
    {
        SubscribeToEvents();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }





    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    protected override void OnDisable()
    {
        base.OnDisable();
        UnsubscribeFromEvents();
    }

    private void OnDebugMsg(object arg1, object arg2)
    {
        Debug.Log("OnDebugMessage received");
    }


    protected override void SubscribeToEvents()
    {
        EventController?.SubscribeToEvent(NvpGameEvents.OnDebugMsg, OnDebugMsg);
    }

    protected override void UnsubscribeFromEvents()
    {
        EventController?.UnsubscribeFromEvent(NvpGameEvents.OnDebugMsg, OnDebugMsg);
    }

    
}
