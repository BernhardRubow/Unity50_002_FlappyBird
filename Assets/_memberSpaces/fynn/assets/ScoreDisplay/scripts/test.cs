using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.Assets.EventHandling;

public class test : NvpAbstractEventHandlerV2
{
    // Start is called before the first frame update
     protected override void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
        //EventController.TriggerEvent("onscored".GetHashCode(), this, "Hello, World!");
    }
}
