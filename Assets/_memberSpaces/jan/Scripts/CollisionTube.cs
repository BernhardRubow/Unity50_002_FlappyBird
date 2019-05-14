using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTube : MonoBehaviour
{
    public BirdMove movement;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Obstacle")
        {
            //Debug.Log("Hit Tube!");
            movement.enabled = false;

        }
    }
}
