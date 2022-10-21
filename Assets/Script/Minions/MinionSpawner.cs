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

        private Timer _spawnTimer;

        private const int SpawnerBorderSize = 100;

        private int _minSpawnX;
        private int _maxSpawnX;
        private int _minSpawnY;

        private int _maxSpawnY;
        private Camera _camera;
        private Vector3 _spawnPosition;

        // Start is called before the first frame update
        void Start()
        {
            _camera = Camera.main;
            _minSpawnX = SpawnerBorderSize;
            _maxSpawnX = Screen.width - SpawnerBorderSize;
            _minSpawnY = SpawnerBorderSize;
            _maxSpawnY = Screen.height - SpawnerBorderSize;

            _spawnTimer = gameObject.AddComponent<Timer>();
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
            var location = RandomAxis();
            var worldLocation = _camera.ScreenToWorldPoint(location);
            var circle = Instantiate(prefabsMinion, _spawnPosition, Quaternion.identity);
            var mover = Instantiate(prefabsMover, _spawnPosition, Quaternion.identity);
            var puzzler = Instantiate(prefabsPuzzler, _spawnPosition, Quaternion.identity);
            circle.transform.position = worldLocation;
            mover.transform.position = worldLocation;
            puzzler.transform.position = worldLocation;
        }

        private Vector3 RandomAxis()
        {
            if (Random.value > 0.5f)
            {
                return new Vector3(Random.Range(_minSpawnX, _maxSpawnX), 0,
                    -_camera.transform.position.z);
            }

            return new Vector3(0, Random.Range(_minSpawnY, _maxSpawnY),
                -_camera.transform.position.z);
        }
    }
}