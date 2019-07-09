using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using nvp.Assets.EventHandling;
using UnityEngine.SceneManagement;

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
    private float verticalThreshold = 11;
    public bool birdLiving { get; protected set; } = true;
    private long dieTime = -1;
    private readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    public long timeSpendDeadOnScreenInMillis = 3000;
    bool isActivated = false;

    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    protected override void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Kinematic;
        base.Start();
    }

    void Update()
    {
        // do some math stuff that the tube movement gets slower and slower

        if (!isActivated)
        {
            isActivated = true;
        
            StartCoroutine(EnableGravityandMovement());
            return;
        }
        else
        {
            long dieTimeOffset = unixTimeMillis() - dieTime;
            if (birdLiving == false &&
                !(Mathf.Abs(_bird_Visual.position.y) > verticalThreshold)
                )
            {
                // to be honest, i have no real idea what this is
                // it's just math stuff to rotate everything
                float thresholdDistance = _bird_Visual.position.y / verticalThreshold;
                if (thresholdDistance < 0.0f)
                    thresholdDistance = 0.0f;
                foreach (GameObject o in Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Pillar_Top_Bottom(Clone)"))
                {
                    float tmp = -thresholdDistance * 0.0025f;
                    o.GetComponent<Transform>().Translate(new Vector3(tmp, 0.0f, 0.0f));
                    tmp *= -75.0f;
                    _turnFactor += tmp;
                }

            }
            else if (
              birdLiving == false &&
              dieTimeOffset >= timeSpendDeadOnScreenInMillis // to prevent instant highscore list when touching the bottom of the screen
              )
            { // if the bird isn't anymore on the screen and dead
                StopListenToEvents();
                //StartCoroutine(LoadSceneAsync("05_HighScores"));
                // load the scene async because then it's kinda like a fade
                // out that you see you failed a little bit longer and you
                // get a more smooth and clean swap to the next scene
            }
        }

        if (birdLiving == true && (
            Input.GetKeyDown(KeyCode.Space) ||
            Input.GetMouseButtonDown(0) // 0 = left mouse button
            ))
        {
            _rb.velocity = Vector2.up * _velocity;
            EventController.TriggerEvent(EventIdNorm.Hash("nvp", "movePressed"), this, null);
        }

        _birdRotation.z = _rb.velocity.y * _turnFactor;
        _bird_Visual.eulerAngles = _birdRotation;
        //Debug.LogFormat("Y: {0}", this.transform.position.y);
        //Debug.Log(_rb.velocity.y * _turnFactor);

        if (Mathf.Abs(this.transform.position.y) > verticalThreshold && birdLiving == true)
            EventController.TriggerEvent(EventIdNorm.Hash("jan", "hitTUbe"), this, null);
        // we can't call enabledMovement(...) here directly because then the event based
        // sound source wouldn't work.
    }

    protected override void StartListenToEvents()
    {
        EventController.StartListenForEvent(EventIdNorm.Hash("jan", "hitTube"), EnabledMovement);
    }

    protected override void StopListenToEvents()
    {
        EventController.StopListenForEvent(EventIdNorm.Hash("jan", "hitTube"), EnabledMovement);
    }

    IEnumerator EnableGravityandMovement()
    {
        yield return new WaitForSeconds(1f);
        isActivated = true;
        _rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void EnabledMovement(object s, object e)
    {
        if (birdLiving == true) // to prevent the dieTime getting reset-ed and the highscore list being never showed
        {
            birdLiving = false;
            dieTime = unixTimeMillis();
            this.GetComponentInChildren<EdgeCollider2D>().enabled = false;
            GameObject.Find("RainbowParticles").GetComponent<ParticleSystem>().Stop(); // this will stop particle spawning and old particles will fade out
            GetComponent<RainbowFartUpdater>().enabled = false;
        }
    }

    IEnumerator LoadSceneAsync(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public long unixTimeMillis()
    {
        return (long)(DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
    }

}
