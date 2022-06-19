using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private SpawnPoint _spawnPointWest;
    [SerializeField] private SpawnPoint _spawnPointEast;
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
            _spawnPointWest.SpawnEnemy();
            yield return delay;
            _spawnPointEast.SpawnEnemy();
            yield return delay;
        }
    }
}
