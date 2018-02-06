using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puertas_rompibles : MonoBehaviour
{
    public GameObject guiObject;

    void Start()
    {
        guiObject.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            guiObject.SetActive(true);
            if (guiObject.activeInHierarchy == true && Input.GetButtonDown("Use"))
            {
                GameObject.Destroy(this.gameObject);
            }

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