using nvp_AbstractBaseClasses;
using nvp.Tools.Events;
using UnityEngine;

namespace nvp.Prototypes.Prototy_000
{

    public class TestScript_Prototyp_Oncoming_Pillars : NvpAbstractEventHandler
    {
        // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        void Awake()
        {
            SubscribeToEvents();
        }

        void Start()
        {

        }

        void Update()
        {

        }





        // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected override void OnDisable()
        {
            base.OnDisable();
            UnsubscribeFromEvents();
        }

        private void OnDebugMsg(object s, object e)
        {
            Debug.LogFormat("OnDebugMessage received {0}", e);
        }


        protected override void SubscribeToEvents()
        {
            EventController?.SubscribeToEvent(NvpGameEvents.OnDebugMsg, OnDebugMsg);
        }

        protected override void UnsubscribeFromEvents()
        {
            EventController?.UnsubscribeFromEvent(NvpGameEvents.OnDebugMsg, OnDebugMsg);
        }


    }
}
