using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma_movimiento : MonoBehaviour {

 //colocamos aqui a que target se va a mover que pusimos en el unity
    public Transform objetivo;

    //la velocidad en que se mueve la plataforma
    public float velocidad;

	private bool tocar;

	public GameObject Player;
	public GameObject plataforma_automatica;

    private Vector3 inicio, fin;


	// Use this for initialization
	void Start () {

        if(objetivo !=null)
        {
            //esto es para que el target deje de ser pariente del objeto
            objetivo.parent = null;


            //marcamos que las variables son el objeto y el objetivo
            inicio = transform.position;
            fin = objetivo.position;

        }


		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //para que sea un objeto con tag "Player" lo que pueda hacer caer la plataforma
        if(collision.gameObject.CompareTag("Player"))
        {

			tocar=true;

        }

    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        
        if(objetivo!= null)
        {


            //se cambia la velocidad a velocidad_nueva porque la funcion "towards" necesita una velocidad delta time
            float velocidad_nueva = velocidad * Time.deltaTime;

            //towards sirve para que el objeto vaya hacia el objetivo
            transform.position = Vector3.MoveTowards(transform.position, objetivo.position, velocidad_nueva);




            if(transform.position==objetivo.position)
            {
                //esto es para comprobar : si el objetivo esta en el target regresa el target a la posicion principal de la plataforma...si no lo esta sigue llendo
                objetivo.position = (objetivo.position == inicio) ? fin : inicio;

            }

			//if (tocar)
			{
				Player.transform.parent = plataforma_automatica.transform;
			}


        }



    }


}
