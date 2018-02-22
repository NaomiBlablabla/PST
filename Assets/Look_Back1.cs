using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look_Back1 : MonoBehaviour {

    public Transform StatusIndicator;
    public Transform Enemy;
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
                target = other.gameObject.transform;
                Enemy.localScale = new Vector2(Enemy.transform.localScale.x * -1, Enemy.transform.localScale.y);
                StatusIndicator.localScale = new Vector2(StatusIndicator.transform.localScale.x * -1, StatusIndicator.transform.localScale.y);
            }
        }  
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (target != null)
        {
            if (other.gameObject.name == "Kaos")
            {
                target = null;
                
            }
        }
    }
}
