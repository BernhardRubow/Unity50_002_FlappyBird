using UnityEngine;

namespace nvp.Assets.PillarGenerator
{
    public class NvpVerticalPositionSetter : IVerticalPositionSetter
    {
        public float GetVerticalPosition()
        {
            return Random.Range(2f, -2f);
        }
    }
}