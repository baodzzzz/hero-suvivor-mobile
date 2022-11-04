using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class PlayerExp : MonoBehaviour
{
    private int level;
    private float expNeedToUpLv;
    private float currentExp;
    public ExpBar expBar;
    public Text textLv;
    public Text textPlus;
    Timer deathTimerExpBonus;
    // Start is called before the first frame update
    void Start()
    {
        textPlus.text = "";
        deathTimerExpBonus = gameObject.AddComponent<Timer>();
       
        level = 1;
        currentExp = 0;
        expNeedToUpLv = 15;
        expBar.SetExp(0);
        expBar.SetMaxExp(expNeedToUpLv);
        textLv.text = "Level: " + level;
    }

    // Update is called once per frame
    void Update()
    {
        expBar.SetExp(currentExp);
        if (currentExp >= expNeedToUpLv)
        {
            currentExp = 0;
            expBar.SetExp(0);
            level++;
            expNeedToUpLv += level * 5;
           
            expBar.SetMaxExp(expNeedToUpLv);
           
        }
        textLv.text = "Level: " + level;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Exp"))
        {
            deathTimerExpBonus.Duration = 1;
            deathTimerExpBonus.Run();
           /* textPlus.text = "+1";*/
            if (deathTimerExpBonus.Finished)
            {
                textPlus.text = "";
            }
            currentExp += 1;
        }
    }
    
   
}
