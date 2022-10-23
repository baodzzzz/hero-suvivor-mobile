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
        float angle = Random.Range(0, Mathf.PI * 2);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        if (deathTimer.Finished)
        {
            GameObject Bullet = Instantiate(prefabWhipAttack, player.position, Quaternion.identity) as GameObject;
            Bullet.GetComponent<Rigidbody2D>().AddForce(direction * 3f, ForceMode2D.Impulse);
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
        GameObject crep = GameObject.FindGameObjectWithTag("Minion");
        float distance = Vector3.Distance(crep.transform.position, gameObject.transform.position);
        if (distance < 10f)
        {
            prefabWhipAttack.transform.position = Vector2.MoveTowards(transform.position, crep.transform.position, Time.deltaTime * 3f);
        }
    }

   
}
