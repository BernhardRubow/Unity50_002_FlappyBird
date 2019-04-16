using System.Collections.Generic;
using UnityEngine;

namespace nvp.Scripts.Tools.Pooling
{
    public class NvpGameObjectPool
    {
        // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private readonly Queue<GameObject> _pool;



        // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public NvpGameObjectPool()
        {
            _pool = new Queue<GameObject>();
        }




        // +++ class member +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void ReturnToPool(GameObject go)
        {
            go.SetActive(false);
            _pool.Enqueue(go);
        }

        public GameObject GetFromPool()
        {
            if (_pool.Count > 0)
            {
                return _pool.Dequeue();
            }

            return null;
        }
    }
}
