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
        [SerializeField] private GameObject prefabDragonBoss;

        private const int SpawnBorderSize = 100;

        private Timer _spawnTimer, _delaySpawnTimer, _bossSpawner;

        private float _minSpawnX;
        private float _maxSpawnX;
        private float _minSpawnY;
        private float _maxSpawnY;
        private Camera _camera;
        private Vector3 _spawnPosition;
        private GameObject _bossMinionObject;
        private Minion _bossMinion;

        // Start is called before the first frame update
        void Start()
        {
            _camera = Camera.main;
            _minSpawnX = SpawnBorderSize;
            _maxSpawnX = Screen.width - SpawnBorderSize;
            _minSpawnY = SpawnBorderSize;
            _maxSpawnY = Screen.height - SpawnBorderSize;

            _spawnTimer = gameObject.AddComponent<Timer>();
            _delaySpawnTimer = gameObject.AddComponent<Timer>();
            _spawnTimer.Duration = 2;
            _spawnTimer.Run();
            _spawnPosition = transform.position;
            _bossSpawner = gameObject.AddComponent<Timer>();
            _bossSpawner.Duration = 10;
            _bossSpawner.Run();
            _bossMinionObject = GameObject.FindGameObjectWithTag("Boss");
        }

        // Update is called once per frame
        void Update()
        {
            MushroomSpawner();
        }

        private void Spawner()
        {
            var miLocation = RandomAxis();
            var minion = Instantiate(prefabsMinion, miLocation, Quaternion.identity);
            minion.transform.position = _camera.ScreenToWorldPoint(miLocation);
            // var pLocation = RandomAxis();
            // var puzzler = Instantiate(prefabsPuzzler, _spawnPosition, Quaternion.identity);
            // puzzler.transform.position = _camera.ScreenToWorldPoint(pLocation);
            // var mLocation = RandomAxis();
            // var mover = Instantiate(prefabsMover, _spawnPosition, Quaternion.identity);
            // mover.transform.position = _camera.ScreenToWorldPoint(mLocation);
        }

        private void MushroomSpawner()
        {
            var miLocation = RandomAxis();
            if (_bossSpawner.Finished)
            {
                var bossMinion = Instantiate(prefabDragonBoss, _spawnPosition, Quaternion.identity);
                bossMinion.transform.position = _camera.ScreenToWorldPoint(miLocation);
                _bossSpawner.Duration = 10;
                _bossSpawner.Run();
            }

            if (!_spawnTimer.Finished) return;
            var minion = Instantiate(prefabsMinion, _spawnPosition, Quaternion.identity);
            minion.transform.position = _camera.ScreenToWorldPoint(miLocation);
            _spawnTimer.Duration = 1;
            _spawnTimer.Run();
        }

        private Vector3 RandomAxis()
        {
            var rand = Random.value;
            var cameraPositionZ = _camera.transform.position.z;
            return rand switch
            {
                >= 0.5f and >= 0.75f => new Vector3(Random.Range(_minSpawnX, _maxSpawnX), _minSpawnY,
                    -cameraPositionZ),
                >= 0.5f => new Vector3(_maxSpawnX, Random.Range(_minSpawnY, _maxSpawnY), -cameraPositionZ),
                <= 0.25f => new Vector3(Random.Range(_minSpawnX, _maxSpawnX), _maxSpawnY,
                    -cameraPositionZ),
                _ => new Vector3(_minSpawnX, Random.Range(_minSpawnY, _maxSpawnY), -cameraPositionZ)
            };
        }
    }
}