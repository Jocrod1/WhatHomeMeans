using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boton : MonoBehaviour {

    public bool boton_activado;


    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            boton_activado = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            boton_activado = false;

        }
    }
}
