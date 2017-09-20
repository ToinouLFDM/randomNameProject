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

	int Count;
	int Score;
    bool []Item ;


	//variable pour afficher le texte
	Text LifeText;
	public GameObject Text;
	Text ScoreText;
	public GameObject Text2;

	// Use this for initialization
	void Start () 
	{
		//initilise le text affiché
		LifeText = Text.GetComponent <Text>();
		ScoreText = Text2.GetComponent <Text>();
        Life_ = 10;
		//initialisation tableau d'item
		for (int i = 0; i < 10; i++)
		{
			//Item [i] = false;
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		//affiche la somme du player
		LifeText.text = Life_.ToString();
		ScoreText.text = Score.ToString ();
		Count+=1;
		if (Count == 18) 
		{
			Count = 0;
			Score += (Life_ / 10) + 1;
		}

	}

	

    public IEnumerator handleMalus(float duration, GameObject obj, int type)
    {
        switch (type)
        {
            case 0:
                isX2 = true;
                break;
            case 1:
                isFaster = true;
                break;
            case 2:
                isBlind = true;
                break;
        }
        Debug.Log(obj);
        MeshRenderer mesh =  obj.GetComponent<MeshRenderer>();
        mesh.enabled = false;
        yield return new WaitForSeconds(duration);
        Debug.Log("no more blind");
        Destroy(obj);
        switch (type)
        {
            case 0:
                isX2 = false;
                break;
            case 1:
                isFaster = false;
                break;
            case 2:
                isBlind = false;
                break;
        }

    }
}
