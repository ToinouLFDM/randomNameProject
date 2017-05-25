using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnField : MonoBehaviour {


	public GameObject Obstacle;
	public GameObject ObstacleStaticNonGeneric;
	//Transform du Terrain
	public Transform TerrainTransform;

	private Vector3 Spawn;
	private Vector3 SpawnHaut;
	private bool []staticNonGenericPostion ;
	private float count =0;
	private float count2= 0;

	// Use this for initialization
	void Start () 
	{
		//Initilise les spawn des obstacles
		Spawn = new Vector3 (72, 0, 0);
		//SpawnHaut = new Vector3 (27, 12, 0);
		staticNonGenericPostion = new bool[4];
	}
	
	// Update is called once per frame
	void Update () 
	{
		//compteur pour afficher toute les 90 frame un nouvel obstacle ( 0.1 correspond a la vitesse de défilement des obstacle)
		count2 += 0.1f;
		count += 0.1f;
		if (count2 >=18 ) 
		{
			

			count2 = 0;
			staticNonGenericPostion[1] =false;
			staticNonGenericPostion[2] =false;
			staticNonGenericPostion[3] =false;

			int RandomPlace = Random.Range (1, 4);
			if (RandomPlace == 1) 
			{
				SpawnRandomObstacleStaticNonGeniric (1);
			}
			 RandomPlace = Random.Range (1, 4);
			if (RandomPlace == 1) 
			{
				SpawnRandomObstacleStaticNonGeniric (2);
			}
			 RandomPlace = Random.Range (1, 4);
			if (RandomPlace == 1) 
			{
				SpawnRandomObstacleStaticNonGeniric (3);
			}

		
		}
		if (count >= 9) 
		{


			count = 0;

			int RandomPlace = Random.Range (1, 4);
			if (RandomPlace == 1) 
			{
				SpawnRandomObstacle (1);
			}
			RandomPlace = Random.Range (1, 4);
			if (RandomPlace == 1) 
			{
				SpawnRandomObstacle (2);
			}
			RandomPlace = Random.Range (1, 4);
			if (RandomPlace == 1) 
			{
				SpawnRandomObstacle (3);
			}
		
			Debug.Log (" down");
		}

			
	}

	//spawn Obastacle
	void SpawnRandomObstacle( int LaneZ)
	{
		float SpawnPositionZ = 0;
		float SpawnPositionY = 0;
		//defini la hauteur de l'obstacle
	

		switch ((int)LaneZ) 
		{
		case 1:
			SpawnPositionZ = -2.0f;
			SpawnPositionY =(staticNonGenericPostion [1] == true)?2f:0 ;
			break;
		case 2:
			SpawnPositionZ = 0.0f;
			SpawnPositionY =(staticNonGenericPostion [2] == true)?2f:0 ;

			break;
		case 3:
			SpawnPositionZ = 2.0f;
			SpawnPositionY =(staticNonGenericPostion [3] == true)?2f:0 ;

			break;
		default:
			SpawnPositionZ = 0.0f;
			break;
		}





		// defeni la postion du spawn de l'obastacle en fct de sa taille et aléatoirement sur  x 
		Vector3 NewSpawn = new Vector3 (Spawn.x - (Random.Range (1f, 4f)), SpawnPositionY +(float)0.375f, SpawnPositionZ);
		//Obstacle.transform.localScale = Scale;
		Instantiate (Obstacle, NewSpawn, TerrainTransform.rotation);



		//la meme chose pour les obstacles du haut
		/*Vector3 ScaleHaut = Obstacle.transform.localScale;
		ScaleHaut.y = Random.Range (2f, 5f);
		Vector3 NewSpawnHaut = new Vector3 (Spawn.x + (Random.Range (1f, 6f)), SpawnHaut.y - (ScaleHaut.y/2), Spawn.z);
		Obstacle.transform.localScale = ScaleHaut;
		Instantiate (Obstacle, NewSpawnHaut, TerrainTransform.rotation);*/






	}
	void SpawnRandomObstacleStaticNonGeniric(int LaneZ)
	{
		float SpawnPositionZ = 0;
		//defini la hauteur de l'obstacle
		int randomZ = Random.Range (1, 4);

		switch ((int)LaneZ) 
		{
		case 1:
			SpawnPositionZ = -2.0f;
			staticNonGenericPostion [1] = true;
			break;
		case 2:
			SpawnPositionZ = 0.0f;
			staticNonGenericPostion [2] = true;
			break;
		case 3:
			SpawnPositionZ = 2.0f;
			staticNonGenericPostion [3] = true;
			break;
		default:
			SpawnPositionZ = 0.0f;
			break;
		}
		// defeni la postion du spawn de l'obastacle en fct de sa taille et aléatoirement sur  x 
		Vector3 NewSpawn = new Vector3 (Spawn.x , 0, SpawnPositionZ);
		//Obstacle.transform.localScale = Scale;
		Instantiate (ObstacleStaticNonGeneric, NewSpawn, TerrainTransform.rotation);
	}



}
