using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharacter : MonoBehaviour {


	public Transform AnimationTransform;
	Quaternion animationTransformInitQ;
	Vector3 animationTransformInitV;

	[SerializeField]
	private float speed;
	[SerializeField]
	private float speed2;
	int countRotate = 0;
	int countTranslate;
	float countRotateJump = 0;
	public bool Is_Moving { get; set; }
	public bool Is_Jumping { get; set; }
	// Use this for initialization
	void Start () 
	{
		//animationTransformInitQ = AnimationTransform.transform.rotation ();

	}

	// Update is called once per frame
	void Update () 
	{
		if (!Is_Moving) 
		{
			rotateBase ();
			translateBase ();

		}
		if (Is_Jumping) 
		{
			Jumping();

		}


	}
	public void initRotation(float y, float z)
	{
		animationTransformInitQ = new Quaternion (0, 0, 0, 0);
		animationTransformInitV = new Vector3 (0,y +0.5f , z);
		AnimationTransform.transform.rotation = animationTransformInitQ;
		AnimationTransform.transform.position = animationTransformInitV;
		countRotate = 0;
	}
	void rotateBase()
	{
		if (countRotate < 10*speed2) 
		{
			countRotate += 1;

			AnimationTransform.Rotate(0,0,speed*30,Space.World);
		}
		if (countRotate < 20*speed2 && countRotate >= 10*speed2) 
		{
			countRotate += 1;
			AnimationTransform.Rotate(0,0,-speed*30,Space.World);
		}
		if (countRotate < ((30*speed2)+1) && countRotate >= ((20*speed2)+1)) 
		{
			countRotate += 1;
			AnimationTransform.Rotate(0,0,-speed*30,Space.World);
		}
		if (countRotate < ((40*speed2)+1) && countRotate >=((30*speed2)+1)) 
		{
			countRotate += 1;
			AnimationTransform.Rotate(0,0,speed*30,Space.World);
		}
		if (countRotate ==20*speed2) 
		{
			countRotate += 1;
		}
		if (countRotate ==((40*speed2)+1)) 
		{
			countRotate = 0;
		}

	}
	void translateBase()
	{
		if (AnimationTransform.position.y <= 0.5f) 
		{
			Vector3 up = new Vector3 (0, 0.5f, 0);
			AnimationTransform.Translate (up);
		}
		if (countTranslate < 10*speed2) 
		{
			Vector3 up = new Vector3 (0, speed * 1, 0);
			countTranslate += 1;
			AnimationTransform.Translate (up);
		}
		if (countTranslate < 20*speed2 && countTranslate >=10*speed2)
		{
			countTranslate += 1;
			Vector3 down = new Vector3 (0, -speed * 1, 0);
			AnimationTransform.Translate (down);
		} 
		if(countTranslate ==20*speed2)
			{
			
			countTranslate = 0;


			}
	}
	void Jumping()
	{
		AnimationTransform.transform.Rotate (0,0 ,-200f * speed, Space.World);
		countRotateJump += 200 * speed;
	}
}
