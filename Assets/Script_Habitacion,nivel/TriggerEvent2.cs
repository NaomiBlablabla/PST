using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEvent2 : MonoBehaviour
{
    public string levelToLoad;
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
                SceneManager.LoadScene(levelToLoad);
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