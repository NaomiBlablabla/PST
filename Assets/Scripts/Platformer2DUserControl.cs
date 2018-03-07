using System.Collections;
using System.Collections.Generic;
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
        [SerializeField] GameObject player;

        private PlatformerCharacter2D m_Character;
        private bool jump;
        
        
        [System.Serializable]
        private class KaosStats
        {

            public int maxHealth = 100;
            public int curHealth;

            public void Init()
            {
                curHealth = maxHealth;
            }

        }

        [SerializeField]
        private KaosStats stats = new KaosStats();

        [Header("Optional: ")]
        [SerializeField]
        private StatusIndicatorKaos statusIndicator;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();

            stats.Init();
           
            if (statusIndicator != null)
            {
                statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
            }
            
        }
        public void Damage(int damage)
        {
            stats.curHealth -= damage;

        }

        private void Update() //bool death
        {


            if (stats.curHealth <= 0)
            {
                
                anim.SetTrigger("Morir");
                this.enabled = false;
                Die();
            }

        }


        float delay;

        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetAxis("Vertical") < 0;
            float h = Input.GetAxis("Horizontal");

            delay += Time.deltaTime;


            if (delay > 0.1)
            {
                // Read the jump input in Update so button presses aren't missed.
                jump = Input.GetAxis("Vertical") > 0;
                delay = 0;
            }
            else
                jump = false;

            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, jump);
            jump = false;
        }

        //
        IEnumerator WaitTwoSeconds()
        {      
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //Función para morir que llama a una Corrutina
        void Die( )
        {
            Debug.Log("Me estoy muriendo_die");
            StartCoroutine("WaitTwoSeconds");
           
           
        }
    }
}
