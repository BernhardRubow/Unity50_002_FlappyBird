using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NvpPillarMover : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private float _horizontalSpeed;
    private Action<GameObject> returnToPoolCallback;

    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.Translate(Vector3.left * _horizontalSpeed * Time.deltaTime, Space.World);

        if (this.transform.position.x < -12)
        {
            returnToPoolCallback(this.gameObject);
        }
    }

    public void ReturnToPoolCallback(Action<GameObject> returnToPool)
    {
        returnToPoolCallback = returnToPool;
    }
}
