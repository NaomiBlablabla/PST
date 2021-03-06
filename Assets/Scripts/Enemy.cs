﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

    //referencias
    Animator anim;


    [System.Serializable]
    public class EnemyStats
    {
        public int maxHealth = 100;
        public int curHealth;

        public void Init()
        {
            curHealth = maxHealth;
        }

    }
    public EnemyStats stats = new EnemyStats();

    //public int curHealth;
    //public int maxHealth = 50;

    [Header("Optional: ")]
    [SerializeField]
    private StatusIndicator statusIndicator;


    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {

        stats.Init();

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (stats.curHealth <= 0)
        {
            anim.SetTrigger("Dead");
            Die();
        }

    }

    /*void myGameMehod()
    {
        Debug.Log(curHealth, gameObject);

    }*/

    public void Damage(int damage)
    {
        stats.curHealth -= damage;

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }
        

    }


    IEnumerator WaitTwoSeconds()
    {       
        yield return new WaitForSeconds(1f);        
        Destroy(gameObject);
    }

    /*void WaitAndDestroy()
    {
        yield WaitForSeconds (delay);
        //yield WaitForSeconds(delay);

        Destroy(gameObject);
    }*/

    void Die()
    {
        StartCoroutine("WaitTwoSeconds");

        //anim.SetBool("Death",death);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //GameMaster.KillEnemy(this);
    }

}
