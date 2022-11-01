using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkill : MonoBehaviour
{
    const float LifeSeconds = 2;

    Timer deathTimer;
    // Start is called before the first frame update
    void Start()
    {

        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = LifeSeconds;
        deathTimer.Run();

        Vector2 direction = new Vector2(Mathf.Cos(-Mathf.PI * 0.2f), Mathf.Sin(-Mathf.PI * 0.2f));
        float magnitude = 3f;
        GetComponent<Rigidbody2D>().AddForce(direction * magnitude, ForceMode2D.Impulse);
    }
 

    private void Update()
    {
     

        if (deathTimer.Finished)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Minion"))
        {

            Destroy(gameObject);
        }
    }
}
