using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma_cae : MonoBehaviour {


    //el tiempo que se va a esperar hasta caer la plataforma
    public float tiempo_caer= 1f;

    //el tiempo que va a reaparecer la plataforma caida
    public float tiempo_reaparecer = 3f;

    private BoxCollider2D bc2d;


    private Vector3 start;

    void Start () {

        bc2d = GetComponent<BoxCollider2D>();

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            Invoke("caer", tiempo_caer);

            Invoke("reaparecer", tiempo_caer+ tiempo_reaparecer);
        }

    }


    void caer()
    {
        bc2d.isTrigger = true;
    }


    void reaparecer()
    {

        bc2d.isTrigger = false;


    }

}