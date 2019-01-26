using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour {

	public float speed= 1f;

	public float JumpPower= 5f;
	public bool jump=false;


	private Rigidbody2D RB;

	// Use this for initialization
	void Start () {
		
		RB= GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	private void Update () {
		
		Vector3 moviment= new Vector3(Input.GetAxisRaw("Horizontal"),0, 0);

		transform.position= Vector3.MoveTowards(transform.position, transform.position + moviment, speed*Time.deltaTime);

		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			jump=true;
		}

	}


	private void FixedUpdate()
	{
		if (jump)
		{
			RB.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
			jump=false;
		}
	}
}
