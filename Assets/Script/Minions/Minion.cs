using MyNamespace;
using Script.Skill;
using UnityEngine;

namespace Script.Minions
{
    public class Minion : MonoBehaviour
    {
        private float _speed;

        private GameObject _player;
        private int _hp;
        private SmallBullet _smallBullet;
        private WhipAttack _whipAttack;
        private SpriteRenderer _minion;
        private Vector3 _minionPosition;
        private Vector3 _playerPosition;

        // Start is called before the first frame update
        private void Start()
        {
            _speed = 0.5f;
            _player = GameObject.FindGameObjectWithTag("Player");
            _hp = 10;
            _smallBullet = GameObject.FindGameObjectWithTag("SmallBullet").GetComponent<SmallBullet>();
            _whipAttack = GameObject.FindGameObjectWithTag("WhipAttack").GetComponent<WhipAttack>();
            _minion = gameObject.GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        private void Update()
        {
            _minionPosition = transform.position;
            _playerPosition = _player.transform.position;
            _minion.flipX = _minionPosition.x > _playerPosition.x;
            transform.position =
                Vector2.MoveTowards(_minionPosition, _playerPosition, Time.deltaTime * _speed);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("SmallBullet"))
            {
                TakeDamage(_smallBullet.Damage);
                Debug.Log(_smallBullet.Damage);
            }
            
            if (col.gameObject.CompareTag("WhipAttack"))
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