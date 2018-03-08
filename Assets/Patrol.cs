 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

    public Transform StatusIndicator;
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public Transform Enemy;

    public Transform[] moveSpots;
    private int randomSpot;

    void Start()
    {
        randomSpot = 2;
        //randomSpot = Random.Range(0, moveSpots.Length);
        //Direccion();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        //Debug.Log(randomSpot);
        

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                Direccion();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    void Direccion()
    {
        if (randomSpot == 0 || randomSpot == 1)
        {
            Enemy.localScale = new Vector2(Enemy.transform.localScale.x * -1, Enemy.transform.localScale.y);
            StatusIndicator.localScale = new Vector2(StatusIndicator.transform.localScale.x * -1, StatusIndicator.transform.localScale.y);
        }

    }
}
