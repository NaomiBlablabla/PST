using UnityEngine;
using UnityStandardAssets._2D;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {
    [SerializeField] GameObject player;
    [SerializeField] Canvas menupausa;

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButton("Cancel"));
        {
            Pause();
        }
	}
    public void Pause()
    {
        
        if (menupausa.gameObject.activeInHierarchy == false)
        {
            
            menupausa.gameObject.SetActive(true);
            Time.timeScale = 0;
            player.GetComponent<Platformer2DUserControl>().enabled = false;
        }
        else
        {
           
            menupausa.gameObject.SetActive(false);
            Time.timeScale = 1;
            player.GetComponent<Platformer2DUserControl>().enabled = true;
        }
    }

    public void Volver(int menu)
    {
        SceneManager.LoadScene(menu);
        Time.timeScale = 1;
    }
}
