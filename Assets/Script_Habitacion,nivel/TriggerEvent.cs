using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEvent : MonoBehaviour {
    public string levelToLoad;

    void Start()
    { }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
