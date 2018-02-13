using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_principal : MonoBehaviour {

    public void Jugar(int menu)
    {
        SceneManager.LoadScene(4);
        
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("salir");
    }
}
