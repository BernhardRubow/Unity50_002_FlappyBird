using System.Collections;
using System.Collections.Generic;
using nvp.Interfaces;
using nvp.Scripts.Tools.Pooling;
using UnityEngine;

namespace nvp.Prefabs.Pillars
{
    public class NvpPillarGenerator : MonoBehaviour
    {

        // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        [SerializeField] private GameObject _pillarSpawnPoint;
        [SerializeField] private GameObject[] _pillarTypes;
        [SerializeField] private float _timeBetweenSpawns;
        private NvpGameObjectPool _pillarPool;
        private IVerticalPositionSetter _verticalPositionSetter;
        



        // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        void Start()
        {
            _verticalPositionSetter = new NvpVerticalPositionSetter();
            _pillarPool = new NvpGameObjectPool();
            StartCoroutine(SpawnPillar());
        }




        // +++ co-routines ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        IEnumerator SpawnPillar()
        {
            while (true)
            {
                yield return new WaitForSeconds(_timeBetweenSpawns);

                GameObject pillar = _pillarPool.GetFromPool();
                if (pillar == null)
                {
                    // pool has not returned an item
                    pillar = Instantiate(
                        _pillarTypes[Random.Range(0, _pillarTypes.Length)],
                        _pillarSpawnPoint.transform.position,
                        Quaternion.identity);

                    // set the callback to return the item to the pool
                    pillar.GetComponent<NvpPillarMover>().ReturnToPoolCallback(_pillarPool.ReturnToPool);
                }
                else
                {
                    // pool has returned an item
                    pillar.SetActive(true);
                    pillar.transform.position = _pillarSpawnPoint.transform.position;
                }

                ModifyVerticalPosition(pillar);
            }
        }




        // +++ class member +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void ModifyVerticalPosition(GameObject pillar)
        {
            var tempPos = pillar.transform.position;
            tempPos.y = _verticalPositionSetter.GetVerticalPosition();
            pillar.transform.position = tempPos;
        }
    }
}
