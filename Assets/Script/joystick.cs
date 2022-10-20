using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class joystick : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    public Transform circle;
    public Transform outerCircle;
    Animate animate;
    // Update is called once per frame

    [SerializeField]
    GameObject prefabBulletSmall;
    [SerializeField]
    GameObject prefabWhipAttack;

    [SerializeField]
    GameObject gameSkillController;
    const float smallBulletLifeSeconds = 0.3f;
    Timer deathTimer;
  
    

    private void Start()
    {
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = smallBulletLifeSeconds;
        deathTimer.Run();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));


            circle.transform.position = pointA * -1;
            outerCircle.transform.position = pointA * -1;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
          
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }

    }
    private void FixedUpdate()
    {
       
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
          
            GameSkillController script = gameSkillController.GetComponent<GameSkillController>();
            script.setDirection(direction);
           
            Shoot(prefabBulletSmall, direction);
                
           
            moveCharacter(direction * -1);

            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * -1;
        }
        else
        {
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
    void Shoot(GameObject gameObject ,Vector2 direction)
    {
        if (deathTimer.Finished)
        {
            GameObject Bullet = Instantiate(gameObject, player.position, Quaternion.identity) as GameObject;
            Bullet.GetComponent<Rigidbody2D>().AddForce(direction * 5f, ForceMode2D.Impulse);
            deathTimer.Duration = smallBulletLifeSeconds;
            deathTimer.Run();
        }

    }

}