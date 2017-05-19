using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnField : MonoBehaviour {

	public GameObject Field;
	public Transform TerrainTransform;
	private Vector3 Spawn;
	private float count = 0;
	private float count2= 0;

	// Use this for initialization
	void Start () 
	{
		
		Spawn = new Vector3 (27, 0, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{

		count2 += 0.1f;
		if (count2 >= 9) 
		{
			
	
			Instantiate (Field, Spawn, TerrainTransform.rotation);
			count2 = 0;

		}
			
	}
}
