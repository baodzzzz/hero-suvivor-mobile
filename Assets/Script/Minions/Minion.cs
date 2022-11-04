using MyNamespace;
using Script.Skill;
using UnityEngine;

namespace Script.Minions
{
    public class Minion : MonoBehaviour
    {
        private float _speed;
        [SerializeField] GameObject exp;
        private GameObject _player;
        private int _hp;
        private SmallBullet _smallBullet;
        private FireSkill _fireSkill;
        private StoneSkill _stoneSkill;
        private Uitl _uitlSkill;
        private WhipAttack _whipAttack;
        private SpriteRenderer _minionSpr;
        private Vector3 _minionPosition, _playerPosition;

        public int HP
        {
            get => _hp;
            set => _hp = value;
        }

        // Start is called before the first frame update
        private void Start()
        {
            _speed = 0.5f;
            _player = GameObject.FindGameObjectWithTag("Player");
            _hp = 10;
            _minionSpr = gameObject.GetComponent<SpriteRenderer>();
            _smallBullet = GameObject.FindGameObjectWithTag("BaseAttack").GetComponent<SmallBullet>();
            // _fireSkill = GameObject.FindGameObjectWithTag("SkillW").GetComponent<FireSkill>();
            // _stoneSkill = GameObject.FindGameObjectWithTag("StoneAttack").GetComponent<StoneSkill>();
            // _uitlSkill = GameObject.FindGameObjectWithTag("SkillUtil").GetComponent<Uitl>();
            // _whipAttack = GameObject.FindGameObjectWithTag("SkillQ").GetComponent<WhipAttack>();
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
                TakeDamage(15);
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