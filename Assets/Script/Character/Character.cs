using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

	//variable de la somme du player
	private int Life;
    public int Life_ { get; set; }

    private bool isX2;
    public bool isX2_ { get; set; }

    private bool isFaster;
    public bool isFaster_ { get; set; }

    private bool isBlind;
    public bool isBlind_ { get; set; }


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

	
	public IEnumerator onBecomeX2(float duration)
	{
        isX2 = true;
        yield return new WaitForSeconds(duration);
        isX2 = false;
	}

    public IEnumerator onBecomeFaster(float duration)
    {
        isFaster = true;
        yield return new WaitForSeconds(duration);
        isFaster = false;

    }

    public IEnumerator onBecomeBlind(float duration)
    {
        isBlind = true;
        yield return new WaitForSeconds(duration);
        isBlind = false;
    }
}
