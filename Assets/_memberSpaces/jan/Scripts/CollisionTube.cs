using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.Assets.EventHandling;

public class CollisionTube : NvpAbstractEventHandlerV2
{
    //public BirdMove movement;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Obstacle")
        {
            ////Debug.Log("Hit Tube!");
            //movement.enabled = false;
            EventController.TriggerEvent("HitTube".GetHashCode(), this, null);
            
        }
    }
}
