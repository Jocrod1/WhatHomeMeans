using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objeto_disparador : MonoBehaviour {

    public GameObject Player;
    public GameObject Disparador_Objeto;

	public Transform Disparador;

	public Transform objetivo;

	public disparador disparador;

	public float velocidad=2f;



	// Use this for initialization
	void Start () {
		disparador= Disparador.GetComponentInChildren<disparador>();
		objetivo.parent = null;
		Disparador.parent = null;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
				if(disparador.boton_activado)
				{
				transform.position = Vector3.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);
				}


	}
}
