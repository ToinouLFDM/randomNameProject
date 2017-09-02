using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharacter : MonoBehaviour {


	public Transform AnimationTransform;
	[SerializeField]
	private float speed;
	[SerializeField]
	private float speed2;
	int countRotate = 0;
	int countTranslate;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		rotate ();
		Translate ();
	}

	void rotate()
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
	void Translate()
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
}
