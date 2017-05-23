using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

	//variable de la somme du player
	public int Life;
	int LifeObj=0;

	bool []Item ;

	//variable pour afficher le texte
	Text LifeText;
	public GameObject Text;

	// Use this for initialization
	void Start () 
	{
		//initilise le text affiché
		LifeText = Text.GetComponent <Text>();
		//initialisation tableau d'item
		for (int i = 0; i < 10; i++)
		{
			Item [i] = false;
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		//affiche la somme du player
		LifeText.text = Life.ToString();
	}

	//Détruit l'obstacle rencontré et recupère et soustrait la variable enregistré dans l'obstacle
	void OnTriggerEnter(Collider obstacle)
	{
		ItemOnObstacle ();
		int ItemObstacle = 0;
		//recupere la vie et l'index de l'item de l'obstacle
		LifeObj = obstacle.GetComponent<Obstacle> ().Life_;
		ItemObstacle = obstacle.GetComponent<Obstacle> ().Item_;

		Destroy (obstacle.gameObject);

		//verifie si l'obstacle possede un Item et si oui lequel
		if ( ItemObstacle> 0) 
		{
			Item [ItemObstacle] = true;

		}

		//diminue la some du Player
		Life -= LifeObj;


	}



	void ItemOnObstacle()
	{
		
	}
	void ItemOnCharacter()
	{

	}
}
