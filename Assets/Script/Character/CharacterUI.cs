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
    private GameObject textBuffGO;
    private Text textBuff;

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
        textBuff = textBuffGO.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        updateBuff();
        updateScore();
        updateBlind();
    }

    //fonction utilisé pour affciher le score du joueur
    private void updateScore() {
        scoreText.text = myPlayer.getScore().ToString();
    }

    //fonction appelé toute les frames pour actualiser le temps restant des buffs présent sur le joueur
    private void updateBuff()
    {
        string affichage = "";
        if (myPlayer.isX2)
        {
            affichage += " X2:" + (System.Math.Round((myPlayer.getTimeX2() - Time.time),0));
        }
        if (myPlayer.isBlind)
        {
            affichage += " Blind:" + (System.Math.Round((myPlayer.getTimeBlind() - Time.time),0));
        }
        if (myPlayer.isFaster)
        {
            affichage += " Faster:" + (System.Math.Round((myPlayer.getTimeFaster() - Time.time),0));
        }
        textBuff.text = affichage;
    }

    private void updateBlind() {
        if(myPlayer.isBlind) {
            blindParticle.SetActive(true);
        }
        else
        {
            blindParticle.SetActive(false);
        }

    }


    
}
