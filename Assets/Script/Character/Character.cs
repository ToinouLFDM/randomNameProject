﻿using System.Collections;
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


	//variable pour afficher le texte
	Text LifeText;
	public GameObject Text;
	
	public GameObject Text2;

	// Use this for initialization
	void Start () 
	{
		//initilise le text affiché
		LifeText = Text.GetComponent <Text>();
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
		
		Count+=1;
		if (Count == 18) 
		{
			Count = 0;
			score += (Life_ / 10) + 1;
		}
        updateMalus();
        updateBonus();
        

	}
    public void updateBonus(){
        if(isPositiv) {
            if (timePositiv < Time.time) {
                isPositiv = false;
                timePositiv = 0;
            }
        }
        if(isSlower) {
            if(timeSlower < Time.time){
                isSlower = false;
                timeSlower = 0;
            }
           
        }
    }


    public void updateMalus() {
        if (isBlind){
            
            if (timeBlind < Time.time){
                isBlind = false;
                timeBlind = 0;
                Debug.Log("no more blind");
            }
        }
        if (isX2)
        {

            if (timeisX2 < Time.time)
            {
                isX2 = false;
                timeisX2= 0;
                Debug.Log("no more X2");
            }
        }
        if (isFaster)
        {

            if (timeFaster < Time.time)
            {
                isFaster = false;
                timeFaster = 0;
                Debug.Log("no more Fast");
            }
        }
    }
    public void handleBonus(float bonusDuration,int type){
        switch (type) {
            case 0:
                Debug.Log("Positiv");
                isPositiv = true;
                timePositiv = Time.time + bonusDuration;
                break;
            case 1:
                Debug.Log("Slower");
                isSlower = true;
                isFaster = false;
                timeSlower = Time.time + bonusDuration;
                break;
        }
    }

    

    public void handleMalus(float malusDuration, GameObject obj, int type)
    {
        switch (type)
        {
            case 0:
                isX2 = true;
                timeisX2 = Time.time + malusDuration;
                break;
            case 1:
                isFaster = true;
                isSlower = false;
                timeFaster = Time.time + malusDuration;
                break;
            case 2:
                isBlind = true;
                timeBlind = Time.time + malusDuration;
                break;
        }
        Debug.Log(obj);
        
        Destroy(obj);

    }
}
