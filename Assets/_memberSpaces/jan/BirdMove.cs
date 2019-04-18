using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    // +++ inspector fields +++
    [SerializeField] private float _velocity;
    [SerializeField] private Transform _bird_Visual;
    [SerializeField] private float _turnFactor;

    // +++ private fields +++
    private Rigidbody2D _rb;
    public Vector3 _birdRotation = Vector3.zero;
    




    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = Vector2.up * _velocity;
        }

        _birdRotation.z = _rb.velocity.y * _turnFactor;
        _bird_Visual.eulerAngles = _birdRotation;

        Debug.Log(_rb.velocity.y * _turnFactor);
    }
    
}
