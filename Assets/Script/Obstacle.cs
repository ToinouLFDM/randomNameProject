using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour {

	//variable de la valeur de l'obstacle
	private int Life;
	public int Life_{get ;set ;}

	//initialisation tableau d'item
	int Item = 0;
	public int Item_{get ;set ;}
	//variable pour afficher le texte
	Text LifeText;
	public GameObject Text;


	// Use this for initialization
	void Start () 
	{
		//initilise le text affiché
		LifeText = Text.GetComponent <Text>();
		//initilise aléatoirement la valeur de l'obstacle
		Life_ = Random.Range(1,5);
		//initilise si l'obstacle possede un item et si oui lequel
		int i = Random.Range (1, 10);
		if (i == 1) 
		{
			Item_ = Random.Range (1, 1);
		}


	}
	
	// Update is called once per frame
	void Update () 
	{
		//affiche la somme del'obstacle
		LifeText.text = Life_.ToString();

	}
}
