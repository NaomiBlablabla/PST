using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra_Vida : MonoBehaviour
{

    Image vida_lifebar;
    Image daño_lifebar;
    float maxHealth = 100f;
    public static float health;

    private void Start()
    {
        vida_lifebar = GetComponent<Image>();
        daño_lifebar = GetComponent<Image>();

        health = maxHealth;
    }

    private void Update()
    {
        vida_lifebar.fillAmount = health / maxHealth;
        daño_lifebar.fillAmount = health / maxHealth;
    }
}
