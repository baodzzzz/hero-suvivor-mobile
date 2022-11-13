using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Controller
{
    public class GameSkillController : MonoBehaviour
    {
        bool isClickKillQ = false;
        bool isClickKillW = false;
        bool isClickKillE = false;
        bool isClickKillR = false;
        bool isClickKillUlti = false;



        [SerializeField] Transform player;
        [SerializeField] GameObject prefabWhipAttack;
        [SerializeField] GameObject prefabThienThach;
        [SerializeField] GameObject prefabPhaoHoa;
        [SerializeField] GameObject prefabSkillR;
        [SerializeField] GameObject prefabSkillAuto;
        [SerializeField] GameObject prefabSkillUtil;


        [SerializeField]
        private Image imageCooldownQ;
        [SerializeField]
        private Image imageCooldownW;
        [SerializeField]
        private Image imageCooldownE;
        [SerializeField]
        private Image imageCooldownR;
        [SerializeField]
        private Image imageCooldownUlti;

        [SerializeField]
        private Text textCooldownQ;
        [SerializeField]
        private Text textCooldownW;
        [SerializeField]
        private Text textCooldownE;
        [SerializeField]
        private Text textCooldownR;
        [SerializeField]
        private Text textCooldownUlti;

        private float cooldownTimeQ=3f;
        private float cooldownTimerQ;
        bool isCooldownQ=true;

        private float cooldownTimeW=5f;
        private float cooldownTimerW;
        bool isCooldownW = true;

        private float cooldownTimeE=6f;
        private float cooldownTimerE;
        bool isCooldownE = true;

        private float cooldownTimeR=10f;
        private float cooldownTimerR;
        bool isCooldownR = true;

        private float cooldownTimeUlti=15f;
        private float cooldownTimerUlti;
        bool isCooldownUlti = true;



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
            deathTimerQ.Duration = 3; // need change
            deathTimerQ.Run();

            deathTimerE = gameObject.AddComponent<Timer>();
            deathTimerE.Duration = 5; // need change
            deathTimerE.Run();

            deathTimerW = gameObject.AddComponent<Timer>();
            deathTimerW.Duration = 6; // need change
            deathTimerW.Run();

            deathTimerR = gameObject.AddComponent<Timer>();
            deathTimerR.Duration = 10; // need change
            deathTimerR.Run();


            deathTimerA = gameObject.AddComponent<Timer>();
            deathTimerA.Duration = 3; // need change
            deathTimerA.Run();

            deathTimerUtil = gameObject.AddComponent<Timer>();
            deathTimerUtil.Duration = 15; // need change
            deathTimerUtil.Run();

            crep = GameObject.FindGameObjectWithTag("Minion");

            cooldownTimerQ = cooldownTimeQ;
            textCooldownQ.text = Mathf.RoundToInt(cooldownTimeQ).ToString();
            imageCooldownQ.fillAmount = 1f;
            

            cooldownTimerW = cooldownTimeW;
            textCooldownW.text = Mathf.RoundToInt(cooldownTimeW).ToString();
            imageCooldownW.fillAmount = 1f;
            

            cooldownTimerE = cooldownTimeE;
            textCooldownE.text = Mathf.RoundToInt(cooldownTimeE).ToString();
            imageCooldownE.fillAmount = 1f;
            

            cooldownTimerR = cooldownTimeR;
            textCooldownR.text = Mathf.RoundToInt(cooldownTimeR).ToString();
            imageCooldownR.fillAmount = 1f;
            


            cooldownTimerUlti = cooldownTimeUlti;
            textCooldownUlti.text = Mathf.RoundToInt(cooldownTimeUlti).ToString();
            imageCooldownUlti.fillAmount = 1f;
          

           



        }

        // Update is called once per frame
        void Update()
        {

            if (cooldownTimerQ < 0.0f)
            {
                isCooldownQ = false;
                textCooldownQ.gameObject.SetActive(false);
                imageCooldownQ.fillAmount = 0f;
            }
            else
            {
                textCooldownQ.gameObject.SetActive(true);
                cooldownTimerQ -= Time.deltaTime;
                isCooldownQ = true;
                textCooldownQ.text = Mathf.RoundToInt(cooldownTimerQ).ToString();
                imageCooldownQ.fillAmount = cooldownTimerQ / cooldownTimeQ;
            }
            if (isClickKillQ)
            {
                cooldownTimerQ = cooldownTimeQ;
                textCooldownQ.text = Mathf.RoundToInt(cooldownTimeQ).ToString();
                imageCooldownQ.fillAmount = 1f;
                cooldownTimerQ -= Time.deltaTime;
               
                    textCooldownQ.gameObject.SetActive(true);
                    isCooldownQ = true;
                    textCooldownQ.text = Mathf.RoundToInt(cooldownTimerQ).ToString();
                    imageCooldownQ.fillAmount = cooldownTimerQ / cooldownTimeQ;
                
                isClickKillQ = false;
            }


            if (cooldownTimerW < 0.0f)
            {
                isCooldownW = false;
                textCooldownW.gameObject.SetActive(false);
                imageCooldownW.fillAmount = 0f;
            }
            else
            {
                textCooldownW.gameObject.SetActive(true);
                cooldownTimerW -= Time.deltaTime;
                isCooldownW = true;
                textCooldownW.text = Mathf.RoundToInt(cooldownTimerW).ToString();
                imageCooldownW.fillAmount = cooldownTimerW / cooldownTimeW;
            }
            if (isClickKillW)
            {
                cooldownTimerW = cooldownTimeW;
                textCooldownW.text = Mathf.RoundToInt(cooldownTimeW).ToString();
                imageCooldownW.fillAmount = 1f;
                cooldownTimerW -= Time.deltaTime;

                textCooldownW.gameObject.SetActive(true);
                isCooldownW = true;
                textCooldownW.text = Mathf.RoundToInt(cooldownTimerW).ToString();
                imageCooldownW.fillAmount = cooldownTimerW / cooldownTimeW;

                isClickKillW = false;
            }


            if (cooldownTimerE < 0.0f)
            {
                isCooldownE = false;
                textCooldownE.gameObject.SetActive(false);
                imageCooldownE.fillAmount = 0f;
            }
            else
            {
                textCooldownE.gameObject.SetActive(true);
                cooldownTimerE -= Time.deltaTime;
                isCooldownE = true;
                textCooldownE.text = Mathf.RoundToInt(cooldownTimerE).ToString();
                imageCooldownE.fillAmount = cooldownTimerE / cooldownTimeE;
            }
            if (isClickKillE)
            {
                cooldownTimerE = cooldownTimeE;
                textCooldownE.text = Mathf.RoundToInt(cooldownTimeE).ToString();
                imageCooldownE.fillAmount = 1f;
                cooldownTimerE -= Time.deltaTime;

                textCooldownE.gameObject.SetActive(true);
                isCooldownE = true;
                textCooldownE.text = Mathf.RoundToInt(cooldownTimerE).ToString();
                imageCooldownE.fillAmount = cooldownTimerE / cooldownTimeE;

                isClickKillE = false;
            }

            if (cooldownTimerR < 0.0f)
            {
                isCooldownR = false;
                textCooldownR.gameObject.SetActive(false);
                imageCooldownR.fillAmount = 0f;
            }
            else
            {
                textCooldownR.gameObject.SetActive(true);
                cooldownTimerR -= Time.deltaTime;
                isCooldownR = true;
                textCooldownR.text = Mathf.RoundToInt(cooldownTimerR).ToString();
                imageCooldownR.fillAmount = cooldownTimerR / cooldownTimeR;
            }
            if (isClickKillR)
            {
                cooldownTimerR = cooldownTimeR;
                textCooldownR.text = Mathf.RoundToInt(cooldownTimeR).ToString();
                imageCooldownR.fillAmount = 1f;
                cooldownTimerR -= Time.deltaTime;

                textCooldownR.gameObject.SetActive(true);
                isCooldownR = true;
                textCooldownR.text = Mathf.RoundToInt(cooldownTimerR).ToString();
                imageCooldownR.fillAmount = cooldownTimerR / cooldownTimeR;

                isClickKillR = false;
            }



            if (cooldownTimerUlti < 0.0f)
            {
                isCooldownUlti = false;
                textCooldownUlti.gameObject.SetActive(false);
                imageCooldownUlti.fillAmount = 0f;
            }
            else
            {
                textCooldownUlti.gameObject.SetActive(true);
                cooldownTimerUlti -= Time.deltaTime;
                isCooldownUlti = true;
                textCooldownUlti.text = Mathf.RoundToInt(cooldownTimerUlti).ToString();
                imageCooldownUlti.fillAmount = cooldownTimerUlti / cooldownTimeUlti;
            }
            if (isClickKillUlti)
            {
                cooldownTimerUlti = cooldownTimeUlti;
                textCooldownUlti.text = Mathf.RoundToInt(cooldownTimeUlti).ToString();
                imageCooldownUlti.fillAmount = 1f;
                cooldownTimerUlti -= Time.deltaTime;

                textCooldownUlti.gameObject.SetActive(true);
                isCooldownUlti = true;
                textCooldownUlti.text = Mathf.RoundToInt(cooldownTimerUlti).ToString();
                imageCooldownUlti.fillAmount = cooldownTimerUlti / cooldownTimeUlti;

                isClickKillUlti = false;
            }

            if (deathTimerA.Finished)
            {
                ActiveSkillAutoGiatSet();

                deathTimerA.Duration = 3f; // need change
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
                deathTimerQ.Duration = 3; // need change
                deathTimerQ.Run();
                /*    var script = spellSkillController.GetComponent<SpellCooldown>();*/
                isClickKillQ = true;
                  
                
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
                deathTimerW.Duration = 5; // need change
                deathTimerW.Run();
                isClickKillW = true;
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
                deathTimerE.Duration = 6; // need change
                deathTimerE.Run();
                isClickKillE = true;
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

                deathTimerR.Duration = 10; // need change
                deathTimerR.Run();
                isClickKillR = true;
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

                    deathTimerA.Duration = 3f; // need change
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
                if (distance < 25f && deathTimerUtil.Finished)
                {
                    GameObject util = Instantiate(prefabSkillUtil, currentCrep.transform.position, Quaternion.identity);
                    AudioManager.Play(AudioClipName.SkillUlti);
                    util.transform.position = currentCrep.transform.position;

                    deathTimerUtil.Duration = 15f; // need change
                    deathTimerUtil.Run();
                    isClickKillUlti = true;
                }
            }
        }

        public void setDirection(Vector2 dict)
        {
            direction = dict;
        }
        
    }
}