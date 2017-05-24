using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnField : MonoBehaviour {


	public GameObject Obstacle;
	//Transform du Terrain
	public Transform TerrainTransform;

	private Vector3 Spawn;
	private Vector3 SpawnHaut;


	private float count2= 0;

	// Use this for initialization
	void Start () 
	{
		//Initilise les spawn des obstacles
		Spawn = new Vector3 (27, 0, 0);
		//SpawnHaut = new Vector3 (27, 12, 0);

	}
	
	// Update is called once per frame
	void Update () 
	{
		//compteur pour afficher toute les 90 frame un nouvel obstacle ( 0.1 correspond a la vitesse de défilement des obstacle)
		count2 += 0.1f;
		if (count2 >= 9) 
		{
			

			count2 = 0;
			SpawnRandomObstacle ();

		}

			
	}

	//spawn Obastacle
	void SpawnRandomObstacle()
	{
		float SpawnPositionZ = 0;
		//defini la hauteur de l'obstacle
		int randomZ = Random.Range (1, 4);

		switch ((int)randomZ) 
		{
		case 1:
			SpawnPositionZ = -2.0f;
			break;
		case 2:
			SpawnPositionZ = 0.0f;
			break;
		case 3:
			SpawnPositionZ = 2.0f;
			break;
		default:
			SpawnPositionZ = 0.0f;
			break;
		}


		// defeni la postion du spawn de l'obastacle en fct de sa taille et aléatoirement sur  x 
		Vector3 NewSpawn = new Vector3 (Spawn.x + (Random.Range (1f, 6f)), (float)(Spawn.y+0.375), SpawnPositionZ);
		//Obstacle.transform.localScale = Scale;
		Instantiate (Obstacle, NewSpawn, TerrainTransform.rotation);



		//la meme chose pour les obstacles du haut
		/*Vector3 ScaleHaut = Obstacle.transform.localScale;
		ScaleHaut.y = Random.Range (2f, 5f);
		Vector3 NewSpawnHaut = new Vector3 (Spawn.x + (Random.Range (1f, 6f)), SpawnHaut.y - (ScaleHaut.y/2), Spawn.z);
		Obstacle.transform.localScale = ScaleHaut;
		Instantiate (Obstacle, NewSpawnHaut, TerrainTransform.rotation);*/






	}




}
