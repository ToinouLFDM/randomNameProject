using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour {

	//variable de la valeur de l'obstacle
	private int Life;
	public int Life_{get ;set ;}


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
	}
	
	// Update is called once per frame
	void Update () 
	{
		//affiche la somme del'obstacle
		LifeText.text = Life_.ToString();
	}
}
