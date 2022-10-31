using Script.Controller;
using UnityEngine;

namespace Script.Skill
{
    public class MainCharacterSkill : MonoBehaviour
    {
        public Transform player;
       

        [SerializeField] private GameObject prefabBulletSmall;

        [SerializeField] private GameObject prefabWhipAttack;

        const float smallBulletLifeSeconds = 0.2f;
        Timer deathTimer;
        [SerializeField]
        GameObject gameSkillController;

        // Start is called before the first frame update
        void Start()
        {
            deathTimer = gameObject.AddComponent<Timer>();
            deathTimer.Duration = smallBulletLifeSeconds;
            deathTimer.Run();       
       
        }

        // Update is called once per frame
        void Update()
        {
            float angle = Random.Range(0, Mathf.PI * 2);
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            /* Vector2 direction = FindClosestCrep();*/

            var script = gameSkillController.GetComponent<GameSkillController>();
            script.setDirection(direction);
           
            Shoot(prefabBulletSmall, direction);
        }
        void Shoot(GameObject bullet, Vector2 direction)
        {
            if (deathTimer.Finished)
            {
                GameObject Bullet = Instantiate(bullet, player.position, Quaternion.identity) as GameObject;
                Bullet.GetComponent<Rigidbody2D>().AddForce(direction * 5f, ForceMode2D.Impulse);
                /*Bullet.transform.position= Vector2.MoveTowards(transform.position, crep.transform.position, Time.deltaTime * 3f);*/
                deathTimer.Duration = smallBulletLifeSeconds;
                deathTimer.Run();
            }
          
            
             
            
        }
        /*Vector2 FindClosestCrep()
        {
            float distanceClosest = Mathf.Infinity;
            GameObject closestCrep = null;
            GameObject[] allCrep = GameObject.FindGameObjectsWithTag("Minion");
            foreach (GameObject currentCrep in allCrep)
            {
                float distance = (currentCrep.transform.position - this.transform.position).sqrMagnitude;
                if (distance < distanceClosest)
                {
                    distanceClosest = distance;
                    closestCrep = currentCrep;
                }
            }
            return closestCrep.transform.position;
        }*/
    }
}