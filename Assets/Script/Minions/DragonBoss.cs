using MyNamespace;
using Script.Skill;
using UnityEditor.Animations;
using UnityEngine;

namespace Script.Minions
{
    public class DragonBoss : MonoBehaviour
    {
        [SerializeField] private GameObject prefabFireBall;
        private float _bulletSpeed;
        
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

        public int HP
        {
            get => _hp;
            set => _hp = value;
        }

        // Start is called before the first frame update
        private void Start()
        {
            _bulletSpeed = 5f;
            _animator = gameObject.GetComponent<Animator>();
            _skillDownDuration = gameObject.AddComponent<Timer>();
            _skillDownCooldown = gameObject.AddComponent<Timer>();
            _skillMountDuration = gameObject.AddComponent<Timer>();
            _skillMountCooldown = gameObject.AddComponent<Timer>();
            _speed = 0.3f;
            _player = GameObject.FindGameObjectWithTag("Player");
            _hp = 200;
            _minionSpr = gameObject.GetComponent<SpriteRenderer>();
            _smallBullet = GameObject.FindGameObjectWithTag("SmallBullet").GetComponent<SmallBullet>();
            // _whipAttack = GameObject.FindGameObjectWithTag("WhipAttack").GetComponent<WhipAttack>();
            // _skillDownDuration.Duration = 5;
            // _skillDownDuration.Run();
            _skillMountDuration.Duration = 5;
            _skillMountDuration.Run();
        }

        // Update is called once per frame
        private void Update()
        {
            if (_skillMountDuration.Finished)
            {
                var fireBall = Instantiate(prefabFireBall, transform.position, Quaternion.identity);
                
            }
            
            _minionPosition = transform.position;
            _playerPosition = _player.transform.position;
            _minionSpr.flipX = _minionPosition.x > _playerPosition.x;
            transform.position =
                Vector2.MoveTowards(_minionPosition, _playerPosition, Time.deltaTime * _speed);
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
