using UnityEngine;

namespace Script.Controller
{
    public class GameSkillController : MonoBehaviour
    {
        [SerializeField] Transform player;
        [SerializeField] GameObject prefabWhipAttack;
        private const float LifeSeconds = 1f;
        private Timer deathTimer;
        private GameObject crep;

        private Vector2 direction { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            deathTimer = gameObject.AddComponent<Timer>();
            deathTimer.Duration = LifeSeconds;
            deathTimer.Run();
            crep = GameObject.FindGameObjectWithTag("Minion");
        }

        // Update is called once per frame
        void Update()
        {
            float distance = Vector3.Distance(crep.transform.position, gameObject.transform.position);
            if (distance < 10f)
            {
                prefabWhipAttack.transform.position =
                    Vector2.MoveTowards(transform.position, crep.transform.position, Time.deltaTime * 3f);
            }
        }


        public void ActiveSkill()
        {
            var angle = Random.Range(0, Mathf.PI * 2);
            var direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            if (!deathTimer.Finished) return;
            var Bullet = Instantiate(prefabWhipAttack, player.position, Quaternion.identity) as GameObject;
            Bullet.GetComponent<Rigidbody2D>().AddForce(direction * 3f, ForceMode2D.Impulse);
            deathTimer.Duration = LifeSeconds;
            deathTimer.Run();
        }

        public void setDirection(Vector2 dict)
        {
            direction = dict;
        }
    }
}