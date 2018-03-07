using UnityEngine;
using System.Collections;

public class DoorKey : MonoBehaviour
{

    public bool inTrigger;

    void OnTriggerEnter2D(Collider2D other)
    {
        inTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.J) || Input.GetButtonDown("Llave"))
            {
                DoorScript.doorKey = true;
                Destroy(this.gameObject);
            }
        }
    }

    void OnGUI()
    {
        if (inTrigger)
        {
            GUI.Box(new Rect(820, 400, 300, 65), "Press J to take key");
            GUI.skin.box.fontSize = 25;
        }
    }
}