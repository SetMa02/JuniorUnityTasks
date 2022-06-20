using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private EnemySpawner _enemySpawnerWest;
        [SerializeField] private EnemySpawner _enemySpawnerEast;
        [SerializeField] private float _delay;

        private void Start()
        {
            StartCoroutine(Spawn());
        }

        public void SpawnEnemy()
        {
            GameObject.Instantiate(_enemy, gameObject.transform, false);
        }
        
        private IEnumerator Spawn()
        {
            WaitForSeconds delay = new WaitForSeconds(_delay);
            while (true)
            {
                _enemySpawnerWest.SpawnEnemy();
                yield return delay;
                _enemySpawnerEast.SpawnEnemy();
                yield return delay;
            }
        }
    }
}