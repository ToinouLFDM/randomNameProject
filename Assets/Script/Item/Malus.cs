using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malus : MonoBehaviour {


    float bonusDuration;
    int type;

   
	// Use this for initialization
	void Start () {
        type = Random.Range(0,3);
       
        //0 => x2, 1 => speed, 2 => Blind
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
                myPlayer.handleMalus(bonusDuration,gameObject, type);
                break;
            case 1:
                bonusDuration = 10f;
                myPlayer.handleMalus(bonusDuration,gameObject, type);
                break;
            case 2:
                bonusDuration = 10f;
                myPlayer.handleMalus(bonusDuration,gameObject, type);
                break;
        }
        Destroy(gameObject);

    }
    
}
