using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainCharacterSkill : MonoBehaviour
{
   
    
    
    [SerializeField]
    GameObject prefabBulletSmall;
    [SerializeField]
    GameObject prefabWhipAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    
}

    // Update is called once per frame
    void Update()
    {
       
       
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(prefabBulletSmall, transform.position, Quaternion.identity);
           /* SmallBullet script = bullet.GetComponent<SmallBullet>();
            script.ApplyForce(thrustDirection);*/
          Rigidbody2D  bulletRb = bullet.GetComponent<Rigidbody2D>();

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
            GameObject whip = Instantiate(prefabWhipAttack, transform.position, Quaternion.identity);
           /* WhipAttack scriptWhip = whip.GetComponent<WhipAttack>();
            scriptWhip.ApplyForce(thrustDirection);*/
            Rigidbody2D whipRb = whip.GetComponent<Rigidbody2D>();

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
