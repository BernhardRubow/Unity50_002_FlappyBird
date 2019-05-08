using System.Collections;
using System.Collections.Generic;
using nvp.Assets.EventHandling;
using UnityEngine;
using Zenject;

namespace nvp.Assets.EventHandling
{

    public abstract class NvpAbstractEventHandler : MonoBehaviour
    {
        protected IEventController EventController;

        [Inject]
        public void Contruct(IEventController eventController)
        {
            EventController = eventController;
        }

        protected virtual void Start()
        {
            SubscribeToEvents();
        }

        protected virtual void OnDisable()
        {
            UnsubscribeFromEvents();
        }

        protected abstract void SubscribeToEvents();

        protected abstract void UnsubscribeFromEvents();
    }
}
