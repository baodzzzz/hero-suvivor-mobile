using System;
using MyNamespace;
using Script.Skill;
using UnityEngine;

namespace Script.Minions
{
    public class Mover : MonoBehaviour
    {
        private float _speed;
        private GameObject _player;
        private int _hp;
        
        private SmallBullet _smallBullet;
        private WhipAttack _whipAttack;

        // Start is called before the first frame update
        private void Start()
        {
            _speed = 2f;
            _hp = 30;
            _player = GameObject.FindGameObjectWithTag("Player");
            _smallBullet = gameObject.GetComponent<SmallBullet>();
            _whipAttack = gameObject.GetComponent<WhipAttack>();
        }

        // Update is called once per frame
        private void Update()
        {
            transform.position =
                Vector2.MoveTowards(transform.position, _player.transform.position, Time.deltaTime * _speed);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag(_smallBullet.tag))
            {
                TakeDamage(_smallBullet.Damage);
            }

            if (col.gameObject.CompareTag(_whipAttack.tag))
            {
                TakeDamage(_whipAttack.Damage);
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