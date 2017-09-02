using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharacter : MonoBehaviour {


	public Transform AnimationTransform;
	[SerializeField]
	private float speed;
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
		if (countRotate < 32) 
		{
			countRotate += 1;

			AnimationTransform.Rotate(0,0,speed*40,Space.World);
		}
		if (countRotate < 64 && countRotate >= 32) 
		{
			countRotate += 1;
			AnimationTransform.Rotate(0,0,-speed*40,Space.World);
		}
		if (countRotate < 97 && countRotate >= 65) 
		{
			countRotate += 1;
			AnimationTransform.Rotate(0,0,-speed*30,Space.World);
		}
		if (countRotate < 129 && countRotate >=97) 
		{
			countRotate += 1;
			AnimationTransform.Rotate(0,0,speed*30,Space.World);
		}
		if (countRotate ==64) 
		{
			countRotate += 1;
		}
		if (countRotate ==129) 
		{
			countRotate = 0;
		}

	}
	void Translate()
	{
		if (countTranslate < 32) 
		{
			Vector3 up = new Vector3 (0, speed * 1, 0);
			countTranslate += 1;
			AnimationTransform.Translate (up);
		}
		if (countTranslate < 64 && countTranslate >=32)
		{
			countTranslate += 1;
			Vector3 down = new Vector3 (0, -speed * 1, 0);
			AnimationTransform.Translate (down);
		} 
		if(countTranslate ==64)
			{
			
			countTranslate = 0;


			}
	}
}
