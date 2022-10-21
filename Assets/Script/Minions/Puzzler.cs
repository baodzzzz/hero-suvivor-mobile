using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Minions
{
    public class Puzzler : MonoBehaviour
    {
        private float _speed;

        private GameObject _player;
        private Vector3 _breakpoint;
        private Vector3 _screenBound;
        private int _counter;

        // Start is called before the first frame update
        private void Start()
        {
            _counter = 0;
            _speed = 2f;
            _player = GameObject.FindGameObjectWithTag("Player");
            _breakpoint = new Vector3(Random.Range(-_screenBound.x, _screenBound.x),
                Random.Range(-_screenBound.y, _screenBound.y), 0);
            if (Camera.main != null)
                _screenBound =
                    Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
                        Camera.main.transform.position.z));
        }

        // Update is called once per frame
        private void Update()
        {
            if (_counter >= 5)
            {
                _speed = 6f;
                transform.position =
                    Vector2.MoveTowards(transform.position, _player.transform.position, Time.deltaTime * _speed);
                return;
            }

            if (transform.position == _breakpoint)
            {
                _counter += 1;
                _breakpoint = new Vector3(Random.Range(-_screenBound.x, _screenBound.x),
                    Random.Range(-_screenBound.y, _screenBound.y), 0);
            }

            transform.position = Vector2.MoveTowards(transform.position, _breakpoint,
                Time.deltaTime * _speed);
        }

        // private void OnCollisionEnter2D(Collision2D col)
        // {
        //     if (col.gameObject.CompareTag("SmallBullet"))
        //     {
        //         Debug.Log("BOOM");
        //         Destroy(gameObject);
        //     }
        // }

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