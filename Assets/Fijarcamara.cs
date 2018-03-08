using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fijarcamara : MonoBehaviour {

    public Transform target;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (target == null)
        {
            //Debug.Log(other.gameObject.name == "Kaos");
            if (other.gameObject.name == "Kaos")
            {
                return;
            }
        }
    }
}
