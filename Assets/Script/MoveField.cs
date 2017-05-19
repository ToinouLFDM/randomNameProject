using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveField : MonoBehaviour {

	public float speed;
	public Transform FieldPosition;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 translate = new Vector3 (-speed, 0, 0);
		FieldPosition.Translate(translate);

		if (FieldPosition.position.x <= -9) 
		{
			Destroy (gameObject);
		}
	}

}
