using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

    public GameObject optionPanel;





    public void OnStart_Click()
    {
        SceneManager.LoadScene("main menu");
    }

	public void OnExit_Click()
    {
        Debug.Log("Has pulsado salir");
	}

    public void OnNewGame_Click()
    {
        SceneManager.LoadScene("Nueva Partida");
    }


    public void OnOptions_Click()
    {
        Debug.Log("Has pulsado opciones");
    }


    public void OnCargar_Click()
    {
        SceneManager.LoadScene("Cargar Partida");
    }

    public void OnBack_Click()
    {
        SceneManager.LoadScene("main menu");
    }

    public void OnStartGame_Click()
    {
        SceneManager.LoadScene("Habitación");
    }



    public void OnPokemon_Click()
    {
        if (optionPanel.activeSelf)
            optionPanel.SetActive(false);
        else
            optionPanel.SetActive(true);
    }

}
