using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class malos : MonoBehaviour {

    public Barra_daño daño;
    public Barra_Vida vida;

    [SerializeField]
    private int dmg1 = 2;
    /*
    void OnTriggerEnter2D(Collider2D other)
     {
        
        Barra_Vida.health -= 5f;
        StartCoroutine (Esperar());

     }
    
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(3);
        Barra_daño.health -= 5f;
    }
    */



    void OnTriggerEnter2D(Collider2D col)
    {
            if (col.gameObject.name == "Kaos")
            {
                col.gameObject.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().Damage(dmg1);
                vida.health -= 5f;
                StartCoroutine(Esperar(col));
            }  

    }
    /*
    void OnTriggerExit2D(Collider2D other)
    {
        if (target != null)
        {
            if (other.gameObject.name == "Kaos")
            {
                return;
            }
        }
    }
    */
    IEnumerator Esperar(Collider2D col)
    {
        yield return new WaitForSeconds(3);
        daño.health -= 5f;
        col.gameObject.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().Damage(dmg1);
    }
}
