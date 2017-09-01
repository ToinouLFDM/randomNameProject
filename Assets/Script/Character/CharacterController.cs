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
	private bool IsGoingLeft = false;
	private bool IsGoingRight = false;
	private bool iClimbing = false;
	float InitialPositionZ= 0;
	float InitialPositionY= 0;

	// Use this for initialization
	void Start () 
	{
		up = up * speed;
		down = 0;
	}


	public bool isClimbing_ { get; set; }
	// Update is called once per frame
	void Update () 
	{
		RaycastHit hit;
		if (Physics.Raycast (transform.position, -Vector3.up, out hit, 100.0f)) 
		{
			if (hit.distance < 0.6f) 
			{
				down = 0;
				IsGoingDown = false;
				InitialPositionY = PlayerPosition.position.y;
				Vector3 Adjustment = new Vector3 (0, 0.1f, 0);
				PlayerPosition.Translate( Adjustment);

			}


			if (hit.distance > 1 && !IsGoingUp) 
			{
				IsGoingDown = true;
			}
				
		}
		RaycastHit hit2;
		if (Physics.Raycast (transform.position, -Vector3.left, out hit2, 100.0f)) 
		{
			
			if (hit2.distance <= 0.5f && IsGoingLeft)
			{
				Debug.Log ("yoloy");
				IsGoingLeft = false;
				Vector3 Adjustment = new Vector3 (0, InitialPositionY, InitialPositionZ);
				PlayerPosition.position = Adjustment;
			}
		}
		RaycastHit hit3;
		if (Physics.Raycast (transform.position, -Vector3.right, out hit3, 100.0f)) 
		{

			if (hit3.distance <= 0.5f && IsGoingRight)
			{
				Debug.Log ("yoloy");
				IsGoingRight = false;
				Vector3 Adjustment = new Vector3 (0, InitialPositionY, InitialPositionZ);
				PlayerPosition.position = Adjustment;
			}
		}
		
		if (Input.GetButtonDown ("Jump") && !IsGoingDown)
		{
			
			IsGoingUp = true;

		}
		if (Input.GetButtonDown ("SideLeft") && !IsGoingRight && (InitialPositionZ<2))
		{
			
			IsGoingLeft = true;

		}
		if (Input.GetButtonDown ("SideRight") && !IsGoingLeft && (InitialPositionZ>-2))
		{
			IsGoingRight = true;

		}

		if (IsGoingUp) 
		{
			GoingUp ();
		}
		if (IsGoingDown) 
		{
			GoingDown ();
		}
		if (IsGoingLeft) 
		{
			GoingLeft ();
		}
		if (IsGoingRight) 
		{
			GoingRight ();
		}



	}

	void GoingUp()
	{
		Vector3 Up = new Vector3 (0, up, 0);


		/*if (  (((PlayerPosition.position.y) >= (8)) && !doubleJump ) || (up<= 0) || ( ((PlayerPosition.position.y) >= (11)) && doubleJump  ) ) 
		 */
		if( PlayerPosition.position.y >= (2+ InitialPositionY))
		{
			IsGoingUp = false; 
			up =1 * speed;
			IsGoingDown = true; 

		} else 
		{
			up -= 0.005f;
			if (up <= 0) 
			{
				up = 0.01f;
			}
			PlayerPosition.Translate(Up);
		}


	}

	void GoingDown()
	{
		Vector3 Down = new Vector3 (0, down, 0);
		/*if ((PlayerPosition.position.y) <= (0.5f+InitialPositionY)) 
		{
			PlayerPosition.position= new Vector3 (0,0.5f,InitialPositionZ) ;
			down = 0;
			IsGoingDown = false; 
		} else 
		{
			down -= 0.01f;
			PlayerPosition.Translate(Down);
		}*/
		down -= 0.01f;
		PlayerPosition.Translate(Down);

	}
	void GoingLeft()
	{
		

		Vector3 Left = new Vector3 (0, 0, speed);
		if( PlayerPosition.position.z >= (InitialPositionZ+2) )
				{
					IsGoingLeft= false; 
					InitialPositionZ += 2;

				}
		
			 else 
			{
			
			PlayerPosition.Translate(Left);
			}


	}
	void GoingRight()
	{
		Vector3 Right = new Vector3 (0, 0, -speed);
		if( PlayerPosition.position.z <= (InitialPositionZ-2) )
		{
			IsGoingRight= false; 
			InitialPositionZ -= 2;

		}

		else 
		{

			PlayerPosition.Translate(Right);
		}

	}

}
