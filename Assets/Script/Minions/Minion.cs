using System;
using UnityEngine;

namespace Script
{
    public class Minion : MonoBehaviour
    {
        private float _speed;

        private GameObject _player;

        // Start is called before the first frame update
        private void Start()
        {
            _speed = 1.5f;
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        private void Update()
        {
            transform.position =
                Vector2.MoveTowards(transform.position, _player.transform.position, Time.deltaTime * _speed);
        }

        // private void OnCollisionEnter2D(Collision2D col)
        // {
        //     if (col.gameObject.CompareTag("SmallBullet"))
        //     {
        //         Debug.Log("BOOM");
        //         Destroy(gameObject);
        //     }


        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("SmallBullet") || col.gameObject.CompareTag("WhipAttack"))
            {
                Debug.Log("BOOM");
                Destroy(gameObject);
            }
        }
    }
}