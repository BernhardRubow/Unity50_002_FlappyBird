using nvp.Scripts.Interfaces;
using UnityEngine;

namespace nvp.Scripts.Game
{
    public class NvpVerticalPositionSetter : IVerticalPositionSetter
    {
        public float GetVerticalPosition()
        {
            return Random.Range(2f, -2f);
        }
    }
}