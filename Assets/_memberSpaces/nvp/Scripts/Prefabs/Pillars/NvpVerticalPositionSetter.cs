using nvp.Interfaces;
using UnityEngine;

namespace nvp.Prefabs.Pillars
{
    public class NvpVerticalPositionSetter : IVerticalPositionSetter
    {
        public float GetVerticalPosition()
        {
            return Random.Range(2f, -2f);
        }
    }
}