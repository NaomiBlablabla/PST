using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField]
    private float destroyTime;

    // Use this for initialization
    void Start()
    {

        Destroy(this.gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    /*
    void OnTriggerEnter2D()
    {
      Destroy(this.gameObject);
    }
    */
}