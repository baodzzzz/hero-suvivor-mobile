using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSkill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


        //random angle and add force to game object
        float angle = Random.Range(0, Mathf.PI * 2);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = 2f;
        GetComponent<Rigidbody2D>().AddForce(direction * magnitude, ForceMode2D.Impulse);
    }

    // Update is called once per frame

    private void Update()
    {
        GameObject crep = GameObject.FindGameObjectWithTag("Minion");
        float distance = Vector3.Distance(crep.transform.position, gameObject.transform.position);
        if (distance < 10f)
        {
            transform.position = Vector2.MoveTowards(transform.position, crep.transform.position, Time.deltaTime * 2f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Minion"))
        {

            Destroy(gameObject);
        }
    }
}
