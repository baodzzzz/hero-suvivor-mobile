﻿using System;
using MyNamespace;
using Script.Skill;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Minions
{
    public class Puzzler : MonoBehaviour
    {
        private float _speed;

        private GameObject _player;
        private Vector3 _breakpoint;
        private Vector3 _screenBound;
        private int _counter;
        
        private int _hp;
        private SmallBullet _smallBullet;
        private WhipAttack _whipAttack;
        private SpriteRenderer _minionSpr;
        private Vector3 _minionPosition, _playerPosition;

        // Start is called before the first frame update
        private void Start()
        {
            _counter = 0;
            _speed = 1.5f;
            _player = GameObject.FindGameObjectWithTag("Player");
            _breakpoint = new Vector3(Random.Range(-_screenBound.x, _screenBound.x),
                Random.Range(-_screenBound.y, _screenBound.y), 0);
            if (Camera.main != null)
                _screenBound =
                    Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
                        Camera.main.transform.position.z));
            _hp = 50;
            _minionSpr = gameObject.GetComponent<SpriteRenderer>();
            _smallBullet = GameObject.FindGameObjectWithTag("SmallBullet").GetComponent<SmallBullet>();
            // _whipAttack = GameObject.FindGameObjectWithTag("WhipAttack").GetComponent<WhipAttack>();
        }

        // Update is called once per frame
        private void Update()
        {
            _minionPosition = transform.position;
            _playerPosition = _player.transform.position;
            _minionSpr.flipX = _minionPosition.x > _playerPosition.x;
            if (_counter >= 5)
            {
                _speed = 3f;
                transform.position =
                    Vector2.MoveTowards(transform.position, _player.transform.position, Time.deltaTime * _speed);
                return;
            }

            if (transform.position == _breakpoint)
            {
                _counter += 1;
                _breakpoint = new Vector3(Random.Range(-_screenBound.x, _screenBound.x),
                    Random.Range(-_screenBound.y, _screenBound.y), 0);
            }

            transform.position = Vector2.MoveTowards(transform.position, _breakpoint,
                Time.deltaTime * _speed);
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("SmallBullet"))
            {
                TakeDamage(_smallBullet.Damage);
            }

            if (col.gameObject.CompareTag("WhipAttack"))
            {
                // TakeDamage(_whipAttack.Damage);
            }
        }
        
        
        private void TakeDamage(int damageAmount)
        {
            _hp -= damageAmount;
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}