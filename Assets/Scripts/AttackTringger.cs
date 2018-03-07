using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTringger : MonoBehaviour {

    //Valores para los daños del ataque del player

    [SerializeField]
    private int dmg1 = 3;
    [SerializeField]
    private int dmg2 = 10;
    [SerializeField]
    private int dmg3 = 8;
    [SerializeField]
    private int dmg4 = 5;
    [SerializeField]
    private int dmg5 = 6;

    //función para activar el box collider "Attaking" que está dentro de kaos
    void OnTriggerEnter2D(Collider2D col)
    {
        //si pulsamos X boton y el collider es falso y además está en contacto con un collider Tageado 
        //Enemy llamaremos a la función damage que está denntro del enemigo y le asignaremos el daño
        //que queremos según el ataque y así en con los demás botones
    
        if (Input.GetButton("Grab") && col.isTrigger != true && col.CompareTag("Enemy"))
        {
       
            col.gameObject.GetComponent<Enemy>().Damage(dmg1);
            
        }
        else
        {
            if (Input.GetButton("Knee") && col.isTrigger != true && col.CompareTag("Enemy"))
            {
                
                col.gameObject.GetComponent<Enemy>().Damage(dmg2);

            }
            else
            {
                if (Input.GetButton("UpKick") && col.isTrigger != true && col.CompareTag("Enemy"))
                {
                    
                    col.gameObject.GetComponent<Enemy>().Damage(dmg3);

                }
                else
                {
                    if (Input.GetButton("Punch1") && col.isTrigger != true && col.CompareTag("Enemy"))
                    {

                        col.gameObject.GetComponent<Enemy>().Damage(dmg4);

                    }
                    else
                    {
                        if (Input.GetButton("Punch2") && col.isTrigger != true && col.CompareTag("Enemy"))
                        {

                            col.gameObject.GetComponent<Enemy>().Damage(dmg5);

                        }
                    }
                }
            }
        }
    }

}
