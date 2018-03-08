using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour {


    public float destroytime;
	// Use this for initialization
	void Start () {

        Destroy(this.gameObject, destroytime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D()
    {
        Destroy(this.gameObject);
    }
}
