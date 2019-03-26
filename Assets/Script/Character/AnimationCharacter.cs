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
	public bool Is_Going_Left { get; set; }
	public bool Is_Going_Right { get; set; }
	// Use this for initialization
	void Start () 
	{
		//animationTransformInitQ = AnimationTransform.transform.rotation ();

	}

	// Update is called once per frame
	void Update () 
	{
		RaycastHit hit;

		if (Physics.Raycast (transform.position, -Vector3.up, out hit, 100.0f)) 
		{
			if ( (hit.distance < 0f) && (hit.collider.tag == "Field") ) 
			{
				
				Vector3 Adjustment = new Vector3 (0, 0.25f, 0);
				AnimationTransform.Translate( Adjustment);
				GetComponentInChildren<AnimationCharacter> ().Is_Moving= false;
			}
		}


		if (!Is_Moving) 
		{
			rotateBase ();
			translateBase ();

		}
		if (Is_Jumping) 
		{
			Jumping();

		}
		if(Is_Going_Left) 
		{
			Goinigleft();

		}
		if(Is_Going_Right) 
		{
			GoinigRight();

		}
        //BugFixe Animation 
        /*
        if (AnimationTransform.position.y>1){
            AnimationTransform.position = new Vector3(AnimationTransform.position.x,1,AnimationTransform.position.z);
        }
        else if (AnimationTransform.position.y<0){
            AnimationTransform.position = new Vector3(AnimationTransform.position.x, 0, AnimationTransform.position.z);
        }
        */
	}
	public void initRotation(float y, float z)
	{
		animationTransformInitQ = new Quaternion (0, 0, 0, 0);
		animationTransformInitV = new Vector3 (0,y+0.1f , z);
		AnimationTransform.transform.rotation = animationTransformInitQ;
		AnimationTransform.transform.position = animationTransformInitV;
		countRotate = 2;
	}
	void rotateBase() {



        if (countRotate <2)
        {
            AnimationTransform.Rotate(0, 0, -4);
        }
        else if (countRotate >1)
        {
            AnimationTransform.Rotate(0, 0, 4);
        }
        if (AnimationTransform.localRotation.z>=0.30f) {
            countRotate = 0;
            
        }
        else if(AnimationTransform.localRotation.z<0 && countRotate==0)
        {
            countRotate = 1;
        }
        else if(AnimationTransform.localRotation.z> 0 &&countRotate==3) {
            countRotate = 2;
        }
        else if(AnimationTransform.localRotation.z<=-0.30f)
        {
            countRotate = 3;
        }
        
        /*
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
        */
	}
	void translateBase()
	{

        
        if(countRotate == 1 && AnimationTransform.localPosition.y > 0.1f)
        {
            Vector3 down = new Vector3(0, -0.01f, 0);
            AnimationTransform.Translate(down, Space.World);
        }
        if (countRotate == 3 && AnimationTransform.localPosition.y > 0.10f)
        {
            Vector3 down = new Vector3(0, -0.03f, 0);
            AnimationTransform.Translate(down, Space.World);
        }
        if (countRotate == 2 && AnimationTransform.localPosition.y>0.1f)
        {
            Vector3 down = new Vector3(0, -0.04f, 0);
            AnimationTransform.Translate(down, Space.World);
        }

        if (countRotate == 0 && AnimationTransform.localPosition.y < 1.5f)
        {
            Vector3 up = new Vector3(0, 0.08f, 0);
            AnimationTransform.Translate(up, Space.World);
        }
        /*
		if (AnimationTransform.position.y <= 0.5f) 
		{
			Vector3 up = new Vector3 (0, 0.5f, 0);
			AnimationTransform.Translate (up);
            countTranslate += 1;
        }
		else if (countTranslate < 10*speed2) 
		{
			Vector3 up = new Vector3 (0, speed * 1, 0);
			countTranslate += 1;
			AnimationTransform.Translate (up);
		}
		else if (countTranslate < 20*speed2 && countTranslate >=10*speed2)
		{
			countTranslate += 1;
			Vector3 down = new Vector3 (0, -speed * 1, 0);
			AnimationTransform.Translate (down);
		} 
		if(countTranslate ==20*speed2)
			{
			
			countTranslate = 0;


			}
        */
	}
	void Jumping()
	{
     
		AnimationTransform.transform.Rotate (0,0 ,-250f * speed);
		countRotateJump += 50 * speed;
	}
	void Goinigleft()
	{

        AnimationTransform.transform.Rotate (250f * speed,0,0);
		countRotateJump += 50 * speed;
	}
	void GoinigRight()
	{
       
        AnimationTransform.transform.Rotate (-250f * speed,0,0);
		countRotateJump += 50 * speed;
	}
}
