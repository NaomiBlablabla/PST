using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class malos : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Barra_Vida.health -= 5f;
        StartCoroutine (Esperar());

    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(3);
        Barra_daño.health -= 5f;
    }
}
