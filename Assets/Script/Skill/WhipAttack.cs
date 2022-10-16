using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipAttack : MonoBehaviour
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
        gameObject.transform.localScale += gameObject.transform.localScale * Time.deltaTime;
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
}
