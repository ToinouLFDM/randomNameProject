using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

	//variable de la somme du player
	public int Life;
	int LifeObj=0;

	//variable pour afficher le texte
	Text LifeText;
	public GameObject Text;

	// Use this for initialization
	void Start () 
	{
		//initilise le text affiché
		LifeText = Text.GetComponent <Text>();

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
		LifeObj = obstacle.GetComponent<Obstacle> ().Life_;
		Life -= LifeObj;
		Destroy (obstacle.gameObject);
	}
}
