using System.Collections;
using System.Collections.Generic;
using nvp.Scripts.Tools.Pooling;
using UnityEngine;

public class NvpPillarGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _pillarSpawnPoint;

    [SerializeField] private GameObject[] _pillarTypes;

    [SerializeField] private float _timeBetweenSpawns;

    private NvpGameObjectPool _pillarPool;


    void Start()
    {
        _pillarPool = new NvpGameObjectPool();
        StartCoroutine(SpawnPillar());
    }

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
        }
    }
}
