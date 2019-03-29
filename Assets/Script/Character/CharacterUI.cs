using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{


    //script principal du joueur
    private Character myPlayer;

    //variable Texte d'affichage
    

    //varaible Image 
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

    //variable transform Image
    [SerializeField]
    private RectTransform fBuffRect;
    [SerializeField]
    private RectTransform sBuffRect;
    [SerializeField]
    private RectTransform pBuffRect;
    [SerializeField]
    private RectTransform bBuffRect;
    [SerializeField]
    private RectTransform xBuffRect;




    [SerializeField]
    private GameObject textScoreGO;
    private TMPro.TextMeshProUGUI scoreText;

    //gameobject particle pour l'effet blind
    [SerializeField]
    private GameObject blindParticle;


    public List<string> listBuff;
    

    // Start is called before the first frame update
    void Start()
    {

        myPlayer = GetComponent<Character>();
        if (textScoreGO.GetComponent<TextMeshPro>())
            Debug.Log("yolo");
        scoreText = textScoreGO.GetComponent<TextMeshProUGUI>();
        
       
        

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
    public void updatePositionBuffDelete(string Type) {
        listBuff.Remove(Type);
        updatePositionBuff();

    }
    public void updatePositionBuffAdd(string Type) {
        
        listBuff.Add(Type);
        updatePositionBuff();
        
        
    }
    public void updatePositionBuff()
    {
        Debug.Log( listBuff.ToString());
        if (myPlayer.isX2)
            xBuffRect.localPosition = new Vector3(-50 * (listBuff.Count-1-listBuff.IndexOf("X2"))+100,0,0);
        if (myPlayer.isBlind)
            bBuffRect.localPosition = new Vector3(-50 * (listBuff.Count - 1 - listBuff.IndexOf("Blind")) + 100, 0, 0);
        if (myPlayer.isFaster)
            fBuffRect.localPosition = new Vector3(-50 * (listBuff.Count - 1 - listBuff.IndexOf("Faster")) + 100, 0, 0);
        if (myPlayer.isSlower)
            sBuffRect.localPosition = new Vector3(-50 * (listBuff.Count - 1 - listBuff.IndexOf("Slower")) + 100, 0, 0);
        if (myPlayer.isPositiv)
            pBuffRect.localPosition = new Vector3(-50 * (listBuff.Count - 1 - listBuff.IndexOf("Positiv")) + 100, 0, 0);
    }
    //fonction utilisé pour affciher le score du joueur
    private void updateScore() {
        scoreText.text = myPlayer.getScore().ToString();
    }




    //fonctions appelé toute les frames pour actualiser le temps restant des buffs présent sur le joueur
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
    //################################################"
    //update de l'effet de particule du Blind
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
