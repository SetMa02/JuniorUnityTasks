using UnityEngine;

namespace DefaultNamespace
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private GameObject _enemy;

        public void SpawnEnemy()
        {
            GameObject.Instantiate(_enemy, gameObject.transform, false);
        }
    }
}