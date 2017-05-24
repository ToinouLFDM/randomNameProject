using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

	//variable de la somme du player
	private int Life;
    public int Life_ { get; set; }

	bool []Item ;

	//variable pour afficher le texte
	Text LifeText;
	public GameObject Text;

	// Use this for initialization
	void Start () 
	{
		//initilise le text affiché
		LifeText = Text.GetComponent <Text>();
        Life = 10;
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

	
	void ItemOnCharacter()
	{

	}
}
