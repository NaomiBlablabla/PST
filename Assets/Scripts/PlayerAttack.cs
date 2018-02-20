using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {


    private bool attacking = false;

    private float attackTimer = 0;
    private float attackCd = 0.3f;

    public Collider2D attackTrigger;
    private Animator anim;

    void Awake ()
    {
        anim = gameObject.GetComponent<Animator>();
        //attackTrigger = gameObject.GetComponent<Collider2D>();
        attackTrigger.enabled = false;
    }

    void Update()
    {
        if(Input.GetButtonDown("Knee")&& !attacking)
        {
            attacking = true;
            attackTimer = attackCd;

            attackTrigger.enabled = true;
        }

        if (Input.GetButtonDown("UpKick") && !attacking)
        {
            attacking = true;
            attackTimer = attackCd;

            attackTrigger.enabled = true;
        }

        if (Input.GetButtonDown("Grab") && !attacking)
        {
            attacking = true;
            attackTimer = attackCd;

            attackTrigger.enabled = true;
        }

        if (Input.GetButtonDown("Punch1") && !attacking)
        {
            attacking = true;
            attackTimer = attackCd;

            attackTrigger.enabled = true;
        }

        if (Input.GetButtonDown("Punch2") && !attacking)
        {
            attacking = true;
            attackTimer = attackCd;

            attackTrigger.enabled = true;
        }

        if (attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
       // anim.SetBool("knee", attacking);

    }


}
