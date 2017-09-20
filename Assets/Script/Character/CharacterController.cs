using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	public float speed;
	public Transform PlayerPosition;
	private float up = 1;
	private float upCount =0 ;
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


	public bool isInObstacle_ { get; set; }
	// Update is called once per frame
	void Update () 
	{
		
		RaycastHit hit;
		if (Physics.Raycast (transform.position, -Vector3.up, out hit, 100.0f)) 
		{
			//the postion in y of the terrain under the player

			if (hit.collider.tag == "Field") 
			{
				InitialPositionY = hit.point.y + 0.5f;
			}
			//if the distance beetwen the player and an objest is too small then stop the player to going down
			if ( (hit.distance < 0.6f) && (hit.collider.tag == "Field") ) 
			{
				down = 0;
				up =1 * speed;
				upCount =0 ;
				IsGoingUp = false;
				IsGoingDown = false;
				Vector3 Adjustment = new Vector3 (0, 0.1f, 0);
				PlayerPosition.Translate( Adjustment);
				GetComponentInChildren<AnimationCharacter> ().Is_Moving= false;
			}

			//if the distance between the player and an object is too big then going down the player
			if ( (hit.distance > 1) && !IsGoingUp  && (hit.collider.tag == "Field") ) 
			{
				IsGoingDown = true;

			}
				
		}
		//if  the player collider encounter an object collider then reajust this position
		if (isInObstacle_) 
		{
			isInObstacle_ = false;
			IsGoingLeft = false;
			IsGoingUp = false;
			IsGoingRight = false;
			GetComponentInChildren<AnimationCharacter> ().Is_Moving= false;
			up =1 * speed;
			upCount =0 ;
			Vector3 Adjustment = new Vector3 (0, InitialPositionY, InitialPositionZ);
			PlayerPosition.position = Adjustment;
		}
		//Raycast for object left and right of the player
		/*RaycastHit hit2;
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
		*/
		if (Input.GetButtonDown ("Jump") && !IsGoingDown)
		{
			up =1 * speed;
			IsGoingUp = true;
			GetComponentInChildren<AnimationCharacter> ().Is_Moving= true;
			GetComponentInChildren<AnimationCharacter> ().Is_Jumping= true;
		}
		if (Input.GetButtonDown ("SideLeft") && !IsGoingRight && (InitialPositionZ<2))
		{
			
			IsGoingLeft = true;
			GetComponentInChildren<AnimationCharacter> ().Is_Moving= true;
		}
		if (Input.GetButtonDown ("SideRight") && !IsGoingLeft && (InitialPositionZ>-2))
		{
			IsGoingRight = true;
			GetComponentInChildren<AnimationCharacter> ().Is_Moving= true;
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
		if( (PlayerPosition.position.y >= (2+ InitialPositionY)) || (upCount>=1) )
		{
			GetComponentInChildren<AnimationCharacter> ().Is_Jumping= false;
			GetComponentInChildren<AnimationCharacter> ().initRotation(PlayerPosition.transform.position.y,PlayerPosition.transform.position.z);
			IsGoingUp = false; 
			up =1 * speed;
			upCount =0 ;
			IsGoingDown = true; 

		} else 
		{
			up -= 0.005f;
			if (up <= 0) 
			{
				upCount +=1 ;
				up = 0.01f;
			}
			PlayerPosition.Translate(Up);
		}


	}

	void GoingDown()
	{
		GetComponentInChildren<AnimationCharacter> ().Is_Moving= true;
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
					GetComponentInChildren<AnimationCharacter> ().Is_Moving= false;
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
			GetComponentInChildren<AnimationCharacter> ().Is_Moving= false;
		}

		else 
		{

			PlayerPosition.Translate(Right);
		}

	}

}
