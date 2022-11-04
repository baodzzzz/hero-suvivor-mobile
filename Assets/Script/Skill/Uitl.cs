using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uitl : MonoBehaviour
{
    Animator anim;
    private int _damage;

    public int Damage
    {
        get => _damage;
        set => _damage = value;
    }
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        _damage = 50;
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // destroy the game object if the explosion has finished its animation
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 9)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Minion") || col.gameObject.CompareTag("Boss"))
        {
            Destroy(col.gameObject);
        }
    }
}
