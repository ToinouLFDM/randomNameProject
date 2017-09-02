using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMysteryBox : MonoBehaviour {

	public Transform AnimationTransform;
	[SerializeField]
	private float speed;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		AnimationTransform.Rotate(speed,speed,speed,Space.World);
	}
}
