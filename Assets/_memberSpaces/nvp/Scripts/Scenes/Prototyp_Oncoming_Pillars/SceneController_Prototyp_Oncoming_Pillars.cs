using System.Collections;
using System.Collections.Generic;
using Assets._memberSpaces.nvp.Scripts._AbstractBaseClasses;
using nvp.events;
using UnityEngine;
using Zenject;

public class SceneController_Prototyp_Oncoming_Pillars : AbstractEventHandler
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    



    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Awake()
    {
        SubscribeToEvents();
    }

    void Start()
    {
        EventController.InvokeEvent(NvpGameEvents.OnDebugMsg, this, "Hello, World!");
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




    // +++ class member +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    protected override void SubscribeToEvents()
    {
        
    }

    protected override void UnsubscribeFromEvents()
    {
        
    }
}
