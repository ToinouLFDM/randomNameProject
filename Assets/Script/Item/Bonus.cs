using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour {

    float bonusDuration;
    int type;
    // Use this for initialization
    void Start () {
        type = Random.Range(0, 2); //0 => +, 1=>slower
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider player)
    {
        Character myPlayer = player.GetComponent<Character>();
        switch (type)
        {
            case 0:
                bonusDuration = 10f;
                myPlayer.handleBonus(bonusDuration, type);
                break;
            case 1:
                bonusDuration = 10f;
                myPlayer.handleBonus(bonusDuration, type);
                break;
           
        }
        Destroy(gameObject);

    }
}
