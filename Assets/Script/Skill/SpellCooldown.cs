using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellCooldown : MonoBehaviour
{
    [SerializeField]
    private Image imageCooldown;

    [SerializeField]
    private Text textCooldown;

    private bool isCooldown= false;
    [SerializeField]
    private float cooldownTime;  
    private float cooldownTimer;




    // Start is called before the first frame update
    void Start()
    {
        cooldownTimer=cooldownTime;
        textCooldown.text= Mathf.RoundToInt(cooldownTime).ToString();
        imageCooldown.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
       
        ApplyCooldown();
        
    }


    public void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer < 0.0f)
        {
            isCooldown = false;
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0f;
        }
        else
        {
            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount= cooldownTimer/cooldownTime;
        }


    }

   
}
