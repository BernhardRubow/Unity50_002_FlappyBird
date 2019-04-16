using nvp.Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace Assets._memberSpaces.nvp.Scripts._AbstractBaseClasses
{
    public abstract class AbstractEventHandler : MonoBehaviour
    {
        protected IEventController EventController;

        [Inject]
        public void Contruct(IEventController eventController)
        {
            EventController = eventController;
        }


        protected virtual void OnDisable()
        {
            EventController.Reset();
            EventController = null;
        }

        protected abstract void SubscribeToEvents();

        protected abstract void UnsubscribeFromEvents();
    }
}