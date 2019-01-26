using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boton_activable : MonoBehaviour {

    public GameObject Player;
    public GameObject Activable;

	public Transform Boton_Objeto;

	public Transform objetivo;

	public boton boton;

	public float velocidad=2f;

	private Vector3 inicio, fin;


	// Use this for initialization
	void Start () {
		boton= Activable.GetComponentInChildren<boton>();
		objetivo.parent = null;
		Boton_Objeto.parent = null;

		    inicio = transform.position;
            fin = objetivo.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		transform.position = Vector3.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);

				if(boton.boton_activado==true)
				{
					objetivo.position=fin;

				}
				else if (boton.boton_activado==false)
				{
					objetivo.position=inicio;
				}


	}
}
