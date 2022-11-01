using UnityEngine;

namespace Script.Controller
{
    public class PlayerHealth : MonoBehaviour
    {
        public float maxHealth = 100;
        public float currentHealth;

        public HealthBar healthBar;

        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        // Update is called once per frame
        void Update()
        {
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Minion")) return;
            TakeDamage(1);
            /* if (collision.gameObject.CompareTag("Mover"))
        {
            TakeDamage(5);
            Debug.Log("-5!");
        }
        if (collision.gameObject.CompareTag("Puzzler"))
        {
            TakeDamage(10);
            Debug.Log("-10!");
        }*/
        }
    }
}