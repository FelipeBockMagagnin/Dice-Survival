using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;
    public float timer;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn() {
        while (true)
        {
            int spawner = Random.Range(0,spawnPoints.Length);
            Instantiate(enemy, spawnPoints[spawner]);
            yield return new WaitForSeconds(timer);
        }
        
    }
}
