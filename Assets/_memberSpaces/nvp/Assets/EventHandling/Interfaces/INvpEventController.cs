using UnityEngine.Events;

namespace nvp.Assets.EventHandling
{
    public interface INvpEventController
    {
        void StartListenForEvent(int e, UnityAction<object, object> listener);
        void StopListenForEvent(int e, UnityAction<object, object> listener);
        void TriggerEvent(int e, object sender, object EventArgs);
        void Reset();
    }
}