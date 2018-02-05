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
        //referencias
        Rigidbody2D rb2D;
        Animator anim;

        private PlatformerCharacter2D m_Character;
        private bool jump;

        [SerializeField]
        private int curHealth;
        private int maxHealth = 100;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

        void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();

            curHealth = maxHealth;

        }


        private void Update()
        {
            if (!jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                jump = Input.GetButtonDown("Jump");
            }

            if (curHealth > maxHealth)
            {
                curHealth = maxHealth;
            }
            if (curHealth <= 0)
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}
