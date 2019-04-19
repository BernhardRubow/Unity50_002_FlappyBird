using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlappyBird.Events;

namespace FlappyBird.Interfaces
{

    public interface IEventController
    {
        void SubscribeToEvent(NvpGameEvents e, Action<object, object> callback);
        void UnsubscribeFromEvent(NvpGameEvents e, Action<object, object> observer);
        void InvokeEvent(NvpGameEvents e, object sender, object eventArgs);
        void Reset();
    }

}
