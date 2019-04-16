using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NvpPillarGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _pillarSpawnPoint;

    [SerializeField] private GameObject[] _pillarTypes;

    [SerializeField] private float _timeBetweenSpawns;

    Queue<Transform> _pool = new Queue<Transform>();


    void Start()
    {
        Queue<Transform> _pool = new Queue<Transform>();
        StartCoroutine(SpawnPillar());
    }

    void Update()
    {

    }

    IEnumerator SpawnPillar()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeBetweenSpawns);

            GameObject pillar = null;
            if (_pool.Count < 1)
            {
                pillar = GameObject.Instantiate(
                    _pillarTypes[Random.Range(0, _pillarTypes.Length)],
                    _pillarSpawnPoint.transform.position,
                    Quaternion.identity);
            }
            else
            {
                pillar = _pool.Dequeue().gameObject;
                pillar.SetActive(true);
                pillar.transform.position = _pillarSpawnPoint.transform.position;
            }

            pillar.GetComponent<NvpPillarMover>().SetReturnCallback(ReturnToPool);

        }
    }

    private void ReturnToPool(Transform t)
    {
        _pool.Enqueue(t);
    }
}
