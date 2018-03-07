using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptprueba : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("update");
		if (Input.GetKeyDown(KeyCode.B))
        {
            Time.timeScale = (Time.timeScale == 1) ? 0 : 1;
        }
	}
    void LateUpdate()
    {
        Debug.Log("lateupdate");

    }

    void FixedUpdate()
    {
        Debug.Log("fixupdate");

    }
}
