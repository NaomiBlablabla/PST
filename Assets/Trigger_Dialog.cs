using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Dialog : MonoBehaviour {

    [SerializeField]
    GameObject guiObject;
    [SerializeField]
    GameObject player;

    void Start()
    {
        guiObject.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            guiObject.SetActive(true);


        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            guiObject.SetActive(false);
        }
    }
}
