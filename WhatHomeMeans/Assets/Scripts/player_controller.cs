using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour {

	public float speed= 1f;

	public float JumpPower= 5f;
	public bool jump=false;


	private Rigidbody2D RB;
    Animator Anim;

    public float logVelocity;

	// Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();
		RB= GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	private void Update () {

        logVelocity = RB.velocity.y;
		
		Vector3 moviment= new Vector3(Input.GetAxisRaw("Horizontal"),0, 0);

		transform.position= Vector3.MoveTowards(transform.position, transform.position + moviment, speed*Time.deltaTime);
        if (moviment.x != 0)
            transform.localScale = new Vector3(-moviment.x, 1f, 1f);

        Anim.SetFloat("Movx", Mathf.Abs(moviment.x));

		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			jump=true;
            Anim.SetTrigger("Jump");
		}

	}


	private void FixedUpdate()
	{
		if (jump)
		{
			RB.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
			jump=false;
		}
        Anim.SetBool("Grounded", Grounded);
	}

    public bool Grounded { get; private set; }

    void OnCollisionStay2D(Collision2D col) {
        if (col.gameObject.tag == "Ground"){
            Grounded = true;
        }

    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Grounded = false;
        }
    }
}
