using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{


    //script principal du joueur
    private Character myPlayer;

    //variable Texte d'affichage
    

    [SerializeField]
    private Image buffFaster;
    
    [SerializeField]
    private Image buffBlind;
    [SerializeField]
    private Image buffX2;
    [SerializeField]
    private Image buffPositiv;
    [SerializeField]
    private Image buffSlower;


    [SerializeField]
    private GameObject textScoreGO;
    private Text scoreText;

    //gameobject particle pour l'effet blind
    [SerializeField]
    private GameObject blindParticle;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = GetComponent<Character>();
        scoreText = textScoreGO.GetComponent<Text>();
       
        

    }

    // Update is called once per frame
    void Update()
    {
        updateScore();
        updateBlindParticle();
        updateFasterUi();
        updateBlind();
        updateX2();
        updatePositiv();
        updateSlower();


    }

    //fonction utilisé pour affciher le score du joueur
    private void updateScore() {
        scoreText.text = myPlayer.getScore().ToString();
    }

    //fonction appelé toute les frames pour actualiser le temps restant des buffs présent sur le joueur
    


    private void updateFasterUi(){
        
        if(myPlayer.isFaster) {
            buffFaster.enabled=true;//Keep track of the time that has passed
            buffFaster.fillAmount =  ((float)(System.Math.Round((myPlayer.getTimeFaster() - Time.time), 2))/10);

            
        }
        else 
            buffFaster.enabled=false;

        
    }

    private void updateBlind() {
        if (myPlayer.isBlind)
        {
            buffBlind.enabled = true;
            buffBlind.fillAmount = ((float)(System.Math.Round((myPlayer.getTimeBlind() - Time.time), 2)) / 10);
        }
        else
            buffBlind.enabled = false;
    }
    private void updateX2() {
        if (myPlayer.isX2) {
            buffX2.enabled = true;
            buffX2.fillAmount = ((float)(System.Math.Round((myPlayer.getTimeX2() - Time.time), 2)) / 10);
        }
        else
            buffX2.enabled = false;
    }
    private void updateSlower()
    {
        if (myPlayer.isSlower)
        {
            buffSlower.enabled = true;
            buffSlower.fillAmount = ((float)(System.Math.Round((myPlayer.getTimeSlower() - Time.time), 2)) / 10);
        }
        else
            buffSlower.enabled = false;
    }
    private void updatePositiv()
    {
        if (myPlayer.isPositiv)
        {
            buffPositiv.enabled = true;
            buffPositiv.fillAmount = ((float)(System.Math.Round((myPlayer.getTimePositiv() - Time.time), 2)) / 10);
        }
        else
            buffPositiv.enabled = false;
    }


    private void updateBlindParticle() {
        if(myPlayer.isBlind) {
            blindParticle.SetActive(true);
        }
        else
        {
            blindParticle.SetActive(false);
        }

    }


    
}
