using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Col_sueño: MonoBehaviour {

    public Image relleno;
    Game_Manager mng;
    public enum collectTypes { gato, fantasma, robot, calavera }
    public collectTypes mitipo;


    void Start()
    {
        gameObject.SetActive(true);
        mng = GameObject.FindWithTag("Manager").GetComponent<Game_Manager>();

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
            gameObject.SetActive(false);
            relleno.fillAmount = relleno.fillAmount + 0.25f;
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    void robot()
    {
        if (mng.GetRobot() == true)
        {
            gameObject.SetActive(false);
            relleno.fillAmount = relleno.fillAmount + 0.25f;
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    void fantasma()
    {
        if (mng.GetFantasma() == true)
        {
            gameObject.SetActive(false);
            relleno.fillAmount = relleno.fillAmount + 0.25f;
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    void calavera()
    {
        if (mng.GetCalavera() == true)
        {
            gameObject.SetActive(false);
            relleno.fillAmount = relleno.fillAmount + 0.25f;
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            relleno.fillAmount = relleno.fillAmount + 0.25f;

            gameObject.SetActive(false);

            if (mitipo == collectTypes.gato)
                mng.SetGato(true);

            if (mitipo == collectTypes.robot)
                mng.SetRobot(true);

            if (mitipo == collectTypes.fantasma)
                mng.SetFantasma(true);

            if (mitipo == collectTypes.calavera)
                mng.SetCalavera(true);
        }
    }
}
