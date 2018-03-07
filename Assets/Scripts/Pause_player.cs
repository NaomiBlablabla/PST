using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets._2D;
using UnityEngine;

public class Pause_player : MonoBehaviour {

    [SerializeField] GameObject player;
    [SerializeField] Canvas SayDialog;

    void Start()
    {

    }
    public void Pause()
    {

        if (SayDialog.gameObject.activeInHierarchy == false)
        {
            //SayDialog.gameObject.SetActive(true);
            Time.timeScale = 0;
            player.GetComponent<Platformer2DUserControl>().enabled = false;
        }
        else
        {

            //SayDialog.gameObject.SetActive(false);
            Time.timeScale = 1;
            player.GetComponent<Platformer2DUserControl>().enabled = true;
        }
    }


}
