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

        // Start is called before the first frame update
        void Start()
        {
            _speed = 3f;
            _player = GameObject.FindGameObjectWithTag("Player");
            _fireballSpr = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            _fireballPos = transform.position;
            _playerPos = _player.transform.position;
            transform.Translate(_playerPos*Time.deltaTime);
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