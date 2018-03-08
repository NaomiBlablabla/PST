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
                if (Input.GetKeyDown(KeyCode.J))
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
                    GUI.Box(new Rect(820, 400, 300, 65), "Presiona la tecla J para abrir");
                    GUI.skin.box.fontSize = 25;
                }
                else
                {
                    GUI.Box(new Rect(820, 400, 300, 65), "¡Necesitas una llave!");
                    GUI.skin.box.fontSize = 25;
                }
            }
        }
    }
}