using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private float _startDelay;
        [SerializeField] private float _periodicity;

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
            WaitForSeconds periodicity = new WaitForSeconds(_periodicity);
            
            WaitForSeconds startDelay = new WaitForSeconds(_startDelay);

            yield return startDelay;
           
            while (true)
            {
                SpawnEnemy();
                yield return periodicity;
            }
        }
    }
}