using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nvp.Prefabs.Pillars
{
    public class NvpPillarMover : MonoBehaviour
    {
        // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        [SerializeField] private float _horizontalSpeed;
        [SerializeField] private float _leftMovementBorder;
        private Action<GameObject> returnToPoolCallback;

        void Start()
        {

        }


        void Update()
        {
            this.transform.Translate(Vector3.left * _horizontalSpeed * Time.deltaTime, Space.World);

            if (this.transform.position.x < _leftMovementBorder)
            {
                returnToPoolCallback(this.gameObject);
            }
        }

        public void ReturnToPoolCallback(Action<GameObject> returnToPool)
        {
            returnToPoolCallback = returnToPool;
        }
    }
}
