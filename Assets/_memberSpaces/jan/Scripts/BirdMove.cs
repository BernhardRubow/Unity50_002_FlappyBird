using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.Assets.EventHandling;


public class BirdMove : NvpAbstractEventHandlerV2
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
    protected override void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        base.Start();
    }

    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = Vector2.up * _velocity;
        }

        _birdRotation.z = _rb.velocity.y * _turnFactor;
        _bird_Visual.eulerAngles = _birdRotation;

        //Debug.Log(_rb.velocity.y * _turnFactor);
    }

    protected override void StartListenToEvents()
    {
        EventController.StartListenForEvent("HitTube".GetHashCode(), EnabledMovement);
    }

    protected override void StopListenToEvents()
    {
        EventController.StopListenForEvent("HitTube".GetHashCode(), EnabledMovement);
    }

    void EnabledMovement(object s, object e)
    {
        this.enabled = false;
    }
}
