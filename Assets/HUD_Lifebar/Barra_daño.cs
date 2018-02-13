using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra_daño : MonoBehaviour
{
    Image daño_lifebar;
    float maxHealth = 100f;
    public static float health;

    private void Start()
    {
        daño_lifebar = GetComponent<Image>();
        health = maxHealth;
    }

    private void Update()
    {
        daño_lifebar.fillAmount = health / maxHealth;
    }
}
