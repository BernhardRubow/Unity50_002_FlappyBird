using System;
using nvp.Scripts.Tools.Events;

namespace nvp.Scripts.Interfaces
{
    public interface IEventController
    {
        void SubscribeToEvent(NvpGameEvents e, Action<object, object> callback);
        void UnsubscribeFromEvent(NvpGameEvents e, Action<object, object> observer);
        void InvokeEvent(NvpGameEvents e, object sender, object eventArgs);
        void Reset();
    }
}