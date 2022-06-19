using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private SpawnPoint spawnPointWest;
    [SerializeField] private SpawnPoint spawnPointEast;
    [SerializeField] private float _delay;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);
        while (true)
        {
            spawnPointWest.SpawnEnemy();
            yield return delay;
            spawnPointEast.SpawnEnemy();
            yield return delay;
        }
    }
}
