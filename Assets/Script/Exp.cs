using Script.Player;
using Script.Skill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Exp : MonoBehaviour
{
    private GameObject player;
    Timer deathTimer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = 5;
        deathTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 5f)
        {
            gameObject.transform.position =
                Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * 2f);
        }

        if (deathTimer.Finished)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
