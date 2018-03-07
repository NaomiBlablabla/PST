using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTringger : MonoBehaviour {

    [SerializeField]
    private int dmg1 = 3;
    [SerializeField]
    private int dmg2 = 10;
    [SerializeField]
    private int dmg3 = 8;
    [SerializeField]
    private int dmg4 = 5;
    [SerializeField]
    private int dmg5 = 6;


    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("trigger");
        //Debug.Log("Grab: " + Input.GetButton("Grab").ToString() + " isTrigger "+ (col.isTrigger != true) + " Is Enemy: "+ col.CompareTag("Enemy"));
        if (Input.GetButton("Grab") && col.isTrigger != true && col.CompareTag("Enemy"))
        {
       
            col.gameObject.GetComponent<Enemy>().Damage(dmg1);//SendMessageUpwards("Damage", dmg);
            
        }
        else
        {
            if (Input.GetButton("Knee") && col.isTrigger != true && col.CompareTag("Enemy"))
            {
                
                col.gameObject.GetComponent<Enemy>().Damage(dmg2);//SendMessageUpwards("Damage", dmg);

            }
            else
            {
                if (Input.GetButton("UpKick") && col.isTrigger != true && col.CompareTag("Enemy"))
                {
                    
                    col.gameObject.GetComponent<Enemy>().Damage(dmg3);//SendMessageUpwards("Damage", dmg);

                }
                else
                {
                    if (Input.GetButton("Punch1") && col.isTrigger != true && col.CompareTag("Enemy"))
                    {

                        col.gameObject.GetComponent<Enemy>().Damage(dmg4);//SendMessageUpwards("Damage", dmg);

                    }
                    else
                    {
                        if (Input.GetButton("Punch2") && col.isTrigger != true && col.CompareTag("Enemy"))
                        {

                            col.gameObject.GetComponent<Enemy>().Damage(dmg5);//SendMessageUpwards("Damage", dmg);

                        }
                    }
                }
            }
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
