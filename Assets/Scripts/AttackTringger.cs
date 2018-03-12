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

        if (Input.GetButton("Grab") && col.isTrigger != true && col.CompareTag("Enemy"))
        {
       
            col.gameObject.GetComponent<Enemy>().Damage(dmg1);
            
        }
        else
        {
            if (Input.GetButton("Knee") && col.isTrigger != true && col.CompareTag("Enemy"))
            {
                
                col.gameObject.GetComponent<Enemy>().Damage(dmg2);

            }
            else
            {
                if (Input.GetButton("UpKick") && col.isTrigger != true && col.CompareTag("Enemy"))
                {
                    
                    col.gameObject.GetComponent<Enemy>().Damage(dmg3);

                }
                else
                {
                    if (Input.GetButton("Punch1") && col.isTrigger != true && col.CompareTag("Enemy"))
                    {

                        col.gameObject.GetComponent<Enemy>().Damage(dmg4);

                    }
                    else
                    {
                        if (Input.GetButton("Punch2") && col.isTrigger != true && col.CompareTag("Enemy"))
                        {

                            col.gameObject.GetComponent<Enemy>().Damage(dmg5);

                        }
                    }
                }
            }
        }
    }
}
