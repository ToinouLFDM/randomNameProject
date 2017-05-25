using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveField : MonoBehaviour {

	public float speed;
	public Transform FieldPosition;
    bool isItem;
   
	// Use this for initialization
	void Start () 
	{
        isItem = gameObject.GetComponent<Malus>() != null || gameObject.GetComponent<Bonus>() != null;
        Debug.Log(isItem);

    }
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 translate = new Vector3 (-speed, 0, 0);
		FieldPosition.Translate(translate);

		if (FieldPosition.position.x <= -30 && !isItem) 
		{
			Destroy (gameObject);
		}
	}


}
