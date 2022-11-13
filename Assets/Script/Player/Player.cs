using UnityEngine;
using UnityEngine.Playables;

namespace Script.Player
{
    public class Player : MonoBehaviour 
    {
        private Rigidbody2D rb;
        private float moveH, moveV;
        public float BaseSpeed { get; set; } = 5f;
        public Animator animator;
        public float SmoothTime { get; set; } = 0.04f;
        private Vector3 moveDir;
        private Vector3 velocitySmoothing;
        public int hp = 100;
        public int level = 0;
       
        public FixedJoystick joystick;

        public void SavePlayer()
        {
            SaveSystem.SavePlayer(this);
        }

        public void LoadPlayer()
        {
            PlayerData data = SaveSystem.LoadPlayer();

            level = data.level;
            if(data.hp != 0)
            {
                hp = data.hp;
            }
            Vector3 position;

            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            transform.position = position;

        }
        
        void Start()
        {       
            rb = GetComponent<Rigidbody2D>();
        }
        // Update is called once per frame
        void Update()
        {
            if (this.rb != null)
            {
                MovePlayer();         

            }
        }
        private void MovePlayer()
        {
                moveH = joystick.Horizontal;
                moveV = joystick.Vertical;
                moveDir = new Vector2(moveH, moveV);
                rb.velocity = Vector3.SmoothDamp(rb.velocity, moveDir * BaseSpeed, ref velocitySmoothing, SmoothTime);
                if (joystick.Direction.x > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else if (joystick.Direction.x < 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
        }
    }
}
