using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 50f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 4000f;                  // Amount of force added when the player jumps.
        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .45f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform groundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator Anim;            // Reference to the player's animator component.
        private Rigidbody2D rb2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.
        private Vector2 mov;

        private void Awake()
        {
            // Setting up references.
            groundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            Anim = GetComponent<Animator>();
            rb2D = GetComponent<Rigidbody2D>();
        }

        void Start()
        {

        }

        void Update()
        {
            //pulsar 'e' para coger
            if (Input.GetButtonDown("Grab"))
            {
                Anim.SetTrigger("Grab");
            }

            //pulsar 'r' para dar un rodillazo
            if (Input.GetButtonDown("Knee"))
            {
                Anim.SetTrigger("Knee");
            }

            //pulsar 'z' para dar una patada alta
            if (Input.GetButtonDown("UpKick"))
            {

                Anim.SetTrigger("UpKick");
            }


            // pulsar 'r' para dar un puñetazo 
            if (Input.GetButtonDown("Punch1"))
            {
                Anim.SetTrigger("Punch1");
            }

            // pulsar 't' para dar un puñetazo forma 2
            if (Input.GetButtonDown("Punch2"))
            {
                Anim.SetTrigger("Punch2");
            }
            //if (mov != Vector2.zero) attackCollider.offset = new Vector2(mov.x /2, mov.y);


        }

        private void FixedUpdate()
        {
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    m_Grounded = true;
            }
            Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            Anim.SetFloat("vSpeed", rb2D.velocity.y);

        }


        public void Move(float move, bool crouch, bool jump)
        {
            // If crouching, check to see if the character can stand up
            if (!crouch && Anim.GetBool("Crouch"))
            {
                //Anim.SetTrigger("Jump") = false;

                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
                {
                    crouch = true;
                }
            }

            // Set whether or not the character is crouching in the animator
            Anim.SetBool("Crouch", crouch);


            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                move = (crouch ? move*m_CrouchSpeed : move);

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                rb2D.velocity = new Vector2(move*m_MaxSpeed, rb2D.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                    // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }
            // If the player should jump...
            if (m_Grounded && jump && Anim.GetBool("Ground"))
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                Anim.SetBool("Ground", false);
                rb2D.AddForce(new Vector2(0f, m_JumpForce));
            }


        }


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
