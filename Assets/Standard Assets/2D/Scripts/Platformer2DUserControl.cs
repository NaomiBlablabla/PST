using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        //vida

        //referencias
        Rigidbody2D rb2D;
        Animator anim;

        private PlatformerCharacter2D m_Character;
        private bool jump;

        /*
        [SerializeField]
        private StatusIndicatorKaos statusIndicator;
        */
        [System.Serializable]
        public class KaosStats
        {
            public int maxHealth = 100;
            public int curHealth;

            public void Init()
            {
                curHealth = maxHealth;
            }

        }
        public KaosStats stats = new KaosStats();

        //[Header("Optional: ")]
        //[SerializeField]
        //private StatusIndicatorKaos statusIndicator;
        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();

            stats.Init();
           /* 
            if (statusIndicator != null)
            {
                statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
            }*/
            
        }


        private void Update()
        {
            if (!jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                jump = Input.GetButtonDown("Jump");
            }

            if (stats.curHealth <= 0)
            {
                Die();
            }

        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetButton("Down");
            float h = Input.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, jump);
            jump = false;
        }

        void Die()
        {
            anim.SetTrigger("Death");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}
