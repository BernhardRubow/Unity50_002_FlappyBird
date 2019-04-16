using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NvpPillarMover : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private float _horizontalSpeed;
    private Action<Transform> returnToPoolCallback;

    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.Translate(Vector3.left * _horizontalSpeed * Time.deltaTime, Space.World);

        if (this.transform.position.x < -12)
        {
            this.gameObject.SetActive(false);
            returnToPoolCallback(this.transform);
        }
    }

    public void SetReturnCallback(Action<Transform> returnToPool)
    {
        returnToPoolCallback = returnToPool;
    }
}
