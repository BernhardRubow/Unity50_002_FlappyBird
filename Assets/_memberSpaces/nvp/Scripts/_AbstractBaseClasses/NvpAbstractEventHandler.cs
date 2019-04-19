using nvp.Interfaces;
using UnityEngine;
using Zenject;

namespace nvp_AbstractBaseClasses
{
    public abstract class NvpAbstractEventHandler : MonoBehaviour
    {
        protected global::nvp.Interfaces.IEventController EventController;

        [Inject]
        public void Contruct(global::nvp.Interfaces.IEventController eventController)
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