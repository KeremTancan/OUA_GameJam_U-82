using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOpener : MonoBehaviour
{
    public GameObject panel;
    
    public NefesBar nefesBar;

    public GameObject button;

    public void OpenPanel()
    {
        panel.SetActive(true); 
    }

    public void ClosePanel()
    {
        panel.SetActive(false); 
    }


    public void ScoreIncrease()
    {
   
        switch(ScoreCounter.scoreValue)
        {

         
            case >= 400:
                PlayerMovement.uwMoveSpeed += 1;
                ScoreCounter.scoreValue -= 400;
                button.SetActive(false);
                break;
             
            case >= 300:
                Debug.Log("nefes 90");
                nefesBar.SetMaxBreath(90);
                nefesBar.SetBreath(90);
                NefesBar.maxBreath = 90;
                NefesBar.currentBreath = 90;
                ScoreCounter.scoreValue -= 300;
                button.SetActive(false);
                break;

            case >= 250:
                PlayerMovement.uwMoveSpeed += 1;
                ScoreCounter.scoreValue -= 250;
                button.SetActive(false);
                break;

            case >=200:
                Debug.Log("nefes 60");
                nefesBar.SetMaxBreath(60);
                nefesBar.SetBreath(60);
                NefesBar.maxBreath = 60;
                NefesBar.currentBreath = 60;
                ScoreCounter.scoreValue -= 200;
                button.SetActive(false);
                break;


            case >= 150:
                PlayerMovement.uwMoveSpeed += 1;
                ScoreCounter.scoreValue -= 150;
                button.SetActive(false);
                break;

            case >=100:
                Debug.Log("nefes 45");
                nefesBar.SetMaxBreath(45);
                nefesBar.SetBreath(45);
                NefesBar.maxBreath = 45;
                NefesBar.currentBreath = 45;
                ScoreCounter.scoreValue -= 100;
                button.SetActive(false);
                break;
       
        
        }
        
        

        
    }

    

}

