using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Skill
{
    public class SmallBullet : MonoBehaviour
    {
        const float LifeSeconds = 2;

        Timer deathTimer;

        // Start is called before the first frame update
        void Start()
        {
            deathTimer = gameObject.AddComponent<Timer>();
            deathTimer.Duration = LifeSeconds;
            deathTimer.Run();
        }

        // Update is called once per frame
        void Update()
        {
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

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Minion"))
            {
                Destroy(gameObject);
                Debug.Log("BEEMMMM!");
            }
        }
    }
}