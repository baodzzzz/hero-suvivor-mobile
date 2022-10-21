using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSkillController : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    GameObject prefabWhipAttack;
    const float LifeSeconds = 1f;
    Timer deathTimer;
    Vector2 direction { get; set; }
    // Start is called before the first frame update
    public void ActiveSkill()
    {
        var dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        if (deathTimer.Finished)
        {
            GameObject Bullet = Instantiate(prefabWhipAttack, player.position, Quaternion.identity) as GameObject;
            Bullet.GetComponent<Rigidbody2D>().AddForce(dir * 3f, ForceMode2D.Impulse);
            deathTimer.Duration = LifeSeconds;
            deathTimer.Run();
        }

    }
    public void setDirection(Vector2 dict)
    {
        direction = dict;
    }
    void Start()
    {
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = LifeSeconds;
        deathTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
