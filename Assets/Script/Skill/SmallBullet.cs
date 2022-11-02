using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Skill
{
    public class SmallBullet : MonoBehaviour
    {
        private const float LifeSeconds = 2;
        private Timer deathTimer;
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
            deathTimer = gameObject.AddComponent<Timer>();
            deathTimer.Duration = LifeSeconds;
            deathTimer.Run();
            _damage = 12;
            crep = GameObject.FindGameObjectWithTag("Minion");
        }

        // Update is called once per frame
        void Update()
        {
            if (!crep) return;
            var distance = Vector3.Distance(crep.transform.position, transform.position);
            if (distance < 10f)
            {
                transform.position = Vector2.MoveTowards(transform.position, crep.transform.position, Time.deltaTime * 3f);
            }
            if (deathTimer.Finished)
            {
                Destroy(gameObject);
            }

        }

        public void ApplyForce(Vector2 forceDirection)
        {
            const float forceMagnitude = 3;
            GetComponent<Rigidbody2D>().AddForce(
                forceMagnitude * forceDirection,
                ForceMode2D.Impulse);
        }


        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Minion"))
            {
                Destroy(gameObject);
            }
        }
    }
}