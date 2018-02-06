using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTringger : MonoBehaviour {

    [SerializeField]
    private int dmg = 20;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Enemy"));
        {
            col.gameObject.GetComponent<Enemy>().Damage(dmg);//SendMessageUpwards("Damage", dmg);

        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
