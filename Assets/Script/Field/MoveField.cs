using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveField : MonoBehaviour {

	public float speed;
	public Transform FieldPosition;
    bool isItem;
	private bool IsGoingDown = false;
	float InitialPositionY= 0;
	private float down = 0;

    private Character myPlayer;
	// Use this for initialization
	void Start () 
	{
        foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject))) {
            if (obj.gameObject.GetComponentInChildren<Character>())
            {
                myPlayer = obj.GetComponentInChildren<Character>();
            }
        }
           
        isItem = gameObject.GetComponent<Malus>() != null || gameObject.GetComponent<Bonus>() != null;
        //Debug.Log(isItem);


    }
	
	// Update is called once per frame
	void Update () 
	{
		//Reajust the position in y of the obstacle
		RaycastHit hit;
		if (Physics.Raycast (transform.position, -Vector3.up, out hit, 100.0f)) 
		{


			if (hit.distance < 0.375f) 
			{
				down = 0;
				IsGoingDown = false;
				Vector3 Adjustment = new Vector3 (0, 0.1f, 0);
				FieldPosition.Translate (Adjustment);

			}
				

			//if the distance between the player and an object is too big then going down the player
			if (hit.distance > 1 ) 
			{
				IsGoingDown = true;

			}

		}
        Vector3 translate = new Vector3(-speed, 0, 0);
        if (myPlayer.isFaster)
        {
            translate = new Vector3(-speed * 2, 0, 0);
            Debug.Log("yolo");
        }
		    
        FieldPosition.Translate(translate);

		if (FieldPosition.position.x <= -30 && !isItem) 
		{
			Destroy (gameObject);
		}
		if (IsGoingDown) 
		{
			GoingDown ();
		}
	}
	void GoingDown()
	{
		Vector3 Down = new Vector3 (0, down, 0);
		down =-0.2f;
		FieldPosition.Translate(Down);

	}

}
