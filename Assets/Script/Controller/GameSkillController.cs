using UnityEngine;

namespace Script.Controller
{
    public class GameSkillController : MonoBehaviour
    {
        [SerializeField] Transform player;
        [SerializeField] GameObject prefabWhipAttack;
        [SerializeField] GameObject prefabThienThach;
        [SerializeField] GameObject prefabPhaoHoa;
        private  float LifeSeconds = 0.1f;
        private Timer deathTimerQ;
        private Timer deathTimerW;
        private Timer deathTimerE;
        private Timer deathTimerR;
        private Timer deathTimerX;
        private GameObject crep;
        const int SpawnBorderSize = 100;
        int minSpawnX;
        int maxSpawnX;
        int minSpawnY;
        int maxSpawnY;
        private Vector2 direction { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            minSpawnX = SpawnBorderSize;
            maxSpawnX =Screen.width *2/3 - SpawnBorderSize;
            minSpawnY = SpawnBorderSize;
            maxSpawnY = Screen.height - SpawnBorderSize;


            deathTimerQ = gameObject.AddComponent<Timer>();
            deathTimerQ.Duration = 1; // need change
            deathTimerQ.Run();

            deathTimerE = gameObject.AddComponent<Timer>();
            deathTimerE.Duration = 2; // need change
            deathTimerE.Run();

            deathTimerW = gameObject.AddComponent<Timer>();
            deathTimerW.Duration = 3; // need change
            deathTimerW.Run();

            deathTimerR = gameObject.AddComponent<Timer>();
            deathTimerR.Duration = 4; // need change
            deathTimerR.Run();

            crep = GameObject.FindGameObjectWithTag("Minion");
        }

        // Update is called once per frame
        void Update()
        {
            /*if (!crep) return;
            var distance = Vector3.Distance(crep.transform.position, transform.position);
            if (distance < 10f)
            {
                prefabWhipAttack.transform.position =
                    Vector2.MoveTowards(transform.position, crep.transform.position, Time.deltaTime * 3f);
            }*/

        }


        public void ActiveSkillQ()
        {
            var angle = Random.Range(0, Mathf.PI * 2);
            var direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            if (deathTimerQ.Finished)
            {
                var Bullet = Instantiate(prefabWhipAttack, player.position, Quaternion.identity) as GameObject;
                Bullet.GetComponent<Rigidbody2D>().AddForce(direction * 4f, ForceMode2D.Impulse);
                deathTimerQ.Duration =1; // need change
                deathTimerQ.Run();
            }
        }
        public void ActiveSkillW()
        {
            Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX),
         Random.Range(minSpawnY, maxSpawnY),
         -Camera.main.transform.position.z);
            Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
            if (deathTimerW.Finished)
            {             
                GameObject thienthach = Instantiate(prefabThienThach, transform.position, Quaternion.identity) as GameObject;
                thienthach.transform.position = worldLocation;
               /* var distance = Vector3.Distance(crep.transform.position, transform.position);
                if (distance < 10f)
                {
                    prefabThienThach.transform.position =
                        Vector2.MoveTowards(transform.position, crep.transform.position, Time.deltaTime * 3f);
                }*/
                deathTimerW.Duration = 2; // need change
                deathTimerW.Run();
            }
        }
        public void ActiveSkillE()
        {
            var angle = Random.Range(0, Mathf.PI * 2);
            var direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            if (deathTimerE.Finished)
            {
                var Bullet = Instantiate(prefabPhaoHoa, player.position, Quaternion.identity) as GameObject;
                Bullet.GetComponent<Rigidbody2D>().AddForce(direction * 3f, ForceMode2D.Impulse);
                /*if (!crep) return;
                var distance = Vector3.Distance(crep.transform.position, transform.position);
                if (distance < 10f)
                {
                    gameObject.transform.position =
                        Vector2.MoveTowards(transform.position, crep.transform.position, Time.deltaTime * 2f);
                }*/
                deathTimerE.Duration = 3; // need change
                deathTimerE.Run();
            }
        }

        public void setDirection(Vector2 dict)
        {
            direction = dict;
        }
    }
}