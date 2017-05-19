using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	public float speed;
	public Transform PlayerPosition;
	private float up = 1;
	private float down = -1;
	private bool IsGoingUp = false;
	private bool IsGoingDown = false;
	// Use this for initialization
	void Start () 
	{
		up = up * speed;
		down = down * speed;
	}

	// Update is called once per frame
	void Update () 
	{
		
		if (Input.GetButtonDown ("Jump") && !IsGoingDown) 
		{
			IsGoingUp=true;
		}

		if (IsGoingUp) 
		{
			GoingUp ();
		}
		if (IsGoingDown) 
		{
			GoingDown ();
		}
	}

	void GoingUp()
	{
		Vector3 Up = new Vector3 (0, up, 0);


		if ((PlayerPosition.position.y) >= (8)) 
		{
			IsGoingUp = false; 
			up =1 * speed;
			IsGoingDown = true; 

		} else 
		{
			up += 0.01f;
			PlayerPosition.Translate(Up);
		}


	}

	void GoingDown()
	{
		Vector3 Down = new Vector3 (0, down, 0);
		if ((PlayerPosition.position.y) <= (0.5f)) 
		{
			PlayerPosition.position= new Vector3 (0,0.5f,0) ;
			down = -1 * speed;
			IsGoingDown = false; 

		} else 
		{
			down -= 0.01f;
			PlayerPosition.Translate(Down);
		}

	}
}
