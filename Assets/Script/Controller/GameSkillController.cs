using UnityEngine;

namespace Script.Controller
{
    public class GameSkillController : MonoBehaviour
    {
        [SerializeField] Transform player;
        [SerializeField] GameObject prefabWhipAttack;
        [SerializeField] GameObject prefabThienThach;
        [SerializeField] GameObject prefabPhaoHoa;
        [SerializeField] GameObject prefabSkillR;
        [SerializeField] GameObject prefabSkillAuto;
        [SerializeField] GameObject prefabSkillUtil;


        private float LifeSeconds = 0.1f;
        private Timer deathTimerQ;
        private Timer deathTimerW;
        private Timer deathTimerE;
        private Timer deathTimerR;
        private Timer deathTimerUtil;
        private Timer deathTimerA;
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
            maxSpawnX = Screen.width * 2 / 3 - SpawnBorderSize;
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
            deathTimerR.Duration = 5; // need change
            deathTimerR.Run();


            deathTimerA = gameObject.AddComponent<Timer>();
            deathTimerA.Duration = 2; // need change
            deathTimerA.Run();

            deathTimerUtil = gameObject.AddComponent<Timer>();
            deathTimerUtil.Duration = 7; // need change
            deathTimerUtil.Run();

            crep = GameObject.FindGameObjectWithTag("Minion");
        }

        // Update is called once per frame
        void Update()
        {
            if (deathTimerA.Finished)
            {
                ActiveSkillAutoGiatSet();

                deathTimerA.Duration = 1.5f; // need change
                deathTimerA.Run();
            }
        }


        public void ActiveSkillQ()
        {
            var angle = Random.Range(0, Mathf.PI * 2);
            var direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            if (deathTimerQ.Finished)
            {
                var Bullet = Instantiate(prefabWhipAttack, player.position, Quaternion.identity) as GameObject;
                AudioManager.Play(AudioClipName.SkillQ);
                Bullet.GetComponent<Rigidbody2D>().AddForce(direction * 4f, ForceMode2D.Impulse);
                deathTimerQ.Duration = 1; // need change
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
                GameObject thienthach =
                    Instantiate(prefabThienThach, transform.position, Quaternion.identity) as GameObject;
                AudioManager.Play(AudioClipName.SKillW);
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
                AudioManager.Play(AudioClipName.SkillE);
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

        public void ActiveSkillR()
        {
            Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX),
                Random.Range(minSpawnY, maxSpawnY),
                -Camera.main.transform.position.z);
            Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);

            if (deathTimerR.Finished)
            {
                GameObject skillR = Instantiate(prefabSkillR, transform.position, Quaternion.identity);
                AudioManager.Play(AudioClipName.SkillR);
                skillR.transform.position = worldLocation;

                deathTimerR.Duration = 5; // need change
                deathTimerR.Run();
            }
        }

        public void ActiveSkillAutoGiatSet()
        {
            GameObject[] allCrep = GameObject.FindGameObjectsWithTag("Minion");
            foreach (GameObject currentCrep in allCrep)
            {
                float distance = (currentCrep.transform.position - player.transform.position).sqrMagnitude;
                if (distance < 15f && deathTimerA.Finished)
                {
                    GameObject skillX = Instantiate(prefabSkillAuto, currentCrep.transform.position,
                        Quaternion.identity);
                    AudioManager.Play(AudioClipName.thunder);
                    skillX.transform.position = currentCrep.transform.position;

                    deathTimerA.Duration = 1.5f; // need change
                    deathTimerA.Run();
                }
            }
        }

        public void ActiveSkillUtil()
        {
            GameObject[] allCrep = GameObject.FindGameObjectsWithTag("Boss");
            foreach (GameObject currentCrep in allCrep)
            {
                float distance = (currentCrep.transform.position - player.transform.position).sqrMagnitude;
                if (distance < 15f && deathTimerUtil.Finished)
                {
                    GameObject util = Instantiate(prefabSkillUtil, currentCrep.transform.position, Quaternion.identity);
                    AudioManager.Play(AudioClipName.SkillUlti);
                    util.transform.position = currentCrep.transform.position;

                    deathTimerUtil.Duration = 7f; // need change
                    deathTimerUtil.Run();
                }
            }
        }

        public void setDirection(Vector2 dict)
        {
            direction = dict;
        }
    }
}