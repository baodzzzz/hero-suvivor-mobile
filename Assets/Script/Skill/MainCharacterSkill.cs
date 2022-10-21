using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainCharacterSkill : MonoBehaviour
{
    Vector2 thrustDirection = new Vector2(0, 1);

    [SerializeField] private GameObject prefabBulletSmall;

    [SerializeField] private GameObject prefabWhipAttack;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(prefabBulletSmall, transform.position, Quaternion.identity);
            /* SmallBullet script = bullet.GetComponent<SmallBullet>();
             script.ApplyForce(thrustDirection);*/
            var bulletRb = bullet.GetComponent<Rigidbody2D>();

            var dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

            if (dir.magnitude > 0)
            {
                bulletRb.velocity = dir * 3f;
            }
            else
            {
                bulletRb.velocity = transform.right * 3f;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            var whip = Instantiate(prefabWhipAttack, transform.position, Quaternion.identity);
            /* WhipAttack scriptWhip = whip.GetComponent<WhipAttack>();
             scriptWhip.ApplyForce(thrustDirection);*/
            var whipRb = whip.GetComponent<Rigidbody2D>();

            var dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

            if (dir.magnitude > 0)
            {
                whipRb.velocity = dir * 3f;
            }
            else
            {
                whipRb.velocity = transform.right * 3f;
            }
        }
    }
}