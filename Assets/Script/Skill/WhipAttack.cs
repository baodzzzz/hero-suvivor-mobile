using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace
{
    public class WhipAttack : MonoBehaviour
    {
        const float LifeSeconds = 2;

        Timer deathTimer;
        private int _damage;
        private GameObject crep;
        public int Damage
        {
            get => _damage;
            set => _damage = value;
        }

        // Start is called before the first frame update
        void Start()
        {
            crep = GameObject.FindGameObjectWithTag("Minion");
            deathTimer = gameObject.AddComponent<Timer>();
            deathTimer.Duration = LifeSeconds;
            deathTimer.Run();
            _damage = 15;
        }

        // Update is called once per frame
        void Update()
        {
            if (!crep) return;
           /* var distance = Vector3.Distance(crep.transform.position, transform.position);
            if (distance < 10f)
            {
                gameObject.transform.position =
                    Vector2.MoveTowards(transform.position, crep.transform.position, Time.deltaTime * 2f);
            }*/
            gameObject.transform.localScale += gameObject.transform.localScale * Time.deltaTime * 1.1f;                    
            if (deathTimer.Finished)
            {
                Destroy(gameObject);
            }
        }

     
        // private void OnCollisionEnter2D(Collision2D col)
        // {
        //     if (col.gameObject.CompareTag("Minion"))
        //     {
        //         Destroy(gameObject);
        //     }
        // }
    }
}
