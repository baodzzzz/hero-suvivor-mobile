using MyNamespace;
using Script.Skill;
using UnityEditor.Animations;
using UnityEngine;

namespace Script.Minions
{
    public class DragonBoss : MonoBehaviour
    {
        [SerializeField] private GameObject prefabFireBall;

        private float _speed;
        private int _hp;
        private GameObject _player;
        private SmallBullet _smallBullet;
        private WhipAttack _whipAttack;
        private SpriteRenderer _minionSpr;
        private Vector3 _minionPosition, _playerPosition;
        private Timer _skillDownDuration, _skillDownCooldown, _skillMountDuration, _skillMountCooldown;
        private Animator _animator;
        private RuntimeAnimatorController _animatorController;
        private static readonly int IsSkillDown = Animator.StringToHash("isSkillDown");
        private Camera _camera;
        private GameObject exp;
        public int HP
        {
            get => _hp;
            set => _hp = value;
        }

        // Start is called before the first frame update
        private void Start()
        {
            exp = GameObject.FindGameObjectWithTag("Exp");
            _camera = Camera.main;
            _animator = gameObject.GetComponent<Animator>();
            _skillDownDuration = gameObject.AddComponent<Timer>();
            _skillDownCooldown = gameObject.AddComponent<Timer>();
            _skillMountDuration = gameObject.AddComponent<Timer>();
            _skillMountCooldown = gameObject.AddComponent<Timer>();
            _speed = 0.3f;
            _player = GameObject.FindGameObjectWithTag("Player");
            _hp = 200;
            _minionSpr = gameObject.GetComponent<SpriteRenderer>();
            _smallBullet = GameObject.FindGameObjectWithTag("BaseAttack").GetComponent<SmallBullet>();
            // _whipAttack = GameObject.FindGameObjectWithTag("WhipAttack").GetComponent<WhipAttack>();
            // _skillDownDuration.Duration = 5;
            // _skillDownDuration.Run();
            _skillMountDuration.Duration = 3;
            _skillMountDuration.Run();
        }

        // Update is called once per frame
        private void Update()
        {
            _minionPosition = transform.position;
            _playerPosition = _player.transform.position;
            _minionSpr.flipX = _minionPosition.x > _playerPosition.x;
            if (_skillMountDuration.Finished)
            {
                Instantiate(prefabFireBall, _minionPosition, Quaternion.identity);
                _skillMountDuration.Duration = 2;
                _skillMountDuration.Run();
            }
            
            transform.position =
                Vector2.MoveTowards(transform.position, _playerPosition, Time.deltaTime * _speed);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("BaseAttack"))
            {
                TakeDamage(_smallBullet.Damage);
            }

            // if (col.gameObject.CompareTag(""))
            // {
            //     // TakeDamage(_whipAttack.Damage);
            // }
        }

        private void TakeDamage(int damageAmount)
        {
            _hp -= damageAmount;
            if (_hp <= 0)
            {
                GameObject expBoss= Instantiate(exp, transform.position, Quaternion.identity);
                expBoss.transform.localScale *= 2f;
                Destroy(gameObject);
            }
        }
    }
}