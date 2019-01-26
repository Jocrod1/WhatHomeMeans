using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_plataforma : MonoBehaviour {

	public bool entrar;


	// Use this for initialization
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
        {

            entrar = true;

        }
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
        {

            entrar = false;

        }
	}
}
