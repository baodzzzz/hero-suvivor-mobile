using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSkill : MonoBehaviour
{
    private GameObject _crep;
    // Start is called before the first frame update
    void Start()
    {


        //random angle and add force to game object
        var angle = Random.Range(0, Mathf.PI * 2);
        var direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        var magnitude = 2f;
      
        _crep = GameObject.FindGameObjectWithTag("Minion");
    }

    // Update is called once per frame

    private void Update()
    {
       /* if (!_crep) return;
            var distance = Vector3.Distance(_crep.transform.position, gameObject.transform.position);
        if (distance < 10f)
        {
            transform.position = Vector2.MoveTowards(transform.position, _crep.transform.position, Time.deltaTime * 2f);
        }*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Minion"))
        {

            Destroy(gameObject);
        }
    }
}
