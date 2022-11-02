using System;
using UnityEngine;

namespace Script.Skill
{
    public class Fireball : MonoBehaviour
    {
        private float _speed;
        private GameObject _player;
        private SpriteRenderer _fireballSpr;
        private Vector3 _fireballPos, _playerPos;

        private const int SpawnBorderSize = 100;
        private float _minSpawnX;
        private float _maxSpawnX;
        private float _minSpawnY;
        private float _maxSpawnY;
        private Camera _camera;

        // Start is called before the first frame update
        void Start()
        {
            _camera = Camera.main;
            _minSpawnX = SpawnBorderSize;
            _maxSpawnX = Screen.width - SpawnBorderSize;
            _minSpawnY = SpawnBorderSize;
            _maxSpawnY = Screen.height - SpawnBorderSize;
            _speed = 5f;
            _player = GameObject.FindGameObjectWithTag("Player");
            _fireballSpr = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            _fireballPos = transform.position;
            _playerPos = _player.transform.position;
            transform.Translate(_playerPos * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("MainCamera"))
            {
                Destroy(gameObject);
            }
            
        }
    }
}