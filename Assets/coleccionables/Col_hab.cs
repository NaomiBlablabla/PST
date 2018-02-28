using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Col_hab : MonoBehaviour
{

    public enum collectTypes { gato, fantasma, robot, calavera }
    public collectTypes mitipo;
    Game_Manager mng;


    void Start()
    {
        mng = GameObject.FindWithTag("Manager").GetComponent<Game_Manager>(); //buscar


        if (mitipo == collectTypes.gato)
            gato();

        if (mitipo == collectTypes.robot)
            robot();

        if (mitipo == collectTypes.fantasma)
            fantasma();

        if (mitipo == collectTypes.calavera)
            calavera();

    }
 
    void gato()
    {
        if (mng.GetGato() == true)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void robot()
    {
        if (mng.GetRobot() == true)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void fantasma()
    {
        if (mng.GetFantasma() == true)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void calavera()
    {
        if (mng.GetCalavera() == true)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


}
