using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    //variable de la somme du player
    private int Life;
    public int Life_ { get; set; }


    //variable qui indique la présence des malus
    public bool isX2 { get; set; }
    public bool isFaster { get; set; }
    public bool isBlind { get; set; }

    //varaible qui correspond au temps restant des malus
    private float timeBlind = 0;
    private float timeisX2 = 0;
    private float timeFaster = 0;

    public float getTimeX2() {
        return timeisX2;
    }
    public float getTimeBlind() {
        return timeBlind;
    }
    public float getTimeFaster() {
        return timeFaster;
    }
    //variable qui indique la présence des bonus
    public bool isPositiv=false;
    public bool isSlower=false;

    //variable qui correspond au temps restant des Bonus
    private float timePositiv = 0;
    private float timeSlower = 0;

    public float getTimePositiv(){
        return timePositiv;
    }
    public float getTimeSlower(){
        return timeSlower;
    }

	int Count;
	private int score;
    public int getScore () {
        return score;
    }
    private float time= 0f;

	//variable pour afficher le texte
	
    private TMPro.TextMeshProUGUI LifeText;
    public GameObject Text;
	
	

    private CharacterUI UI;

	// Use this for initialization
	void Start () 
	{
        UI = GetComponent<CharacterUI>();
        time = (float)System.Math.Round(Time.time,2);
        //initilise le text affiché
        LifeText = Text.GetComponent <TMPro.TextMeshProUGUI>();
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
        time = (float)System.Math.Round(Time.time, 2);
        //affiche la somme du player
        LifeText.text = Life_.ToString();

        updateSore();
        updateMalus();
        updateBonus();
        

	}
    public void updateSore () {
        Count += 1;
        float temp = time / 30;
        if (Count >= (100/temp)){
            Count = 0;
            score += Life_/2;
        }
            
    }
    public void updateBonus(){
        if(isPositiv) {
            if (timePositiv < Time.time) {
                isPositiv = false;
                timePositiv = 0;
                UI.updatePositionBuffDelete("Positiv");
            }
        }
        if(isSlower) {
            if(timeSlower < Time.time){
                isSlower = false;
                timeSlower = 0;
                UI.updatePositionBuffDelete("Slower");
            }
           
        }
    }


    public void updateMalus() {
        if (isBlind){
            
            if (timeBlind < Time.time){
                isBlind = false;
                timeBlind = 0;
                Debug.Log("no more blind");
                UI.updatePositionBuffDelete("Blind");
            }
        }
        if (isX2)
        {

            if (timeisX2 < Time.time)
            {
                isX2 = false;
                timeisX2= 0;
                Debug.Log("no more X2");
                UI.updatePositionBuffDelete("X2");
            }
        }
        if (isFaster)
        {

            if (timeFaster < Time.time)
            {
                isFaster = false;
                timeFaster = 0;
                Debug.Log("no more Fast");
                UI.updatePositionBuffDelete("Faster");
            }
        }
    }
    public void handleBonus(float bonusDuration,int type){
        switch (type) {
            case 0:
                timePositiv = Time.time + bonusDuration;
                //on vérifie que le buff n'est pas deja actif s'il ne l'est pas on update l'ui
                if (isPositiv) {
                    UI.updatePositionBuffDelete("Positiv");
                    UI.updatePositionBuffAdd("Positiv");
                }
                else
                    UI.updatePositionBuffAdd("Positiv");
                isPositiv = true;
                break;
            case 1:
                //on vérifie que le buff n'est pas deja actif s'il ne l'est pas on update l'ui
                if (isFaster)
                    UI.updatePositionBuffDelete("Faster");
                if (isSlower) {
                    UI.updatePositionBuffDelete("Slower");
                    UI.updatePositionBuffAdd("Slower");
                }
                else
                    UI.updatePositionBuffAdd("Slower");
                
                isSlower = true;
                isFaster = false;
                timeSlower = Time.time + bonusDuration;
                break;
        }
        UI.updatePositionBuff();
    }

    

    public void handleMalus(float malusDuration, GameObject obj, int type)
    {
        switch (type)
        {
            case 0:
                timeisX2 = Time.time + malusDuration;
                //on vérifie que le buff n'est pas deja actif s'il ne l'est pas on update l'ui
                if (isX2) {
                    UI.updatePositionBuffDelete("X2");
                    UI.updatePositionBuffAdd("X2");
                }
                else
                    UI.updatePositionBuffAdd("X2");
                isX2 = true;
                break;
            case 1:
                timeFaster = Time.time + malusDuration;
                //on vérifie que le buff n'est pas deja actif s'il ne l'est pas on update l'ui
                if (isSlower)
                    UI.updatePositionBuffDelete("Slower");
                if (isFaster) {
                    UI.updatePositionBuffDelete("Faster");
                    UI.updatePositionBuffAdd("Faster");
                }
                else
                    UI.updatePositionBuffAdd("Faster");
                
                isFaster = true;
                isSlower = false;
                break;
            case 2:
                timeBlind = Time.time + malusDuration;
                //on vérifie que le buff n'est pas deja actif s'il ne l'est pas on update l'ui
                if (isBlind) {
                    UI.updatePositionBuffDelete("Blind");
                    UI.updatePositionBuffAdd("Blind");
                }
                else
                    UI.updatePositionBuffAdd("Blind");
                isBlind = true;
                break;
        }
        Debug.Log(obj);
        UI.updatePositionBuff();
        Destroy(obj);

    }
}
