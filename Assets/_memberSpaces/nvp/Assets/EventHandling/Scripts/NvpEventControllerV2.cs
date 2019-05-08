using System;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine.Events;
using Zenject;

namespace nvp.Assets.EventHandling
{
    public class NvpEventControllerV2 : INvpEventController
    {
        // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private Dictionary<int, NvpEvent> _eventDictionary;




        // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public NvpEventControllerV2()
        {
            _eventDictionary = new Dictionary<int, NvpEvent>();
        }




        // +++ INvpEventController implementation +++++++++++++++++++++++++++++++++++++++++++++++++
        public void StartListenForEvent(int e, UnityAction<object, object> listener)
        {
            if (_eventDictionary.TryGetValue(e, out var eventInstance))
            {
                eventInstance.AddListener(listener);
            }
            else
            {
                eventInstance = new NvpEvent();
                eventInstance.AddListener(listener);
                _eventDictionary.Add(e, eventInstance);
            }
        }

        public void StopListenForEvent(int e, UnityAction<object, object> listener)
        {
            if (_eventDictionary.TryGetValue(e, out var eventInstance))
            {
                eventInstance.RemoveListener(listener);
            }
        }

        public void TriggerEvent(int e, object sender, object eventArgs)
        {
            if (_eventDictionary.TryGetValue(e, out var eventInstance))
            {
                eventInstance.Invoke(sender, eventArgs);
            }
        }

        public void Reset()
        {
            _eventDictionary = new Dictionary<int, NvpEvent>();
        }
    }
}