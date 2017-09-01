using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider player)
	{
		player.GetComponent<CharacterController> ().isInObstacle_ = true;
	}
}
