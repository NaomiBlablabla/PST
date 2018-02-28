using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour {


    public Transform target;
    public float health;
    public int meleeDamage;
    public float meleeRange;
    public float attackRange;
    public int damage;
    private float lastattacktime;
    public float attackDelay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //ataque ia

        //check la distancia entre enemigo y player
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayer < attackRange)
        {
            //check si ha pasado suficiente tiempo
            if (Time.time > lastattacktime + attackDelay)
            //tiempo pasado
            target.SendMessage("TakeDamage", damage);
            lastattacktime = Time.time;
        }

    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Debug.Log("Dead");
        }
    }
    
}
