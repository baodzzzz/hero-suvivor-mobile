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
        private GameObject exp;
        private SmallBullet _smallBullet;
        private WhipAttack _whipAttack;
        private SpriteRenderer _minionSpr;
        private Vector3 _minionPosition, _playerPosition;
        private FireSkill _fireSkill;
        private StoneSkill _stoneSkill;
        private Uitl _uitlSkill;

        // Start is called before the first frame update
        private void Start()
        {
            _speed = 2f;
            _hp = 30;
            exp = GameObject.FindGameObjectWithTag("Exp");
            _player = GameObject.FindGameObjectWithTag("Player");
            _minionSpr = gameObject.GetComponent<SpriteRenderer>();
            _smallBullet = GameObject.FindGameObjectWithTag("BaseAttack").GetComponent<SmallBullet>();
            // _whipAttack = gameObject.GetComponent<WhipAttack>();
            _fireSkill = GameObject.FindGameObjectWithTag("SkillW").GetComponent<FireSkill>();
            _stoneSkill = GameObject.FindGameObjectWithTag("StoneAttack").GetComponent<StoneSkill>();
            _uitlSkill = GameObject.FindGameObjectWithTag("SkillUtil").GetComponent<Uitl>();
            _whipAttack = GameObject.FindGameObjectWithTag("SkillQ").GetComponent<WhipAttack>();
        }

        // Update is called once per frame
        private void Update()
        {
            _minionPosition = transform.position;
            _playerPosition = _player.transform.position;
            _minionSpr.flipX = _minionPosition.x > _playerPosition.x;
            transform.position =
                Vector2.MoveTowards(_minionPosition, _playerPosition, Time.deltaTime * _speed);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("BaseAttack"))
            {
                TakeDamage(_smallBullet.Damage);
            }

            if (col.gameObject.CompareTag("SkillQ"))
            {
                TakeDamage(20);
            }

            if (col.gameObject.CompareTag("SkillW"))
            {
                TakeDamage(15);
            }

            if (col.gameObject.CompareTag("StoneAttack"))
            {
                TakeDamage(30);
            }

            if (col.gameObject.CompareTag("SkillUtil"))
            {
                Destroy(gameObject);
            }

            if (col.gameObject.CompareTag("SkillR"))
            {
                // TakeDamage(50);
                Destroy(gameObject);
            }

            if (col.gameObject.CompareTag("SkillE"))
            {
                TakeDamage(25);
            }

            if (col.gameObject.CompareTag("thunderbolt"))
            {
                TakeDamage(15);
                // Destroy(gameObject);
            }
        }

        private void TakeDamage(int damageAmount)
        {
            _hp -= damageAmount;
            if (_hp <= 0)
            {
                Instantiate(exp, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}