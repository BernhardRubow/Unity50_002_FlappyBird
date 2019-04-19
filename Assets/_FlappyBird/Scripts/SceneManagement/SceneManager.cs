using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlappyBird.Events;


public class SceneManager : NvpAbstractEventHandler
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    
    

    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        
    }




    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnGameInitialized(object arg1, object arg2)
    {
        Debug.Log("OnGameInitialized called");
    }





    // +++ class member +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


    protected override void SubscribeToEvents()
    {
        EventController.SubscribeToEvent(NvpGameEvents.OnGameInitialized, OnGameInitialized);
    }

    protected override void UnsubscribeFromEvents()
    {
        EventController.SubscribeToEvent(NvpGameEvents.OnGameInitialized, OnGameInitialized);
    }

}
