using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malus : MonoBehaviour {


    float bonusDuration;
    int type;
	// Use this for initialization
	void Start () {
        type = 2;   //0 => x2, 1 => speed, 2 => Blind
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    //handle malus activation
    void OnTriggerEnter(Collider player)
    {
        Character myPlayer = player.GetComponent<Character>();
        switch (type)
        {
            case 0:
                bonusDuration = 10f;
                StartCoroutine(myPlayer.onBecomeX2(bonusDuration));
                break;
            case 1:
                bonusDuration = 10f;
                StartCoroutine(myPlayer.onBecomeFaster(bonusDuration));
                break;
            case 2:
                bonusDuration = 10f;
                StartCoroutine(myPlayer.onBecomeBlind(bonusDuration));
                myPlayer.isBlind_ = false;
                break;
        }
    }
}
