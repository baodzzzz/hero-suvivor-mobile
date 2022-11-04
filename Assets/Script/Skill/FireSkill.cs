using System.Collections;
using System.Collections.Generic;
using Script.Minions;
using UnityEngine;

public class FireSkill : MonoBehaviour
{
    const float LifeSeconds = 2;

    Timer deathTimer;
    private Minion _crepMinion;

    private int _damage;

    public int Damage
    {
        get => _damage;
        set => _damage = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        _damage = 15;
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = LifeSeconds;
        deathTimer.Run();

        Vector2 direction = new Vector2(Mathf.Cos(-Mathf.PI * 0.2f), Mathf.Sin(-Mathf.PI * 0.5f));
        float magnitude = 3f;
        GetComponent<Rigidbody2D>().AddForce(direction * magnitude, ForceMode2D.Impulse);
        _crepMinion = GameObject.FindGameObjectWithTag("Minion").GetComponent<Minion>();
    }


    private void Update()
    {
        if (deathTimer.Finished)
        {
            Destroy(gameObject);
        }
    }

    // private void OnTriggerEnter2D(Collider2D col)
    // {
    //     if (col.gameObject.CompareTag("Minion"))
    //     {
    //         _crepMinion.HP -= _damage;
    //         if (_crepMinion.HP <= 0)
    //         {
    //             Destroy(col.gameObject);
    //         }
    //     }
    // }
}