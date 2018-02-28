using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour {

    //codigo de gato

    bool gato;

    public bool GetGato()
    {
        return gato;
    }
    

    public void SetGato(bool valor)
    {
        if (valor == true)
        {
           
            gato = valor;
        }
    }

    // codigo de robot

    bool robot;

    public bool GetRobot()
    {
        return robot;
    }


    public void SetRobot(bool valor)
    {
        if (valor == true)
        {

            robot = valor;
        }
    }

    // codigo de fantasma
    bool fantasma;

    public bool GetFantasma()
    {
        return fantasma;
    }


    public void SetFantasma(bool valor)
    {
        if (valor == true)
        {

            fantasma = valor;
        }
    }

    // codigo de calavera

    bool calavera;

    public bool GetCalavera()
    {
        return calavera;
    }


    public void SetCalavera(bool valor)
    {
        if (valor == true)
        {

            calavera = valor;
        }
    }




    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
    gato = false;
    robot = false;
    fantasma = false;
    calavera = false;
    }
}
