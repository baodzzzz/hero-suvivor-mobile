using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Minions
{
    public class MinionSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefabsMinion;
        [SerializeField] private GameObject prefabsMover;
        [SerializeField] private GameObject prefabsPuzzler;

        public const int SpawnBorderSize = 100;

        private Timer _spawnTimer;
        private Timer _delayTimer;

        private float _minSpawnX;
        private float _maxSpawnX;
        private float _minSpawnY;
        private float _maxSpawnY;
        private Camera _camera;
        private Vector3 _spawnPosition;

        // Start is called before the first frame update
        void Start()
        {
            _camera = Camera.main;
            _minSpawnX = SpawnBorderSize;
            _maxSpawnX = Screen.width - SpawnBorderSize;
            _minSpawnY = SpawnBorderSize;
            _maxSpawnY = Screen.height - SpawnBorderSize;

            _spawnTimer = gameObject.AddComponent<Timer>();
            _delayTimer = gameObject.AddComponent<Timer>();
            _spawnTimer.Duration = 2;
            _spawnTimer.Run();
            _spawnPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (!_spawnTimer.Finished) return;
            Spawner();
            _spawnTimer.Duration = 1;
            _spawnTimer.Run();
        }

        private void Spawner()
        {
            var miLocation = RandomAxis();
            var mLocation = RandomAxis();
            var pLocation = RandomAxis();

            var minion = Instantiate(prefabsMinion, _spawnPosition, Quaternion.identity);
            var mover = Instantiate(prefabsMover, _spawnPosition, Quaternion.identity);
            var puzzler = Instantiate(prefabsPuzzler, _spawnPosition, Quaternion.identity);
            minion.transform.position = _camera.ScreenToWorldPoint(miLocation);

            mover.transform.position = _camera.ScreenToWorldPoint(mLocation);

            puzzler.transform.position = _camera.ScreenToWorldPoint(pLocation);
        }

        private Vector3 RandomAxis()
        {
            var rand = Random.value;
            if (rand >= 0.5f)
            {
                if (rand >= 0.75f)
                {
                    return new Vector3(Random.Range(_minSpawnX, _maxSpawnX), _minSpawnY,
                        -_camera.transform.position.z);
                }

                return new Vector3(_maxSpawnX, Random.Range(_minSpawnY, _maxSpawnY),
                    -_camera.transform.position.z);
            }

            if (rand <= 0.25f)
            {
                return new Vector3(Random.Range(_minSpawnX, _maxSpawnX), _maxSpawnY,
                    -_camera.transform.position.z);
            }

            return new Vector3(_minSpawnX, Random.Range(_minSpawnY, _maxSpawnY),
                -_camera.transform.position.z);
        }
    }
}