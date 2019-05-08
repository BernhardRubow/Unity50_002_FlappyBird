using System;
using System.Collections;
using System.Collections.Generic;
using FlappyBird.Events;
using UnityEngine;

namespace nvp.Assets.EventHandling
{
    public class NvpEventController : IEventController
    {

        // +++ private fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private Dictionary<int, List<Action<object, object>>> _eventCallbacks;




        // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public NvpEventController()
        {
            _eventCallbacks = new Dictionary<int, List<Action<object, object>>>();
        }

        ~NvpEventController()
        {
            _eventCallbacks = null;
        }




        // +++ public class methods +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void SubscribeToEvent(int e, Action<object, object> callback)
        {
            if (!_eventCallbacks.ContainsKey(e))
            {
                _eventCallbacks[e] = new List<Action<object, object>>();
            }

            _eventCallbacks[e].Add(callback);
        }

        public void UnsubscribeFromEvent(int e, Action<object, object> observer)
        {
            if (!_eventCallbacks.ContainsKey(e)) return;

            if (!_eventCallbacks[e].Contains(observer)) return;

            _eventCallbacks[e].Remove(observer);
        }

        public void InvokeEvent(int e, object sender, object eventArgs)
        {
            if (!_eventCallbacks.ContainsKey(e)) return;

            foreach (var observer in _eventCallbacks[e])
                observer(sender, eventArgs);
        }

        public void Reset()
        {
            _eventCallbacks = new Dictionary<int, List<Action<object, object>>>();
        }
    }
}
