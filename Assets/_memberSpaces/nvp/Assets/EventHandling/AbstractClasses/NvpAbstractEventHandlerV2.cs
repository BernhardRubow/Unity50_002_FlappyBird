using UnityEngine;
using Zenject;

namespace nvp.Assets.EventHandling
{
    public abstract class NvpAbstractEventHandlerV2: MonoBehaviour
    {
        protected INvpEventController EventController;

        [Inject]
        public void Contruct(INvpEventController eventController)
        {
            EventController = eventController;
        }

        protected virtual void Start()
        {
            StartListenToEvents();
        }

        protected virtual void OnDisable()
        {
            StopListenToEvents();
        }

        protected virtual void StartListenToEvents()
        {
        }

        protected virtual void StopListenToEvents()
        {
        }
    }
}