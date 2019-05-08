using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlappyBird.Events;

namespace nvp.Assets.EventHandling
{

    public interface IEventController
    {
        void SubscribeToEvent(int e, Action<object, object> callback);
        void UnsubscribeFromEvent(int e, Action<object, object> observer);
        void InvokeEvent(int e, object sender, object eventArgs);
        void Reset();
    }
}
