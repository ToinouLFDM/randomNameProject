using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Obstacle : MonoBehaviour {

	//variable de la valeur de l'obstacle
	private int Life;
	public int Life_{get ;set ;}

    private bool doneX2 = false;
    private bool donePostiv = false;

    private int obstacleType;
    public int obstacleType_{ get; set; }        //0 => generic, 1 ==> ungeneric

    //variable pour afficher le texte
    TMPro.TextMeshProUGUI LifeText;
	public GameObject Text;
    private Character myPlayer;

	// Use this for initialization
	void Start () 
	{
        // on trouve le player et on récupere son instance
        foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
        {
            if (obj.gameObject.GetComponentInChildren<Character>())
            {
                myPlayer = obj.GetComponentInChildren<Character>();
            }
        }
        //initilise le text affiché
        LifeText = Text.GetComponent <TMPro.TextMeshProUGUI>();
		//initilise aléatoirement la valeur de l'obstacle
		Life = Random.Range(1,5);
        obstacleType = Random.Range(0, 1);
        int tempLife = Life;
        LifeText.color = new Color(255, 0, 0);
    }
	
	// Update is called once per frame
	void Update () 
	{
        //affiche la somme del'obstacle

        updateLife();
        
        

	}

    public void updateLife() {
        int tempLife = Life;
        if (myPlayer.isX2 && !doneX2) {
            Life = Life * 2;
            doneX2 = true;
        }
        else if(!myPlayer.isX2 && doneX2) {
            Life = Life / 2;
            doneX2 = false;
        }
        if (myPlayer.isPositiv && !donePostiv) {
            LifeText.color = new Color(0, 255, 0);
            donePostiv = true;
        }   
        else if (!myPlayer.isPositiv && donePostiv) {
            LifeText.color = new Color(255, 0, 0);
            donePostiv = false;
        }
           

        LifeText.text = Life.ToString();
    }
    
    // destroy gameObj and decrease playerLife
    void OnTriggerEnter(Collider player)
    {
        Character myPlayer = player.GetComponent<Character>();
        
        
        myPlayer.Life_ = (obstacleType == 0) ?((myPlayer.isPositiv)?myPlayer.Life_+Life :myPlayer.Life_ - Life ):  myPlayer.Life_ / 2;
        Destroy(gameObject);
    }
}
