using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour {

	//variable de la valeur de l'obstacle
	private int Life;
	public int Life_{get ;set ;}

    private int obstacleType;
    public int obstacleType_{ get; set; }        //0 => generic, 1 ==> ungeneric

	//variable pour afficher le texte
	Text LifeText;
	public GameObject Text;


	// Use this for initialization
	void Start () 
	{
		//initilise le text affiché
		LifeText = Text.GetComponent <Text>();
		//initilise aléatoirement la valeur de l'obstacle
		Life = Random.Range(1,5);
        obstacleType = Random.Range(0, 1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//affiche la somme del'obstacle
		LifeText.text = Life.ToString();

	}

    // destroy gameObj and decrease playerLife
    void OnTriggerEnter(Collider player)
    {
        Character myPlayer = player.GetComponent<Character>();
        if (myPlayer.isX2_)
            Life *= 2;
        myPlayer.Life_ = (obstacleType == 0) ? myPlayer.Life_ - Life :  myPlayer.Life_ / 2;
        Destroy(gameObject);
    }
}
