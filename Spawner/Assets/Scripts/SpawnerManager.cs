using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private Spawner _spawnerWest;
    [SerializeField] private Spawner _spawnerEast;
    [SerializeField] private float _delay;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            _spawnerWest.SpawnEnemy();
            yield return new WaitForSeconds(_delay);
            _spawnerEast.SpawnEnemy();
            yield return new WaitForSeconds(_delay);
        }
    }
}
