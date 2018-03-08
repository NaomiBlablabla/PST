using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float speedFactor;
    [SerializeField]
    private float delay;
    [SerializeField]
    private Transform target;
    private Animator Anim;
    private Vector2 rotation;
    private bool disparar;

    // Use this for initialization
    void Start()
    {
        Anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (target == null)
        {
            if (other.gameObject.name == "Kaos")
            {
                
                StartCoroutine(Shoots());
                Anim.GetBool("diPaRArxD");
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (target != null)
        {
            if (other.gameObject.name == "Kaos")
            {
                //TODO: hacer que pare de disparar
                return;                
            }
        }
    }

    IEnumerator Shoots()
    {
        while (true)
        {


            yield return new WaitForSeconds(delay);

            GameObject clone = Instantiate(projectile, transform.position, Quaternion.Euler(rotation));

            clone.GetComponent<Rigidbody2D>().velocity = transform.right * transform.localScale.x * speedFactor;

        }


    }

}