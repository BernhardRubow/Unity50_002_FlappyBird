using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.Assets.EventHandling;

public class EventBasedSoundSourceScript : NvpAbstractEventHandlerV2
{
    private AudioSource source;
    public string eventPerson = "";
    public string eventName = "";
    public AudioClip sound;
    public bool overlappingEnabled = false;

    void onSound(object s, object e) {
        if(!source.isPlaying)
        {
            source.PlayOneShot(sound, 1.0f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        EventController.StartListenForEvent(EventIdNorm.Hash(eventPerson, eventName), onSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void StartListenToEvents()
    {
        base.StartListenToEvents();
    }

    protected override void StopListenToEvents()
    {
        base.StopListenToEvents();
    }
}
