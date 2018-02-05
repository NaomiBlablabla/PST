using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
{

    public static bool doorKey;
    public bool open;
    public bool inTrigger;

    void OnTriggerEnter2D(Collider2D other)
    {
        
        inTrigger = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        inTrigger = false;
    }

    void Update()
    {
        if (inTrigger)
        {
            if (doorKey)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    open = true;
                }
            }
        }

        if (open)
        {
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = newRot;
            if (transform.eulerAngles.y == 270)
            {
                Destroy(this.gameObject);
            }

        }
    }

    void OnGUI()
    {
        if (inTrigger)
        {
            if(!open)
            {
                if (doorKey)
                {
                    GUI.Box(new Rect(0, 0, 200, 25), "Presiona la tecla E para abrir");
                }
                else
                {
                    GUI.Box(new Rect(0, 0, 200, 25), "¡Necesitas una llave!");
                }
            }
        }
    }
}