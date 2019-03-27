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
        if (player.GetComponent<CharacterController>().getIsGoingLeft() || player.GetComponent<CharacterController>().getIsGoingRight())
            player.GetComponent<Character>().Life_/=2;
	}
    void OnTriggerStay(Collider player)
    {
        player.GetComponent<CharacterController>().isInObstacle_ = true;
        
    }


}
