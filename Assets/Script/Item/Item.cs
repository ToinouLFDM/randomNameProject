using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    private int activationTime;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void SelectItem(int i)
	{
		
	}


    void OnTriggerEnter(Collider player)
    {
        Character myPlayer = player.GetComponent<Character>();
        Destroy(gameObject);
    }
}
