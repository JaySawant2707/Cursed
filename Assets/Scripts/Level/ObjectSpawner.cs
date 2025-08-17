using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] List<GameObject> prefabs;
    [SerializeField]  int poolSize = 10;
    [SerializeField]  float spawnInterval = 2f;
    [SerializeField]  Transform spawnPoint;

    private List<GameObject> pool;

    private void Start()
    {
        pool = new List<GameObject>(poolSize);
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefabs[Random.Range(0, prefabs.Count-1)]);
            obj.SetActive(false);
            pool.Add(obj);
        }

        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        int index = 0;

        while (true)
        {
            GameObject obj = pool[index];
            Vector3 spawnPos = spawnPoint ? spawnPoint.position : transform.position;

            obj.transform.position = spawnPos;
            obj.transform.rotation = Quaternion.identity;
            obj.SetActive(true);

            index = (index + 1) % poolSize;

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
